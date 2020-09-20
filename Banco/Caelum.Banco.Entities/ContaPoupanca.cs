using Caelum.Banco.Interfaces;
using Caelum.Banco.Interfaces.Enums;

namespace Caelum.Banco.Entities
{
    public class ContaPoupanca : IConta, ITributavel
    {
        public uint Numero { get; set; }
        public decimal Saldo { get; set; }
        public TipoContaEnums Tipo { get; set; }
        public Cliente Cliente { get; set; }

        public ContaPoupanca(TipoContaEnums tipo, Cliente cliente)
        {           
            Tipo = tipo;
            Cliente = cliente;
        }

        public void SacarDinheiro(decimal valor)
        {
            Saldo -= (valor + 0.10m);
        }

        public void DepositarDinheiro(decimal valor)
        {
             Saldo += (valor - 0.10m);
        }

        public decimal CalculaTributo()
        {
            return this.Saldo * 0.02m;
        }
    }
}
