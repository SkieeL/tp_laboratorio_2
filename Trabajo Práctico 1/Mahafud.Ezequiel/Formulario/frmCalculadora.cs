using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace Formulario
{
    public partial class frmCalculadora : Form
    {

        public frmCalculadora() {
            InitializeComponent();

            this.cmbOperacion.Items.Add("+");
            this.cmbOperacion.Items.Add("-");
            this.cmbOperacion.Items.Add("*");
            this.cmbOperacion.Items.Add("/");

            this.cmbOperacion.SelectedItem = "+";
            this.cmbOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void operar(object sender, EventArgs e) {
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);
            double resultado;

            resultado = Calculadora.operar(numero1, numero2, (string) this.cmbOperacion.SelectedItem);

            this.lblResultado.Text = resultado.ToString();
        }

        private void limpiar(object sender, EventArgs e) {
            this.lblResultado.Text = "Ingrese operandos";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperacion.SelectedItem = "+";
        }
    }
}
