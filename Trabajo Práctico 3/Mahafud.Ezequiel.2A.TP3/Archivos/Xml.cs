using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa la información en un archivo XML.
        /// </summary>
        /// <param name="archivo">Nombre del archivo donde se serializará la información.</param>
        /// <param name="datos">Información a serializar.</param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos) {
            try {
                TextWriter escritura = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo);
                XmlSerializer serializador = new XmlSerializer(typeof(T));

                serializador.Serialize(escritura, datos);
                escritura.Close();
            }
            catch (Exception e) {
                throw new ArchivosException(e);
            }

            return true;
        }

        /// <summary>
        /// Deserializa la información de un archivo XML.
        /// </summary>
        /// <param name="archivo">Nombre del archivo de donde se deserealizará la información.</param>
        /// <param name="datos">Variable de salida donde se guardará la información deserializada.</param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos) {
            try {
                TextReader lectura = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo);
                XmlSerializer serializador = new XmlSerializer(typeof(T));

                datos = (T)serializador.Deserialize(lectura);
                lectura.Close();
            }
            catch (Exception e) {
                throw new ArchivosException(e);
            }

            return true;
        }
    }
}
