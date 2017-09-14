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
        /// <summary>
        /// Constructor por defecto del formulario contenedor de la calculadora.
        /// </summary>
        public frmCalculadora() {
            InitializeComponent();

            this.cmbOperacion.Items.Add("+");
            this.cmbOperacion.Items.Add("-");
            this.cmbOperacion.Items.Add("*");
            this.cmbOperacion.Items.Add("/");

            this.cmbOperacion.SelectedItem = "+";
            this.cmbOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Toma los valores de los campos de texto, los mete en objetos de tipo Numero, opera con ellos y escribe el resultado en el Label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void operar(object sender, EventArgs e) {
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);
            double resultado;

            resultado = Calculadora.operar(numero1, numero2, (string) this.cmbOperacion.SelectedItem);

            this.lblResultado.Text = resultado.ToString();
        }

        /// <summary>
        /// Establece los valores por defecto en el label, en los campos de texto y en el combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void limpiar(object sender, EventArgs e) {
            this.lblResultado.Text = "Ingrese operandos";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperacion.SelectedItem = "+";
        }
    }
}
