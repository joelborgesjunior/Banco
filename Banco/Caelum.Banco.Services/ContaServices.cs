using System;
using System.Linq;

using Caelum.Banco.Entities;
using Caelum.Banco.Interfaces;
using Caelum.Banco.Interfaces.Enums;
using Caelum.Banco.Db;

namespace Caelum.Banco.Services
{
    public class ContaServices
    {   
        decimal valor = 0.00m;     
        TributosServices tributosServices = new TributosServices();

        public void CriarConta(uint numeroDaConta)
        {
            string escolha = "0";            
            IConta conta;
            Cliente cliente = new Cliente();
            DevedoresServices devedoresServices = new DevedoresServices();

            try
            {
                Console.Clear();
                Console.WriteLine("*****BANCO POR CONSOLE*****");
                Console.WriteLine("QUAL TIPO DE CONTA A SER CRIADA:");
                Console.WriteLine("1- Conta Corrente");
                Console.WriteLine("2- Conta Poupança");
                escolha = Console.ReadLine();

                conta = escolha switch 
                {  
                    "1" => new ContaCorrente(TipoContaEnums.ContaCorrente, cliente),  
                    "2" => new ContaPoupanca(TipoContaEnums.ContaPoupança, cliente),
                    _   => throw new Exception()
                }; 

                conta.Numero = numeroDaConta;
                Console.WriteLine($"O número dessa conta será: {conta.Numero}");
                Console.WriteLine("Entre com o Nome do Titular da Conta: ");
                cliente.Nome = Console.ReadLine();

                if (devedoresServices.VerificarSeDevedor(conta.Cliente.Nome))
                {
                    Console.WriteLine("Entre com a idade do Titular da conta: ");
                    conta.Cliente.Idade = Convert.ToInt32(Console.ReadLine());
                    ClienteServices.MaiorDeIdade(conta.Cliente.Idade);
                    Console.WriteLine("Entre com o Saldo da Conta: ");
                    conta.Saldo = Convert.ToInt32(Console.ReadLine());
                }            

            BancoDeDados.Contas.Add(conta);
            BancoDeDados.Clientes.Add(cliente);

            Console.WriteLine($"Cliente {conta.Cliente.Nome} criado com sucesso!",
                    Console.ForegroundColor = ConsoleColor.Green);
            
            Console.Read();

            } catch (FormatException)
            {
                Console.WriteLine("Formato não aceite. Tente novamente",
                     Console.ForegroundColor = ConsoleColor.Red);
                Console.Read();

            } 
             catch (Exception)
            {
                Console.WriteLine("Você não pode abrir uma conta. Você é menor de idade.",
                    Console.ForegroundColor = ConsoleColor.Red);
                Console.Read();
            }
        }

        public void RemoverConta(uint ContaEscolhida)
        {    
            var conta = BancoDeDados.Contas.FirstOrDefault(conta => conta.Numero == ContaEscolhida);
            BancoDeDados.Contas.RemoveAll(conta => conta.Numero == ContaEscolhida);
            Console.WriteLine($"Conta do cliente {conta.Cliente.Nome} removida com sucesso!",
                    Console.ForegroundColor = ConsoleColor.Blue);
                Console.Read();
        }

        public void AtualizarConta(uint numeroDaConta)
        {   
            for (int i = 0; i < BancoDeDados.Contas.Count; i++)
            {
                if (BancoDeDados.Contas[i].Numero == numeroDaConta)
                {             
                    try
                    {                        
                        Console.WriteLine("O número não pode ser alterado depois de criado.");
                        Console.WriteLine($" O Nome do Titular é {BancoDeDados.Contas[i].Cliente.Nome}. Entre com o novo Nome do Titular da Conta: ");
                        BancoDeDados.Contas[i].Cliente.Nome = Console.ReadLine();
                        Console.WriteLine($"A idade do Titular é {BancoDeDados.Contas[i].Cliente.Idade}. Entre com a nova idade do Titular da conta: ");
                        BancoDeDados.Contas[i].Cliente.Idade = Convert.ToInt32(Console.ReadLine());
                        ClienteServices.MaiorDeIdade(BancoDeDados.Contas[i].Cliente.Idade);
                        Console.WriteLine("O Saldo não pode ser alterado depois de criado.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Formato não aceite. Tente novamente",
                            Console.ForegroundColor = ConsoleColor.Red);                    
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Você não pode abrir uma conta. Você é menor de idade.",
                            Console.ForegroundColor = ConsoleColor.Red);
                        Console.Read();
                    }

                    Console.WriteLine($"Cliente {BancoDeDados.Contas[i].Cliente.Nome} atualizado com sucesso!",
                            Console.ForegroundColor = ConsoleColor.Green);
                    Console.Read();
                }
            }
        }

        public void ListarContas()
        {
            foreach (var conta in BancoDeDados.Contas)
                Console.WriteLine($"{conta.Numero} - {conta.Cliente.Nome}");
        }
        
        public void MostrarSaldoConta(uint numeroDaConta)
        {   
           foreach (var conta in BancoDeDados.Contas)
            {
                if (conta.Numero == numeroDaConta)
                {
                    try
                    {
                        Console.WriteLine($"O Saldo da conta do Titular {conta.Cliente.Nome} é de {conta.Saldo.ToString("C")}");
                        Console.Read();
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine($"Erro: Não existe conta para mostrar saldo. Selecione ou crie uma nova conta.",
                               Console.ForegroundColor = ConsoleColor.Red);
                        Console.Read();
                    }
                }
            }           
        }

