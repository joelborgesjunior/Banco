﻿using Banco.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

// Operações Secundárias (Listagem de Contas, Valor somado das contas, Numero de Contas, Mostrar Saldo, Total de taxas pagas) 

namespace Banco.Operações
{
    public class OperacoesSecundarias : IOperacoesSecundarias
    {
        public void ListarConta(List<Conta> c)
        {
            Console.Clear();
            if (c.Count == 0)
            {
                Console.WriteLine("NÃO EXISTE CONTAS NESTE BANCO.", 
                Console.ForegroundColor = ConsoleColor.Red); 
                Console.Read();
            } else 
            {
                Console.WriteLine("LISTA DE CONTAS DO BANCO:");
                for (int i = 0; i < c.Count; i++)
                {
                    Console.WriteLine($"{c[i].Numero} - {c[i].Nome}");
                }
            }
        }

        public void SomaValorContas(List<Conta> c)
        {
            Console.Clear();
            Console.WriteLine($"O Valor total das contas do banco é de: {c.Sum(c => c.Saldo).ToString("C")}");
            Console.Read();
        }

        public void TotalDeContas(List<Conta> c)
        {
            Console.Clear();
            Console.WriteLine($"O Número total de contas do banco é de {c.Count} contas.");
            Console.WriteLine($"Sendo: \n {c.Count(c => c.GetType() == typeof(TiposDeConta.ContaCorrente))}" +
            $" Contas Corrente, \n {c.Count(c => c.GetType() == typeof(TiposDeConta.ContaPoupanca))} Contas Poupança");
            Console.Read();
        }

        public void MostrarSaldo(List<Conta> c)
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
                        Console.WriteLine($"O Saldo da Conta Número {c[i].Numero} de {c[i].Nome} é de {c[i].Saldo.ToString("C")}.");
                        Console.Read();
                        break;
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

        public void SomarImpostos(List<Conta> c){
           Console.Clear();
           Console.WriteLine($"Valor total de taxas: {c.Sum(x => x.GastoTaxas).ToString("C")}");
           Console.Read();       
        }
    }
}
