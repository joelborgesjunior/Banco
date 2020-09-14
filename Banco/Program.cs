using System;
using System.Collections.Generic;
using System.Linq;

using Caelum.Banco.Entities;
using Caelum.Banco.Services;

namespace Caelum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Conta> c = new List<Conta>();
            DevedoresServices ds = new DevedoresServices();
            ContaServices cs = new ContaServices();
            TributosServices ts = new TributosServices();

            int NumeroDeContas = 0;
            uint NumeroDaConta = 1;
            double valor;
            string escolha = "0";
           
            while (escolha != "12")
            {
                int esc;

                for (int i = 0; i < c.Count; i++)
                {
                    if (c[i].Nome == null || c[i].Idade < 18 )
                        c.Remove(c[i]);
                }

                NumeroDeContas = c.Count;
                NumeroDaConta = cs.ProximaConta(c);
                var Lista = ds.GeraListaDevedor(c); 

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("*****BANCO POR CONSOLE*****");
                Console.WriteLine("ESCOLHA UMA DAS OPÇÕES ABAIXO");
                Console.WriteLine("1 - Criar Conta");
                Console.WriteLine("2 - Retirar Dinheiro");
                Console.WriteLine("3 - Depositar Dinheiro");
                Console.WriteLine("4 - Mostrar Saldo");
                Console.WriteLine("5 - Valor de todas as contas");
                Console.WriteLine("6 - Listar Contas");
                Console.WriteLine("7 - Atualizar Conta");
                Console.WriteLine("8 - Deletar Conta");
                Console.WriteLine("9 - Fazer Transferência entre Contas");
                Console.WriteLine("10 - Impostos do Banco");
                Console.WriteLine("11 - Total de Contas");
                Console.WriteLine("12 - Sair");

                escolha = Console.ReadLine();               

                switch (escolha)
                {
                    case "1":
                         Console.Clear();
                         Console.WriteLine("*****BANCO POR CONSOLE*****");
                         Console.WriteLine("QUAL TIPO DE CONTA A SER CRIADA:");
                         Console.WriteLine("1- Conta Corrente");
                         Console.WriteLine("2- Conta Poupança");
                         Console.WriteLine("3- Conta Investimento");
                         escolha = Console.ReadLine();
                         switch (escolha)
                         {
                             case "1":
                                 ContaCorrente e = new ContaCorrente();
                                 e.CriarConta(e, ds, NumeroDaConta, "Conta Corrente");                                 
                                 c.Add(e);                                
                                 break;
                             case "2":
                                 ContaPoupanca d = new ContaPoupanca();
                                 d.CriarConta(d, ds, NumeroDaConta, "Conta Poupança");
                                 c.Add(d);
                                 break;
                            case "3":
                                break;
                             default:
                                 Console.Clear();
                                 break;
                         }
                         break;
                    case "2":
                         Console.Clear();
                         Console.WriteLine("Selecione uma conta:");
                         cs.ListarContas(c);
                         esc = Convert.ToInt32(Console.ReadLine());
                         Console.WriteLine("Digite o valor a ser sacado:");
                         valor = Convert.ToDouble(Console.ReadLine());
                         cs.SacarDinheiro(esc, c, valor);
                         break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Selecione uma conta:");
                        cs.ListarContas(c);
                        esc = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o valor a ser depositado:");
                        valor = Convert.ToDouble(Console.ReadLine());
                        cs.DepositarDinheiro(esc, c, valor);
                        break;
                    case "4": 
                        Console.Clear();
                        Console.WriteLine("Selecione uma conta:");
                        cs.ListarContas(c);
                        esc = Convert.ToInt32(Console.ReadLine());
                        cs.MostrarSaldoConta(c, esc);
                        break;
                    case "5":
                        Console.Clear();
                        cs.SomaTotalContas(c);
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("LISTA COMPLETA DE CONTAS: ");
                        try 
                        {
                            cs.ListarContas(c);
                        }
                        catch(ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Não existe contas neste banco.", Console.ForegroundColor = ConsoleColor.Red);
                            Console.Read();
                        }
                        Console.Read();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Selecione uma conta:");
                        cs.ListarContas(c);
                        esc = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < c.Count; i++)
                        {
                            if (i + 1 == esc)
                            {
                                cs.AtualizarConta(c, c[i]);
                                break;
                            }
                        }
                        break;
                    case "8":
                        Console.Clear();
                        Console.WriteLine("Selecione uma conta para ser deletada:");
                        cs.ListarContas(c);
                        esc = Convert.ToInt32(Console.ReadLine());
                        cs.RemoverConta(c, esc);
                        break;
                    case "9":
                        Console.Clear();
                        Console.WriteLine("Selecione uma conta:");
                        cs.ListarContas(c);
                        esc = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o valor a ser transferido:");
                        valor = Convert.ToInt32(Console.ReadLine());
                        cs.TransferirDinheiro(esc, c, valor);
                        break;
                    case "10":
                        Console.Clear();                        
                        for (int i = 0; i < c.Count; i++)
                        {
                            if (c[i] is ContaPoupanca)
                            {
                                ContaPoupanca cp;
                                cp = (ContaPoupanca)c[i];
                                ts.Acumula(cp);
                            }
                            else if (c[i] is ContaInvestimento)
                            {
                                ContaInvestimento cp;
                                cp = (ContaInvestimento)c[i];
                                ts.Acumula(cp);
                            }
                        }
                        Console.WriteLine(Convert.ToString($"Total de Impostos cobrados de todas as contas é: {ts.Total.ToString("C")}"));
                        Console.Read();
                        break;
                    case "11":
                        Console.Clear();
                        Console.WriteLine($"O número de contas neste banco é de: {c.Count} contas");
                        Console.WriteLine($"Sendo:\n {c.Count(x => x.Tipo == "Conta Corrente")} Conta Corrente " +
                                          $" \n {c.Count(x => x.Tipo == "Conta Poupança")} Conta Poupança");
                        Console.Read();
                        break;
                    case "12":
                        break;
                    default:
                        Console.Clear();
                        break;
                }

            }
        }
    }
}
