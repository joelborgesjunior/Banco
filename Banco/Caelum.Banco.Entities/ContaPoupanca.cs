using System.Collections.Generic;

using Caelum.Banco.Services;
using Caelum.Banco.Interfaces;
using Caelum.Banco.Entities;

namespace Caelum.Banco.Entities
{
    public class ContaPoupanca : ContaServices, ITributavel
    {
        public override void SacarDinheiro(int escolha, List<Conta> c, double valor)
        {
            base.SacarDinheiro(escolha, c, valor + 0.10);
        }

        public override void DepositarDinheiro(int escolha, List<Conta> c, double valor)
        {
            base.DepositarDinheiro(escolha, c, valor - 0.10);
        }
       
        public double CalculaTributo()
        {
            return this.Saldo * 0.02;
        }
    }
}
