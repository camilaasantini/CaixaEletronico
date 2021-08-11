using System;
using System.Collections.Generic;
using System.Text;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Entidades.Contas;

namespace CaixaEletronico.Entidades.Contas
{
    class ContaInvestimento : Conta, ITributavel
    {
        public double CalculaTributo()
        {
            return Saldo * 0.03;
        }

        public override void Deposita(double valor)
        {
            throw new NotImplementedException();
        }

        public override void Saca(double valor)
        {
            throw new NotImplementedException();
        }
    }
}
