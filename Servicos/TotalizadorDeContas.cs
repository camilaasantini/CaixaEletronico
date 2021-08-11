using System;
using System.Collections.Generic;
using CaixaEletronico.Entidades.Contas;

namespace CaixaEletronico
{
    class TotalizadorDeContas
    {
        public double SaldoTotal { get; private set; }

        public void Adiciona(Conta conta)
        {
            SaldoTotal += conta.Saldo;
        }
    }
}
