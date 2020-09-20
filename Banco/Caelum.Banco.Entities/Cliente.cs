using System.Collections.Generic;
using Caelum.Banco.Interfaces;

namespace Caelum.Banco.Interfaces
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public List<IConta> Contas { get; set;}

        public Cliente() {} 
    }


}
