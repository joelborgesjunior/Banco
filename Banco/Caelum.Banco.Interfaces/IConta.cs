namespace Caelum.Banco.Interfaces
{
    public interface IConta
    {
        uint Numero { get; set; }
        double Saldo { get; set; }
        string Tipo { get; set; }
    }
}