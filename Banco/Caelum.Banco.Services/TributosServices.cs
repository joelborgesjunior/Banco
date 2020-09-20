using Caelum.Banco.Interfaces;

namespace Caelum.Banco.Services
{
    public class TributosServices
    {
        public decimal Total { get; private set; }

        public void Acumula(ITributavel it)
        {
            this.Total += it.CalculaTributo();
        }
    }
}
