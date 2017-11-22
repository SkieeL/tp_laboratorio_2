using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda información en un archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre del archivo donde se guardarán los datos.</param>
        /// <param name="datos">Información a guardar.</param>
        /// <returns></returns>
        public bool guardar(string archivo, string datos) {
            try {
                StreamWriter escritura = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo, true, Encoding.UTF8);

                escritura.WriteLine(datos);
                escritura.Close();
            }
            catch (Exception e) {
                throw new ArchivosException(e);
            }

            return true;
        }

        /// <summary>
        /// Lee información de un archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer.</param>
        /// <param name="datos">Variable de salida donde se almacenará la información leída.</param>
        /// <returns></returns>
        public bool leer(string archivo, out string datos) {
            try {
                StreamReader lectura = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo, Encoding.UTF8);

                datos = lectura.ReadToEnd();
                lectura.Close();
            }
            catch (Exception e) {
                throw new ArchivosException(e);
            }

            return true;
        }
    }
}
