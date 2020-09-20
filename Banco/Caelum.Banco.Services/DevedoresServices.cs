using System;
using System.Collections.Generic;

using Caelum.Banco.Db;
using Caelum.Banco.Interfaces;

namespace Caelum.Banco.Services
{
    public class DevedoresServices
    {
        HashSet<Cliente> ListaDevedores = new HashSet<Cliente>();

        public HashSet<Cliente> GeraListaDevedor()
        {
            for (int i = 0; i < BancoDeDados.Contas.Count; i++)
            {
                if (BancoDeDados.Contas[i].Saldo < 0)
                {
                    ListaDevedores.Add(BancoDeDados.Clientes[i]);
                }
            }
            return ListaDevedores;
        }

        public bool VerificarSeDevedor(string nome)
        {
            foreach (var item in ListaDevedores)
            {
                if (item.Nome.Contains(nome))
                {
                    Console.WriteLine("É Devedor, não pode criar conta");
                    Console.Read();
                    return false;
                } 
            }
            return true;
        }


    }
}
