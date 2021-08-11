using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Busca
{
    public class GeradorDeDevedores
    {
        public HashSet<string> GerarListaNomes()
        {
            HashSet<string> nomes = new HashSet<string>();

            for (int i = 0; i < 30000; i++)
            {
                nomes.Add("Devedor " + i);
            }

            return nomes;
        }
    }
}
