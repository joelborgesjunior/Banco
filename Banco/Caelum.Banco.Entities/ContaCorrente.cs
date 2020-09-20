using Caelum.Banco.Interfaces;
using Caelum.Banco.Interfaces.Enums;

namespace Caelum.Banco.Entities
{
    public class ContaCorrente : IConta
    {        
        public uint Numero { get; set; }
        public decimal Saldo { get; set; }
        public TipoContaEnums Tipo { get; set; }        
        public Cliente Cliente { get; set;}

        public ContaCorrente(TipoContaEnums tipo, Cliente cliente)
        {           
            Tipo = tipo;
            Cliente = cliente;
        }

        public void SacarDinheiro(decimal valor)
        {
            Saldo -= (valor + 0.05m);
        }

        public void DepositarDinheiro(decimal valor)
        {
             Saldo += (valor - 0.10m);
        }

    }
}