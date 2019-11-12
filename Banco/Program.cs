using System;
using System.Collections.Generic;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            string escolha = "13";
            List<Conta> c = new List<Conta>();

            while (escolha != "12")
            {
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
                        Conta.CriarConta(c);
                        break;
                    case "3":
                        Console.Clear();
                        Conta.ListarConta(c);
                        OperacoesBasicas.Depositar(c);
                        break;
                    case "6":
                        Conta.ListarConta(c);
                        Console.Read();
                        break;
                    default:
                        break;
                }


            }

        }
    }
}
