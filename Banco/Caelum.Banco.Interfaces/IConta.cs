using Caelum.Banco.Interfaces.Enums;

namespace Caelum.Banco.Interfaces
{
    public interface IConta
    {
        uint Numero { get; set; }
        decimal Saldo { get; set; }
        TipoContaEnums Tipo { get; set; }       
        Cliente Cliente { get; set; }  

        public void SacarDinheiro(decimal valor);
        public void DepositarDinheiro(decimal valor);
    }
}