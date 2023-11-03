using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {
        double numero1;
        string ultimoOp;
        bool validarOp = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbTela.Clear();
            txbAux.Clear();
            validarOp = false;
        }
        private void Numero_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando o evento:
            var botao = (Button)sender;
            txbTela.Text += botao.Text;
        }
        private void Operador_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando o evento:
            var botao = (Button)sender;
            if (validarOp == false && txbTela.Text != "")
            {
                numero1 = double.Parse(txbTela.Text);
                txbTela.Clear();
                txbAux.Text = numero1.ToString() + botao.Text;
                ultimoOp = botao.Text;
                validarOp = true;
            }
            else
            {
                if(txbAux.Text != "" && txbTela.Text != "")
                {
                    btnIgual.PerformClick();
                    txbAux.Text = txbTela.Text + botao.Text;
                    numero1 = double.Parse(txbTela.Text);
                    ultimoOp = botao.Text;
                    txbTela.Text = "";
                    validarOp = false;
                }
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            validarOp = false;
            switch (ultimoOp)
            {
                case "+":
                    txbAux.Clear();
                    txbTela.Text = (numero1 + double.Parse(txbTela.Text)).ToString();
                    break;
                case"-":
                    txbAux.Clear();
                    txbTela.Text = (numero1 - double.Parse(txbTela.Text)).ToString();
                    break;
                case "X":
                    txbAux.Clear();
                    txbTela.Text = (numero1 * double.Parse(txbTela.Text)).ToString();
                    break;
                case "÷":
                    txbAux.Clear();
                    txbTela.Text = (numero1 / double.Parse(txbTela.Text)).ToString();
                    break;
            }
        }
    }
}
