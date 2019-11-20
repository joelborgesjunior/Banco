using System;
using Banco.Operações;
using System.Collections.Generic;
using System.IO;

namespace Banco
{
    public class GeradorDeMenu
    {     

        public static void GeraMenu(){
            
            string escolha = "13";
            List<Conta> c = new List<Conta>();
            Conta Co = new Conta();
            OperacoesSecundarias OpSec = new OperacoesSecundarias();

            while (escolha != "12")
            {
                for (int i = 0; i < c.Count; i++)
                {
                    if (c[i].Nome == string.Empty || c[i].Nome == " " || c[i].Idade < 18)
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
                        OperacoesBasicas.CriarConta(c);
                        break;
                    case "2":
                        Console.Clear();
                        OpSec.ListarConta(c);
                        Co.Sacar(c);
                        break;
                    case "3":
                        OpSec.ListarConta(c);
                        Co.Depositar(c);
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
                        OperacoesBasicas.AtualizarConta(c);
                        break;
                    case "8":
                        OpSec.ListarConta(c);
                        OperacoesBasicas.RemoverConta(c);
                        break;
                    case "9":
                        OpSec.ListarConta(c);
                        Co.Transferir(c);
                        break;
                    case "10":
                        OpSec.SomarImpostos(c);
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