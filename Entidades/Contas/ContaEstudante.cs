using System;
using System.Collections.Generic;
using System.Text;
using CaixaEletronico.Entidades.Contas;

namespace CaixaEletronico.Entidades.Contas
{
    class ContaEstudante : Conta
    {
        public override void Saca(double valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
            }
            if (valor + 0.10 > Saldo)
            {
                throw new SaldoInsuficienteException();
            }
        }

        public override void Deposita(double valor)
        {
            Saldo += valor + (valor * 0.10);
        }
    }
}
