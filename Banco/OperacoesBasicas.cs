using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    abstract class OperacoesBasicas : IConta
    {
        public static void Depositar(List<Conta> c)
        {
            int escolha;
            double valor;

            Console.WriteLine("Selecione uma Conta:");
            escolha = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o Valor a ser depositado:");
            valor = Convert.ToDouble(Console.ReadLine());

            for (int i = 0; i < c.Count; i++)
            {
                if( c[i].Numero == escolha)
                {
                    c[i].Saldo += valor;
                    Console.WriteLine($"Depósito de {valor.ToString("C")} feito com sucesso.", 
                        Console.ForegroundColor = ConsoleColor.Green);
                    break;
                }
            }
        }

        public void Sacar()
        {

        }

        public void Transferir()
        {

        }
    }
}
