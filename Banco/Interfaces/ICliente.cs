namespace Banco.Interfaces
{
    interface ICliente
    {
        public bool MaiorDeIdade(int Idade);
        public double TaxaSaque(Conta conta, double saque);
    }
}
