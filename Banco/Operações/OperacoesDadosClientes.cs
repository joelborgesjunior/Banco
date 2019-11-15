using Banco.Interfaces;
using System;

// Class com Operações envolvendo dados de cliente

namespace Banco
{
    public class OperacoesDadosClientes : Cliente, ICliente
    {
        public bool MaiorDeIdade(int Idade)
        {
            if (Idade > 17)
                return true;

            throw new Exception();
        }

        // Método que calcula a Taxa por saque .        
        // Corrente é 0.01% e Poupança 0.02%

        public double TaxaSaque(Conta conta, double saque)
        {
            if (conta.GetType() == typeof(TiposDeConta.ContaCorrente))
            {
                return saque * 0.01;
            }
            else if (conta.GetType() == typeof(TiposDeConta.ContaPoupanca))
            {
                return saque * 0.02;
            }

            return 0;
        }
    }
}
