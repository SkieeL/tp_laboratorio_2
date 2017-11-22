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
        public bool guardar(string archivo, string datos) {
            StreamWriter escritura = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo, false, Encoding.UTF8);

            escritura.WriteLine(datos);
            escritura.Close();

            return true;
        }

        public bool leer(string archivo, out string datos) {
            StreamReader lectura = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo, Encoding.UTF8);

            datos = lectura.ReadToEnd();
            lectura.Close();

            return true;
        }
    }
}
