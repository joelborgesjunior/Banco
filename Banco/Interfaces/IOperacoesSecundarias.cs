using System.Collections.Generic;

// Interface das operações secundarias de uma conta.

namespace Banco.Interfaces
{
    public interface IOperacoesSecundarias
    {
        public void ListarConta(List<Conta> contas);
        public void SomaValorContas(List<Conta> contas);
        public void TotalDeContas(List<Conta> contas);
        public void MostrarSaldo(List<Conta> contas);
    }
}