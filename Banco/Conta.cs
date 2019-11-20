using Banco.TiposDeConta;
using System;
using System.Collections.Generic;
using Banco.Operações;

// Class da abstração de conta com seu CRUD genérico

namespace Banco
{
    public class Conta : Cliente
    {
        public void Depositar(List<Conta> c)
        {
            int escolha;
            double valor;
            try
            {
                if(c.Count > 0)
                {
                    Console.WriteLine("Selecione uma Conta:");
                    escolha = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o Valor a ser depositado:");
                    valor = Convert.ToDouble(Console.ReadLine());

                    for (int i = 0; i < c.Count; i++)
                    {
                        if (c[i].Numero == escolha)
                        {
                            c[i].Saldo += valor;
                            Console.WriteLine($"Depósito de {valor.ToString("C")} feito com sucesso.",
                                Console.ForegroundColor = ConsoleColor.Green);
                            Console.WriteLine($"A Conta de {c[i].Nome} agora tem um saldo de {c[i].Saldo.ToString("C")}",
                                Console.ForegroundColor = ConsoleColor.Yellow);
                            break;
                        }
                    }
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine($"ERRO: Opção/Formato Inexistente. Operação Cancelada",
                        Console.ForegroundColor = ConsoleColor.Red);
                Console.Read();
            }
        }
        public void Sacar(List<Conta> c)
        {
            OperacoesDadosClientes OpCliente = new OperacoesDadosClientes();
            OperacoesSecundarias OpSec = new OperacoesSecundarias();
            int escolha;
            double valor;

            try
            {
                if(c.Count > 0)
                {
                    Console.WriteLine("Selecione uma Conta:");
                    escolha = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o Valor do saque:");
                    valor = Convert.ToDouble(Console.ReadLine());

                    for (int i = 0; i < c.Count; i++)
                    {
                        if (c[i].Numero == escolha)
                        {
                            c[i].Saldo -= (valor + OpCliente.TaxaSaque(c[i], valor));
                            Console.WriteLine($"Saque de {valor.ToString("C")} feito com sucesso.",
                                Console.ForegroundColor = ConsoleColor.Green);
                            Console.WriteLine($"Valor da taxa de saque: {OpCliente.TaxaSaque(c[i], valor).ToString("C")}",
                                Console.ForegroundColor = ConsoleColor.Cyan);
                            c[i].GastoTaxas += OpCliente.TaxaSaque(c[i], valor);
                            Console.WriteLine($"A Conta de {c[i].Nome} agora tem um saldo de {c[i].Saldo.ToString("C")}",
                                Console.ForegroundColor = ConsoleColor.Yellow);
                            Console.Read();
                            break;
                        }
                    }
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine($"ERRO: Opção/Formato Inexistente. Operação Cancelada",
                        Console.ForegroundColor = ConsoleColor.Red);
                Console.Read();
            }
        }
        public void Transferir(List<Conta> c)
        {
            int remetente, destinatario;
            double valor;
            OperacoesDadosClientes OpCliente = new OperacoesDadosClientes();
            try
            {
                if(c.Count > 0)
                {
                    Console.WriteLine("Selecione uma Conta:");
                    remetente = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < c.Count; i++)
                    {
                        if (c[i].Numero == remetente)
                        {
                            Console.WriteLine("Selecione uma Conta destino:");
                            destinatario = Convert.ToInt32(Console.ReadLine());
                            for (int j = 0; j < c.Count; j++)
                            {
                                if (c[j].Numero == destinatario)
                                {
                                    Console.WriteLine("Digite o Valor do saque:");
                                    valor = Convert.ToDouble(Console.ReadLine());
                                    c[i].Saldo -= (valor + OpCliente.TaxaSaque(c[i], valor));
                                    Console.WriteLine($"Saque de {valor.ToString("C")} feito com sucesso.",
                                        Console.ForegroundColor = ConsoleColor.Green);                                        
                                    c[i].GastoTaxas += OpCliente.TaxaSaque(c[i], valor);
                                    Console.WriteLine($"Valor da taxa de saque: {OpCliente.TaxaSaque(c[i], valor).ToString("C")}",
                                        Console.ForegroundColor = ConsoleColor.Cyan);
                                    Console.WriteLine($"A Conta de {c[i].Nome} agora tem um saldo de {c[i].Saldo.ToString("C")}",
                                        Console.ForegroundColor = ConsoleColor.Yellow);
                                    c[j].Saldo += valor;
                                    Console.WriteLine($"Deposito de {valor.ToString("C")} da conta {c[j].Numero} de " +
                                        $"{c[j].Nome} feito com sucesso.",
                                        Console.ForegroundColor = ConsoleColor.Green);
                                    Console.WriteLine($"A Conta de {c[j].Nome} agora tem um saldo de {c[j].Saldo.ToString("C")}",
                                        Console.ForegroundColor = ConsoleColor.Yellow);
                                    Console.Read();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine($"ERRO: Opção/Formato Inexistente. Operação Cancelada",
                        Console.ForegroundColor = ConsoleColor.Red);
                Console.Read();
            }
        }
    }
}
