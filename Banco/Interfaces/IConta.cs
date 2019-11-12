using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    public interface IConta
    {
        public void Sacar();
        public static void Depositar(List<Conta> c) { }
        public void Transferir();
    }
}
