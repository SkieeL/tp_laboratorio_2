using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public enum ENacionalidad {
            Argentino,
            Extranjero
        }

        public string Apellido {
            get { return this._apellido; }
            set { this._apellido = this.ValidarNombreApellido(value); }
        }

        public int DNI {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this._nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre {
            get { return this._nombre; }
            set { this._nombre = this.ValidarNombreApellido(value); }
        }

        public string StringToDNI {
            set { this._dni = this.ValidarDni(this._nacionalidad, value); }
        }

        public Persona() : this("", "", 1, ENacionalidad.Argentino) { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this(nombre, apellido, 1, nacionalidad) { }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad) {
            this.StringToDNI = dni;
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato) {
            try {
                if (nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato > 89999999))
                    throw new DniInvalidoException("La nacionalidad no se coincide con el número de DNI");
            }
            catch (DniInvalidoException e) {
                Console.WriteLine(e.Message);
            }

            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato) {
            int dni;

            try {
                if (!int.TryParse(dato, out dni))
                    throw new DniInvalidoException("El DNI únicamente debe contener números");
                else {
                    if (nacionalidad == ENacionalidad.Argentino && (dni < 1 || dni > 89999999))
                        throw new DniInvalidoException("La nacionalidad no se coincide con el número de DNI");
                }
            }
            catch (DniInvalidoException e) {
                Console.WriteLine(e.Message);
            }

            dni = int.Parse(dato);

            return dni;
        }

        private string ValidarNombreApellido(string dato) {
            Regex rgx = new Regex(@"[\W0-9]");

            if (rgx.IsMatch(dato))
                return "";

            return dato;
        }

        public override string ToString() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("NOMBRE COMPLETO: {1}, {0}\n", this._nombre, this._apellido);
            retorno.AppendFormat("NACIONALIDAD: {0}\n", (this._nacionalidad).ToString());
            //retorno.AppendFormat("DNI: {0}\n", this._dni);

            return retorno.ToString();
        }
    }
}
