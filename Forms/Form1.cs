using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaixaEletronico.Interfaces;
using CaixaEletronico.Entidades.Contas;
using CaixaEletronico.Usuários;
using CaixaEletronico.Forms;

namespace CaixaEletronico
{
    public partial class Form1 : Form
    {
        private List<Conta> contas;

        private Dictionary<string, Conta> dicionario;

        public Form1()
        {
            InitializeComponent();
        }
        public void AdicionaNovaConta(Conta conta)
        {
            this.contas.Add(conta);
            comboContas.Items.Add(conta);
            comboDestinoTransferencia.Items.Add(conta);
            this.dicionario.Add(conta.Titular.Nome, conta);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dicionario = new Dictionary<string, Conta>();

            this.contas = new List<Conta>();
            Conta c1 = new ContaPoupanca();
            c1.Titular = new Cliente("Camila");
            c1.Numero = 1;
            c1.Saldo = 1050;
            AdicionaNovaConta(c1);
            Conta.ProximoNumero();

            Conta c2 = new ContaEstudante();
            c2.Titular = new Cliente("Amanda");
            c2.Numero = 2;
            c2.Saldo = 6600;
            AdicionaNovaConta(c2);
            Conta.ProximoNumero();

            Conta c3 = new ContaCorrente();
            c3.Titular = new Cliente("Renan");
            c3.Numero = 3;
            c3.Saldo = 12000;
            AdicionaNovaConta(c3);
            Conta.ProximoNumero();

        }

        public bool validarCampos()
        {
            bool retornar;
            if (txtValor.Text == "" || comboContas.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Favor preencher os campos 'Escolha a conta' e 'Valor'!");
                retornar = false;
            }
            else
            {
                retornar = true;
            }
            return retornar;
        }
        private void btnDepositar_Click(object sender, EventArgs e)
        {
            Conta conta = (Conta)comboContas.SelectedItem;
            if (validarCampos())
            {
                double valor = double.Parse(txtValor.Text);
                try
                {
                    conta.Deposita(valor);
                    txtSaldo.Text = conta.Saldo.ToString();
                    MessageBox.Show("Depósito realizado!");
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Argumento inválido!");
                }
            }
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            Conta conta = (Conta)comboContas.SelectedItem;
            if (validarCampos())
            {
                double valor = double.Parse(txtValor.Text);
                try
                {
                    conta.Saca(valor);
                    txtSaldo.Text = conta.Saldo.ToString();
                    MessageBox.Show("Dinheiro liberado!");
                }
                catch (SaldoInsuficienteException)
                {
                    MessageBox.Show("Saldo insuficiente!");
                }
               catch (ArgumentException)
                {
                    MessageBox.Show("Não é possível sacar um valor negativo!");
                }
            }
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            Conta selecionada = contas[indice];

            txtTitular.Text = selecionada.Titular.Nome;
            txtNumero.Text = selecionada.Numero.ToString();
            txtSaldo.Text = selecionada.Saldo.ToString();
        }

        private void botaoTransferir_Click(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            int indice2 = comboDestinoTransferencia.SelectedIndex;
            double valor = double.Parse(txtValor.Text);

            if (indice != indice2)
            {
                contas[indice].Saca(valor);
                contas[indice2].Deposita(valor);
                txtSaldo.Text = contas[indice].Saldo.ToString();
            }
            else
            {
                MessageBox.Show("Escolha uma conta diferente da sua para realizar a transferência!");
            }
        }

        private void comboDestinoTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboDestinoTransferencia.SelectedIndex;
            Conta selecionada = contas[indice];
        }

        private void btnNovaConta_Click(object sender, EventArgs e)
        {
            FormCadastroNovaConta frmCadastro = new FormCadastroNovaConta(this);
            frmCadastro.ShowDialog();
        }

        private void btnCalcularTributos_Click(object sender, EventArgs e)
        {
            ContaCorrente conta = new ContaCorrente();
            conta.Deposita(200.0);

            MessageBox.Show("Imposto da Conta Corrente: " + conta.CalculaTributo());
            ITributavel t = conta;

            MessageBox.Show("Imposto da Conta pela Interface: " + t.CalculaTributo());

            SeguroDeVida sv = new SeguroDeVida();
            MessageBox.Show("Imposto do Seguro de Vida: " + sv.CalculaTributo());

            t = sv;
            MessageBox.Show("Imposto do Seguro de Vida pela Interface: " + t.CalculaTributo());

            TotalizadorDeTributos totalizador = new TotalizadorDeTributos();
            totalizador.Adiciona(conta);
            for (int i = 0; i < contas.Count; i++)
            {
                if (contas[i] is ContaCorrente)
                {
                    totalizador.Adiciona(contas[i]);
                }
            }
            MessageBox.Show("Total Tributos Contas Correntes: " + totalizador.Total);

            totalizador.Adiciona(sv);
            MessageBox.Show("Total Tributos Contas Correntes + Seguro de Vida: " + totalizador.Total);

            
        }

        private void botaoRelatorio_Click(object sender, EventArgs e)
        {
            FormRelatorios form = new FormRelatorios(this.contas);
            form.ShowDialog();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeTitular = txtBuscaTitular.Text;
                Conta conta = dicionario[nomeTitular];
                comboContas.SelectedItem = conta;
            }
            catch (Exception)
            {
                MessageBox.Show("Nome não encontrado!");

            }
        }
    }
}
