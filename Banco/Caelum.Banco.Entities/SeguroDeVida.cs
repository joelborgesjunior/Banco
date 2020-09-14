using Caelum.Banco.Interfaces;

namespace Caelum.Banco.Entities
{
    class SeguroDeVida: ITributavel
    {
        public double CalculaTributo()
        {
            return 42;
        }
    }
}
