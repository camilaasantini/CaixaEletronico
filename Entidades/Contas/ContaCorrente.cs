using CaixaEletronico.Interfaces;
using System;
using CaixaEletronico.Entidades.Contas;

namespace CaixaEletronico.Entidades.Contas
{
    class ContaCorrente : Conta, ITributavel
    {
        public override void Saca(double valor)
        {
            if (valor < 0.0)
            {
                throw new ArgumentException();
            }
            if (valor + 0.10 > Saldo)
            {
                throw new SaldoInsuficienteException();
            }
            else
            {
                Saldo -= valor + 0.05;
            }
        }

        public override void Deposita(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                Saldo += valor - 0.10;
            }
        }

        public double CalculaTributo()
        {
            return Saldo * 0.05;
        }
    }
}
