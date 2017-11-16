using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";
        private List<string> _listaURLs;

        public frmHistorial()
        {
            InitializeComponent();
            this._listaURLs = new List<string>();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

            archivos.leer(this._listaURLs);

            for (int i = 0; i < this._listaURLs.Count; i++) {
                this.lstHistorial.Items.Add(this._listaURLs[i]);
            }
        }
    }
}
