using System;

namespace Caelum.Banco.Services
{
    public class ClienteServices
    {
         public static bool MaiorDeIdade(int idade)
        {
            if(idade > 16)
            {
                return true;
            }
            
            throw new Exception();
        }
    }
}