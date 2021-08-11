using CaixaEletronico.Interfaces;

namespace CaixaEletronico
{
    class SeguroDeVida : ITributavel
    {
        const double valor = 42.00;
        public double CalculaTributo()
        {
            return valor;
        }
    }
}
