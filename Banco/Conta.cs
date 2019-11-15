using Banco.TiposDeConta;
using System;
using System.Collections.Generic;

// Class da abstração de conta com seu CRUD genérico

namespace Banco
{
    public abstract class Conta : Cliente
    {
        public static void CriarConta(List<Conta> Co)
        {
            int escolha;
            OperacoesDadosClientes OpCliente = new OperacoesDadosClientes();

            try
            {
                Console.Clear();
                Console.WriteLine("Selecione o Tipo de Conta:");
                Console.WriteLine("1 - Conta Corrente");
                Console.WriteLine("2 - Conta Poupança");
                escolha = Convert.ToInt32(Console.ReadLine());

                if (escolha == 1)
                {
                    ContaCorrente c = new ContaCorrente();
                    Console.WriteLine("Entre com o Nome do Titular da Conta: ");
                    c.Nome = Console.ReadLine();
                    Console.WriteLine("Entre com a idade do Titular da conta: ");
                    c.Idade = Convert.ToInt32(Console.ReadLine());
                    OpCliente.MaiorDeIdade(c.Idade);
                    Console.WriteLine("Entre com o Saldo da Conta: ");
                    c.Saldo = Convert.ToDouble(Console.ReadLine());
                    c.TipoConta = "Conta Corrente";
                    Co.Add(c);
                    c.Numero = Co.Count;
                    Console.WriteLine($"Cliente {c.Nome} criado com sucesso!",
                        Console.ForegroundColor = ConsoleColor.Green);
                    Console.Read();
                }
                else if (escolha == 2)
                {
                    ContaPoupanca p = new ContaPoupanca();
                    Console.WriteLine("Entre com o Nome do Titular da Conta: ");
                    p.Nome = Console.ReadLine();
                    Console.WriteLine("Entre com a idade do Titular da conta: ");
                    p.Idade = Convert.ToInt32(Console.ReadLine());
                    OpCliente.MaiorDeIdade(p.Idade);
                    Console.WriteLine("Entre com o Saldo da Conta: ");
                    p.Saldo = Convert.ToDouble(Console.ReadLine());
                    p.TipoConta = "Conta Poupança";
                    Co.Add(p);
                    p.Numero = Co.Count;
                    Console.WriteLine($"Cliente {p.Nome} criado com sucesso!",
                        Console.ForegroundColor = ConsoleColor.Green);
                    Console.Read();
                }
            }

            catch (System.FormatException)
            {
                Console.WriteLine($"ERRO: Opção/Formato Inexistente. Operação Cancelada",
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

        public static void RemoverConta(List<Conta> c)
        {
            string escolha;

            Console.WriteLine("Selecione uma Conta:");
            escolha = Console.ReadLine();
            c.RemoveAll(c => c.Numero == Convert.ToInt32(escolha));
            Console.WriteLine($"A conta foi removida com sucesso!",
                                Console.ForegroundColor = ConsoleColor.Green);
            Console.Read();
        }

        public static void AtualizarConta(List<Conta> c)
        {
            int escolha;

            try
            {
                Console.WriteLine("Selecione uma Conta:");
                escolha = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < c.Count; i++)
                {
                    if (c[i].Numero == escolha)
                    {
                        Console.WriteLine("O número não pode ser alterado depois de criado.");
                        Console.WriteLine($" O Nome do Titular é {c[i].Nome}. Entre com o novo Nome do Titular da Conta: ");
                        c[i].Nome = Console.ReadLine();
                        Console.WriteLine($"A idade do Titular é {c[i].Idade}. Entre com a nova idade do Titular da conta: ");
                        c[i].Idade = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("O Saldo não pode ser alterado depois de criado.");
                        Console.WriteLine($"Cliente {c[i].Nome} atualizado com sucesso!",
                                Console.ForegroundColor = ConsoleColor.Green);
                        Console.Read();
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
