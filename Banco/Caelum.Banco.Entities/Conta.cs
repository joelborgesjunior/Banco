using Caelum.Banco.Services;
using Caelum.Banco.Interfaces;

namespace Caelum.Banco.Entities
{
    public class Conta : IConta, ICliente
    {
        public uint Numero { get; set; }
        public double Saldo { get; set; }
        public string Tipo { get; set; }

        public string Nome {get; set;}
        public string Endereco {get; set;}
        public string Rg {get; set;}
        public string Cpf {get; set;}
        public int Idade {get; set;}

        public Conta(uint numero, double saldo, string tipo, string nome, 
                                string endereco, string rg, string cpf, int idade)
        {                       
            Nome = nome;
            Endereco = endereco;
            Rg = rg;
            Cpf = cpf;
            Idade = idade;
            Numero = numero;
            Saldo = saldo;
            Tipo = tipo;
        }

        public Conta(){}
    }
}