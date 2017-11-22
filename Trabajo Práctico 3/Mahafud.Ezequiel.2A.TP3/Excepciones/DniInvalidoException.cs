using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception {
        private static string mensajeBase = "La nacionalidad no se coincide con el número de DNI";

        public DniInvalidoException() : base() { }

        public DniInvalidoException(Exception e) : base(mensajeBase, e) { }

        public DniInvalidoException(string message) : base(message) { }

        public DniInvalidoException(string message, Exception e) : base(message, e) { }
    }
}
