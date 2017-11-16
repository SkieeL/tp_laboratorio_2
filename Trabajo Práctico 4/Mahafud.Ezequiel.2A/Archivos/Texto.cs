using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _rutaArchivo;

        public Texto(string archivo) {
            this._rutaArchivo = AppDomain.CurrentDomain.BaseDirectory + archivo;
        }

        public bool guardar(string datos) {
            StreamWriter escritor = new StreamWriter(this._rutaArchivo, true, Encoding.UTF8);

            try {
                escritor.WriteLine(datos);
                escritor.Close();
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public bool leer(List<string> datos) {
            StreamReader lector = new StreamReader(this._rutaArchivo, Encoding.UTF8);

            try {
                while (!lector.EndOfStream) {
                    datos.Add(lector.ReadLine());
                }

                lector.Close();
            }
            catch (Exception) {
                return false;
            }

            return true;
        }
    }
}
