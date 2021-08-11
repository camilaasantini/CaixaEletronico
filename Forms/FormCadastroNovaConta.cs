using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using CaixaEletronico.Entidades.Contas;
using System.Windows.Forms;
using CaixaEletronico.Busca;
using CaixaEletronico.Usuários;

namespace CaixaEletronico
{
    public partial class FormCadastroNovaConta : Form
    {
        private ICollection<string> devedores;

        private Form1 formPrincipal;
        public FormCadastroNovaConta(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();

            GeradorDeDevedores gerador = new GeradorDeDevedores();
            devedores = gerador.GerarListaNomes();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var titular = txtTitular.Text;
            bool ehDevedor = false;

            for (int i = 0; i < 30000; i++)
            {
                ehDevedor = this.devedores.Contains(titular);
            } 

            if ((txtTitular.Text == "") || ehDevedor)
            {
                MessageBox.Show("Campo titular vazio ou o titular é um devedor!");
            }
            else
            {
                Conta cc = new ContaCorrente();
                cc.Titular = new Cliente(txtTitular.Text);
                this.formPrincipal.AdicionaNovaConta(cc);
            } 
        }
        private void FormCadastroNovaConta_Load(object sender, EventArgs e)
        {
            txtNumero.Text = Convert.ToString(Conta.ProximoNumero());
        }
    }
}
