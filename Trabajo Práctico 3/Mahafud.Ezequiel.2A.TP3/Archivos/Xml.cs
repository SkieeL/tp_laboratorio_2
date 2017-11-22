using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool guardar(string archivo, T datos) {
            TextWriter escritura = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo);
            XmlSerializer serializador = new XmlSerializer(typeof(T));

            serializador.Serialize(escritura, datos);
            escritura.Close();

            return true;
        }

        public bool leer(string archivo, out T datos) {
            TextReader lectura = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo);
            XmlSerializer serializador = new XmlSerializer(typeof(T));

            datos = (T)serializador.Deserialize(lectura);
            lectura.Close();

            return true;
        }
    }
}
