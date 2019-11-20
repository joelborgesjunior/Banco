using System.Collections.Generic;

// Interface das operações básicas de uma conta.

namespace Banco.Interfaces
{
    public interface IOperacoesBasicas
    {
        public static void CriarConta(List<Conta> Conta) {}
        public static void RemoverConta(List<Conta> Conta) {}
        public static void AtualizarConta(List<Conta> Conta) {}
    }
}
