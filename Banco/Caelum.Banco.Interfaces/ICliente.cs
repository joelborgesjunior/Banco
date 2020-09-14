namespace Caelum.Banco.Interfaces
{
    public interface ICliente
    {
        string Nome { get; set; }
        string Endereco { get; set; }
        string Rg { get; set; }
        string Cpf { get; set; }
        int Idade { get; set; }
    }
}
