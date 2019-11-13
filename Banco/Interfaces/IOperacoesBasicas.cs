using System.Collections.Generic;

// Interface das operações básicas de uma conta.

namespace Banco.Interfaces
{
    public interface IOperacoesBasicas
    {
        public void Sacar(List<Conta> contas);
        public void Depositar(List<Conta> contas);
        public void Transferir(List<Conta> contas);
    }
}
