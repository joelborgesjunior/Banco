using System.Collections.Generic;

using Caelum.Banco.Services;
using Caelum.Banco.Interfaces;
using Caelum.Banco.Entities;

namespace Caelum.Banco.Entities
{
    public class ContaCorrente : ContaServices
   {
        public override void SacarDinheiro(int escolha, List<Conta> c, double valor)
        {
            base.SacarDinheiro(escolha, c, valor + 0.05);
        }

        public override void DepositarDinheiro(int escolha, List<Conta> c, double valor)
        {
            base.DepositarDinheiro(escolha, c, valor - 0.10);
        }
    }
}
