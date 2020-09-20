using System.Collections.Generic;
using Caelum.Banco.Interfaces;

namespace Caelum.Banco.Db
{
    public static class BancoDeDados
    {
        public static List<IConta> Contas = new List<IConta>();
        public static List<Cliente> Clientes = new List<Cliente>();

        public static void ProximaConta(ref uint prox)
        {
            if (Contas.Count == 0)
            {
                prox = (uint) 1;
            }

            for (int i = 0; i < Contas.Count; i++)
            {
                if (i + 1 != Contas[i].Numero)
                {
                   prox = (uint) i + 1;
                }
            }

            prox = (uint) Contas.Count + 1;
        }
    }
}