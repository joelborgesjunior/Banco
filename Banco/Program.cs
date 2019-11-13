using System;
using System.Collections.Generic;


// Class programa onde roda o banco


namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            string escolha = "13";
            List<Conta> c = new List<Conta>();
            OperacoesBasicas OpBasic = new OperacoesBasicas(); 
            OperacoesSecundarias OpSec = new OperacoesSecundarias();

            while (escolha != "12")
            {
                for (int i = 0; i < c.Count; i++)
                {
                    if (c[i].Nome == null || c[i].Nome == " " || c[i].Idade < 18)
                    {
                        c.Remove(c[i]);
                    }
                }

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
                        Conta.CriarConta(c);
                        break;
                    case "2":
                        Console.Clear();
                        OpSec.ListarConta(c);
                        OpBasic.Sacar(c);
                        break;
                    case "3":
                        OpSec.ListarConta(c);
                        OpBasic.Depositar(c);
                        break;
                    case "4":
                        OpSec.ListarConta(c);
                        OpSec.MostrarSaldo(c);
                        break;
                    case "5":
                        OpSec.SomaValorContas(c);
                        break;
                    case "6":
                        OpSec.ListarConta(c);
                        Console.Read();
                        break;
                    case "7":
                        OpSec.ListarConta(c);
                        Conta.AtualizarConta(c);
                        break;
                    case "8":
                        OpSec.ListarConta(c);
                        Conta.RemoverConta(c);
                        break;
                    case "9":
                        OpSec.ListarConta(c);
                        OpBasic.Transferir(c);
                        break;
                    case "10":
                        break;
                    case "11":
                        OpSec.TotalDeContas(c);
                        break;
                    case "12":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
