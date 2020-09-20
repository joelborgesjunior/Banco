using System;
using Caelum.Banco.Db;
using Caelum.Banco.Services;

namespace Caelum
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumeroDeContas = 0;
            uint NumeroDaConta = 1;
            string escolha = "0";
            uint NumeroContaEscolhida = 0;

            ContaServices contaServices = new ContaServices();
            DevedoresServices devedoresServices = new DevedoresServices();
           
            while (escolha != "12")
            {
               devedoresServices.GeraListaDevedor();

                for (int i = 0; i < BancoDeDados.Clientes.Count; i++)
                {
                    if ( BancoDeDados.Clientes[i].Nome == null || 
                         BancoDeDados.Clientes[i].Idade < 18 ) 
                    {
                        BancoDeDados.Clientes.Remove(BancoDeDados.Clientes[i]);
                    }
                }

                NumeroDeContas = BancoDeDados.Contas.Count;
                BancoDeDados.ProximaConta(ref NumeroDaConta);

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
                         contaServices.CriarConta(NumeroDaConta);
                         break;
                    case "2":
                         Console.Clear();
                         Console.WriteLine("Selecione uma conta:");
                         contaServices.ListarContas();
                         NumeroContaEscolhida = Convert.ToUInt32(Console.ReadLine());
                         contaServices.Retirada(NumeroContaEscolhida);
                         break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Selecione uma conta:");
                        contaServices.ListarContas();
                        NumeroContaEscolhida = Convert.ToUInt32(Console.ReadLine());                        
                        contaServices.Deposito(NumeroContaEscolhida);
                        break;
                    case "4": 
                        Console.Clear();
                        Console.WriteLine("Selecione uma conta:");
                        contaServices.ListarContas();
                        NumeroContaEscolhida = Convert.ToUInt32(Console.ReadLine());
                        contaServices.MostrarSaldoConta(NumeroContaEscolhida);
                        break;
                    case "5":
                        Console.Clear();
                        contaServices.SomaTotalContas();
                        break;
                    case "6":
                        Console.Clear();                        
                        if( BancoDeDados.Contas.Count > 0 )
                        {
                            Console.WriteLine("LISTA COMPLETA DE CONTAS: ");
                            contaServices.ListarContas();
                        } else 
                        {
                        Console.WriteLine("Não existe contas neste banco.", Console.ForegroundColor = ConsoleColor.Red);
                        }
                        Console.Read();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Selecione uma conta:");
                        contaServices.ListarContas();
                        NumeroContaEscolhida = Convert.ToUInt32(Console.ReadLine());
                        contaServices.AtualizarConta(NumeroContaEscolhida);
                        break;
                    case "8":
                        Console.Clear();
                        Console.WriteLine("Selecione uma conta para ser deletada:");
                        contaServices.ListarContas();
                        NumeroContaEscolhida = Convert.ToUInt32(Console.ReadLine());
                        contaServices.RemoverConta(NumeroContaEscolhida);
                        break;
                    case "9":
                        Console.Clear();
                        Console.WriteLine("Selecione uma conta de origem:");
                        contaServices.ListarContas();
                        NumeroContaEscolhida = Convert.ToUInt32(Console.ReadLine());
                        contaServices.TransferirDinheiro(NumeroContaEscolhida);
                        break;
                    case "10":
                        Console.Clear();                        
                        contaServices.CalculoImpostoBanco();
                        break;
                    case "11":
                        Console.Clear();
                        contaServices.NumeroTotalDeContas();
                        Console.Read();
                        break;
                    default:
                        Console.Clear();
                        break;
                }

            }
        }
    }
}
