using System;
using System.Collections.Generic;
using System.Text;

// Interface das operações básicas de um conta.

namespace Banco
{
    public interface IConta
    {
        public void Sacar(List<Conta> c) { }
        public static void Depositar(List<Conta> c) { }
        public void Transferir();
    }
}
