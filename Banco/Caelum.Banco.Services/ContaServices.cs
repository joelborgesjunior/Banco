using System;
using System.Collections.Generic;
using System.Linq;

using Caelum.Banco.Entities;

namespace Caelum.Banco.Services
{
    public class ContaServices : Conta
    {
      public void CriarConta(Conta c, DevedoresServices gerador, uint NumeroDaConta, string Tipo)
        {
            try
            {
                c.Numero = NumeroDaConta;
                Console.WriteLine($"O número dessa conta será: {NumeroDaConta}");
                Console.WriteLine("Entre com o Nome do Titular da Conta: ");
                c.Nome = Console.ReadLine();

                if (gerador.VerificarSeDevedor(c.Nome))
                {
                    Console.WriteLine("Entre com a idade do Titular da conta: ");
                    c.Idade = Convert.ToInt32(Console.ReadLine());
                    ClienteServices.MaiorDeIdade(c.Idade);
                    Console.WriteLine("Entre com o Saldo da Conta: ");
                    c.Saldo = Convert.ToInt32(Console.ReadLine());
                    if (Tipo == "Conta Corrente")
                        c.Tipo = Tipo;
                    else if (Tipo == "Conta Poupança")
                        c.Tipo = Tipo;
                }

            } catch (FormatException)
            {
                Console.WriteLine("Formato não aceite. Tente novamente",
                     Console.ForegroundColor = ConsoleColor.Red);
                Console.Read();

            } catch (Exception)
            {
                Console.WriteLine("Você não pode abrir uma conta. Você é menor de idade.",
                    Console.ForegroundColor = ConsoleColor.Red);
                Console.Read();
            }

            Console.WriteLine($"Cliente {c.Nome} criado com sucesso!",
                    Console.ForegroundColor = ConsoleColor.Green);
            Console.Read();
        }

        public void RemoverConta(List<Conta> c, int esc)
        {
            c.RemoveAll(x => x.Numero == esc);
        }

        public void AtualizarConta(List<Conta> Li, Conta c)
        {
            try
            {
                Console.WriteLine("O número não pode ser alterado depois de criado.");
                Console.WriteLine($" O Nome do Titular é {c.Nome}. Entre com o novo Nome do Titular da Conta: ");
                c.Nome = Console.ReadLine();
                Console.WriteLine($"A idade do Titular é {c.Idade}. Entre com a nova idade do Titular da conta: ");
                c.Idade = Convert.ToInt32(Console.ReadLine());
                ClienteServices.MaiorDeIdade(c.Idade);
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

            Console.WriteLine($"Cliente {c.Nome} atualizado com sucesso!",
                    Console.ForegroundColor = ConsoleColor.Green);
            Console.Read();
        }

        public void ListarContas(List<Conta> c)
        {
            foreach (var conta in c)
                Console.WriteLine($"{conta.Numero} - {conta.Nome}");
        }
        
        public void MostrarSaldoConta(List<Conta> c, int esc)
        {   
           foreach (var conta in c)
            {
                if (conta.Numero == esc)
                {
                    try
                    {
                        Console.WriteLine($"O Saldo da conta do Titular {conta.Nome} é de {conta.Saldo.ToString("C")}");
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

        public virtual void SacarDinheiro( int escolha, List<Conta> c, double valor)
        {
            for (int i = 0; i < c.Count; i++)
            {
                if (c[i].Numero == escolha)
                {                    
                    if (c[i].Saldo >= valor && c[i].Idade >= 18)
                    {
                        c[i].Saldo -= valor;
                        Console.WriteLine($"Saque de {valor.ToString("C")} feito com sucesso.",
                            Console.ForegroundColor = ConsoleColor.Green);
                        MostrarSaldoConta(c, escolha);
                        Console.Read();
                    }
                    else if (c[i].Saldo >= valor && c[i].Idade < 18 && valor < 201)
                    {
                        c[i].Saldo -= valor;
                        Console.WriteLine($"Saque de {valor.ToString("C")} feito com sucesso.",
                            Console.ForegroundColor = ConsoleColor.Green);
                        MostrarSaldoConta(c, escolha);
                        Console.Read();
                    }
                    else if (c[i].Saldo >= valor && c[i].Idade < 18 && valor > 200)
                    {
                        Console.WriteLine($"Saque de {valor.ToString("C")} rejeitado. Você não tem idade suficiente para " +
                            $"saques maiores que 200 reais.",
                               Console.ForegroundColor = ConsoleColor.Red);
                        MostrarSaldoConta(c, escolha);
                        Console.Read();
                    }
                    else
                    {
                        Console.WriteLine($"Saque de {valor.ToString("C")} rejeitado. Você não tem saldo.",
                            Console.ForegroundColor = ConsoleColor.Red);
                        MostrarSaldoConta(c, escolha);
                        Console.Read();
                    }
                }
            }            
        }

        public virtual void DepositarDinheiro( int escolha, List<Conta> c, double valor )
        {
            for (int i = 0; i < c.Count; i++)
            {
                if (c[i].Numero == escolha)
                {
                    c[i].Saldo += valor;
                    Console.WriteLine($"Depósito de {valor.ToString("C")} feito com sucesso.", 
                        Console.ForegroundColor = ConsoleColor.Green);
                    MostrarSaldoConta(c, escolha);
                    break;
                }
            }
        }

        public void TransferirDinheiro(int escolha, List<Conta> c, double valor )
        {
            for (int i = 0; i < c.Count; i++)
            {
                if(c[i].Numero == escolha)
                {
                    if (c[i].Saldo >= valor)
                    {
                        int destino;
                        Console.WriteLine("Selecione uma conta para depositar o valor:");
                        ListarContas(c);
                        destino = Convert.ToInt32(Console.ReadLine());
                        SacarDinheiro(escolha, c, valor);
                        DepositarDinheiro(destino, c, valor);
                        Console.WriteLine($"Depósito de {valor.ToString("C")} na conta {c[destino-1]} feita com sucesso.",
                            Console.ForegroundColor = ConsoleColor.Green);
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
    
        public void SomaTotalContas (List<Conta> c)
        {
            Console.WriteLine($"O Valor total das contas é de {c.Sum(c => c.Saldo).ToString("C")}");
            Console.Read();
        }        
        
        public uint ProximaConta(List<Conta> c)
        {
            if (c.Count == 0)
            {
                return 1;
            }

            for (int i = 0; i < c.Count; i++)
            {
                if (i + 1 != c[i].Numero)
                {
                    return (uint)i + 1;
                }
            }

            return (uint)c.Count + 1;
        }
    }
}