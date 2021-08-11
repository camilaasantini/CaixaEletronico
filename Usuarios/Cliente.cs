using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Usuários
{
    public class Cliente
    {
        public string Nome { get; set; }

        public Cliente(string nome)
        {
            Nome = nome;
        }
    }
}
