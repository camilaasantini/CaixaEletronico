using System;
using System.Collections.Generic;
using System.Text;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Usuários;

namespace CaixaEletronico.Entidades.Contas
{
    public abstract class Conta : ITributavel
    {
        public Cliente Titular { get; set; }
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public decimal Valor { get; set; }

        private static int numeroDeContas;

        public static int ProximoNumero()
        {
            return numeroDeContas + 1;
        }

        public Conta()
        {
            Conta.numeroDeContas++;
            this.Numero = Conta.numeroDeContas;
        }

        public double CalculaTributo()
        {
            return 0.0;
        }

        public abstract void Deposita(double valor);

        public abstract void Saca(double valor);

        public override string ToString()
        {
            return "Titular: " + this.Titular.Nome;
        }
    }
}
