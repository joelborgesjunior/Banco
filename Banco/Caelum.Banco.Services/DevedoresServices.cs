using System;
using System.Collections.Generic;

using Caelum.Banco.Entities;

namespace Caelum.Banco.Services
{
    public class DevedoresServices
    {
        HashSet<String> nomes = new HashSet<String>();

        public HashSet<String> GeraListaDevedor(List<Conta> c)
        {
            for (int i = 0; i < c.Count; i++)
            {
                if (c[i].Saldo < 0)
                {
                    nomes.Add(c[i].Nome);
                }
            }
            return nomes;
        }

        public bool VerificarSeDevedor(string nome)
        {
            if (nomes.Contains(nome))
            {
                Console.WriteLine("É Devedor, não pode criar conta");
                Console.Read();
                return false;
            } else
            {
                return true;
            }
        }


    }
}
