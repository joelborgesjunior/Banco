using Caelum.Banco.Services;
using Caelum.Banco.Interfaces;
using Caelum.Banco.Entities;

namespace Caelum.Banco.Entities
{
    public class ContaInvestimento : Conta, ITributavel
    {
        public double CalculaTributo()
        {
            return this.Saldo * 0.02;
        }
    }
}
