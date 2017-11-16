using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public delegate void delDescProg(int progreso);
    public delegate void delDescFin(string html);

    public class Descargador
    {
        private string html;
        private Uri direccion;

        public event delDescProg EnProgreso;
        public event delDescFin Finalizado;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            this.EnProgreso(e.ProgressPercentage);
        }

        public void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e) {
            if (e.Error == null && !e.Cancelled) {
                this.html = e.Result;
                this.Finalizado(this.html);
            }
                
        }
    }
}
