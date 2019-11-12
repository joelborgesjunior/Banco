using System;
using System.Collections.Generic;
using System.Text;
using Banco.TiposDeConta;
using System.Linq;


// Class da abstração de conta

namespace Banco
{
    public abstract class Conta : Cliente
    {
        public static void CriarConta(List<Conta> Co)
        {
            int escolha;

            Console.Clear();
            Console.WriteLine("Selecione o Tipo de Conta:");
            Console.WriteLine("1 - Conta Corrente");
            Console.WriteLine("2 - Conta Poupança");
            escolha = Convert.ToInt32(Console.ReadLine());

            if (escolha == 1)
            {
                ContaCorrente c = new ContaCorrente();
                c.QTdCC++;
                c.Numero = c.QTdCC;
                c.TipoConta = "Conta Corrente";
                Console.WriteLine("Entre com o Nome do Titular da Conta: ");
                c.Nome = Console.ReadLine();
                Console.WriteLine("Entre com a idade do Titular da conta: ");
                c.Idade = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Entre com o Saldo da Conta: ");
                c.Saldo = Convert.ToDouble(Console.ReadLine());
                Co.Add(c);
                Console.WriteLine($"Cliente {c.Nome} criado com sucesso!",
                    Console.ForegroundColor = ConsoleColor.Green);
                Console.Read();
            }
            else if (escolha == 2)
            {
                ContaPoupanca p = new ContaPoupanca();
                p.QtdCP++;
                p.Numero = p.QtdCP;
                p.TipoConta = "Conta Poupança";
                Console.WriteLine("Entre com o Nome do Titular da Conta: ");
                p.Nome = Console.ReadLine();
                Console.WriteLine("Entre com a idade do Titular da conta: ");
                p.Idade = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Entre com o Saldo da Conta: ");
                p.Saldo = Convert.ToDouble(Console.ReadLine());
                Co.Add(p);
                Console.WriteLine($"Cliente {p.Nome} criado com sucesso!",
                    Console.ForegroundColor = ConsoleColor.Green);
                Console.Read();
            }
        }

        public static void ListarConta(List<Conta> c)
        {
            Console.Clear();
            Console.WriteLine("LISTA DE CONTAS DO BANCO:");
            for (int i = 0; i < c.Count; i++)
            {
                Console.WriteLine($"{c[i].Numero} - {c[i].Nome}");
            }
        }

        public static void MostrarSaldo(List<Conta> c)
        {
            int escolha;

            Console.WriteLine("Selecione uma Conta:");
            escolha = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < c.Count; i++)
            {
                if (c[i].Numero == escolha)
                {
                    Console.WriteLine($"O Saldo da Conta Número {c[i].Numero} de {c[i].Nome} é de {c[i].Saldo.ToString("C")}.");
                    Console.Read();
                    break;
                }
            }

        }


        public void RemoverConta()
        {

        }

        public void AtualizarConta()
        {

        }

        public static void SomaValorContas(List<Conta> c)
        {
            Console.Clear();
            Console.WriteLine($"O Valor total das contas do banco é de: {c.Sum(c => c.Saldo).ToString("C")}");
            Console.Read();
        }

    }
}