        public void NumeroTotalDeContas()
        {
            Console.WriteLine($"O número de contas neste banco é de: {BancoDeDados.Contas.Count} contas");
            Console.WriteLine($"Sendo:\n " +
                              $"{BancoDeDados.Contas.Count(conta => conta.Tipo == TipoContaEnums.ContaCorrente )} Conta Corrente, " +
                              $" \n {BancoDeDados.Contas.Count(conta => conta.Tipo == TipoContaEnums.ContaPoupança )} Conta Poupança. ");                       
        }

        public void Retirada( uint numeroDaConta )
        {
            Console.WriteLine("Digite o valor a ser sacado:");
            valor = Convert.ToDecimal(Console.ReadLine());
            
            for (int i = 0; i < BancoDeDados.Contas.Count; i++)
            {
                if (BancoDeDados.Contas[i].Numero == numeroDaConta)
                {                    
                    if (BancoDeDados.Contas[i].Saldo >= valor && BancoDeDados.Contas[i].Cliente.Idade >= 18)
                    {
                        BancoDeDados.Contas[i].SacarDinheiro(valor);
                        Console.WriteLine($"Saque de {valor.ToString("C")} feito com sucesso.",
                            Console.ForegroundColor = ConsoleColor.Green);
                        MostrarSaldoConta( numeroDaConta );
                        Console.Read();
                    }
                    else if (BancoDeDados.Contas[i].Saldo >= valor && BancoDeDados.Contas[i].Cliente.Idade < 18 && valor < 201)
                    {
                        BancoDeDados.Contas[i].SacarDinheiro(valor);
                        Console.WriteLine($"Saque de {valor.ToString("C")} feito com sucesso.",
                            Console.ForegroundColor = ConsoleColor.Green);
                        MostrarSaldoConta(numeroDaConta);
                        Console.Read();
                    }
                    else if (BancoDeDados.Contas[i].Saldo >= valor && BancoDeDados.Contas[i].Cliente.Idade < 18 && valor > 200)
                    {
                        Console.WriteLine($"Saque de {valor.ToString("C")} rejeitado. Você não tem idade suficiente para " +
                            $"saques maiores que 200 reais.",
                               Console.ForegroundColor = ConsoleColor.Red);
                        MostrarSaldoConta(numeroDaConta);
                        Console.Read();
                    }
                    else
                    {
                        Console.WriteLine($"Saque de {valor.ToString("C")} rejeitado. Você não tem saldo.",
                            Console.ForegroundColor = ConsoleColor.Red);
                        MostrarSaldoConta(numeroDaConta);
                        Console.Read();
                    }
                }
            }            
        }

        public void Deposito(uint numeroDaConta)
        {
            Console.WriteLine("Digite o valor a ser depositado:");
            valor = Convert.ToDecimal(Console.ReadLine());

            for (int i = 0; i < BancoDeDados.Contas.Count; i++)
            {
                if (BancoDeDados.Contas[i].Numero == numeroDaConta)
                {
                    BancoDeDados.Contas[i].DepositarDinheiro(valor);
                    Console.WriteLine($"Depósito de {valor.ToString("C")} feito com sucesso.", 
                    Console.ForegroundColor = ConsoleColor.Green);
                    MostrarSaldoConta(numeroDaConta);
                    break;
                }
            }
        }

        public void TransferirDinheiro(uint numeroDaConta)
        {            
            Console.WriteLine("Digite o valor a ser transferido:");
            valor = Convert.ToDecimal(Console.ReadLine());
            for (int i = 0; i < BancoDeDados.Contas.Count; i++)
            {
                if(BancoDeDados.Contas[i].Numero == numeroDaConta)
                {
                    if (BancoDeDados.Contas[i].Saldo >= valor)
                    {
                        int destino;
                        Console.WriteLine("Selecione uma conta para depositar o valor:");
                        ListarContas();
                        destino = Convert.ToInt32(Console.ReadLine());
                        BancoDeDados.Contas[i].SacarDinheiro(valor);
                        BancoDeDados.Contas[destino-1].DepositarDinheiro(valor);
                        Console.WriteLine($"Depósito de {valor.ToString("C")} na conta de número " +
                                          $"{BancoDeDados.Contas[destino-1].Numero} de " +
                                          $"{BancoDeDados.Contas[destino-1].Cliente.Nome} feita com sucesso.",
                                            Console.ForegroundColor = ConsoleColor.Green);
                        Console.WriteLine($"Retirada de {valor.ToString("C")} na conta de número " +
                                          $"{BancoDeDados.Contas[i].Numero} de " +
                                          $"{BancoDeDados.Contas[i].Cliente.Nome} feita com sucesso.",
                                            Console.ForegroundColor = ConsoleColor.Red);
                        Console.Read();
                        
                    }
                    else
                    {
                        Console.WriteLine($"Transferência de {valor.ToString("C")} rejeitada. Você não tem saldo.",
                            Console.ForegroundColor = ConsoleColor.Red);
                        Console.Read();
                    }
                }
                
            }                        
        }

        public void CalculoImpostoBanco()
        {
            for (int i = 0; i < BancoDeDados.Contas.Count; i++)
            {
                if (BancoDeDados.Contas[i] is ContaPoupanca)
                {
                    ContaPoupanca cp;
                    cp = (ContaPoupanca)BancoDeDados.Contas[i];
                    tributosServices.Acumula(cp);
                }
            }
            Console.WriteLine(Convert.ToString($"Total de Impostos cobrados de todas as contas é: {tributosServices.Total.ToString("C")}"));
            Console.Read();
        }      
    
        public void SomaTotalContas()
        {
            Console.WriteLine($"O Valor total das contas é de {BancoDeDados.Contas.Sum(conta => conta.Saldo).ToString("C")}");
            Console.Read();
        }    
    }
}