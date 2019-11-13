using System;
using System.Collections.Generic;
using Banco.Interfaces;

// Classe com as operações básicas de uma Conta (Depositar, Sacar, Transferir)

namespace Banco
{
    public class OperacoesBasicas : IOperacoesBasicas
    {
        public void Depositar(List<Conta> c)
        {
            int escolha;
            double valor;

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

        public void Sacar(List<Conta> c)
        {
            int escolha;
            double valor;

            Console.WriteLine("Selecione uma Conta:");
            escolha = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o Valor do saque:");
            valor = Convert.ToDouble(Console.ReadLine());

            for (int i = 0; i < c.Count; i++)
            {
                if (c[i].Numero == escolha)
                {
                    c[i].Saldo -= valor;
                    Console.WriteLine($"Saque de {valor.ToString("C")} feito com sucesso.",
                        Console.ForegroundColor = ConsoleColor.Green);
                    Console.WriteLine($"A Conta de {c[i].Nome} agora tem um saldo de {c[i].Saldo.ToString("C")}",
                        Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.Read();
                    break;
                }
            }
        }

        public void Transferir(List<Conta> c)
        {
            int remetente, destinatario;
            double valor;

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
                            c[i].Saldo -= valor;
                            Console.WriteLine($"Saque de {valor.ToString("C")} da conta {c[i].Numero} de " +
                                $"{c[i].Nome} feito com sucesso.",
                                Console.ForegroundColor = ConsoleColor.Green);
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
}
