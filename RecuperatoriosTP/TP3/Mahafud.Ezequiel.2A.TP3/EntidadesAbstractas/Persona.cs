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

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona() : this("", "", 1, ENacionalidad.Argentino) { }

        /// <summary>
        /// Primer sobrecarga, constructor parametrizado.
        /// </summary>
        /// <param name="nombre">Nombre para la persona.</param>
        /// <param name="apellido">Apellido para la persona.</param>
        /// <param name="nacionalidad">Nacionalidad para la persona.</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this(nombre, apellido, 1, nacionalidad) { }

        /// <summary>
        /// Segunda sobrecarga, constructor parametrizado.
        /// </summary>
        /// <param name="nombre">Nombre para la persona.</param>
        /// <param name="apellido">Apellido para la persona.</param>
        /// <param name="dni">DNI para la persona.</param>
        /// <param name="nacionalidad">Nacionalidad para la persona.</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.DNI = dni;
        }

        /// <summary>
        /// Tercer sobrecarga, constructor parametrizado.
        /// </summary>
        /// <param name="nombre">Nombre para la persona.</param>
        /// <param name="apellido">Apellido para la persona.</param>
        /// <param name="dni">DNI para la persona.</param>
        /// <param name="nacionalidad">Nacionalidad para la persona.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad) {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Valida si un DNI en formato int cumple con el rango correspondiente de un ciudadano argentino.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad.</param>
        /// <param name="dato">DNI a validar.</param>
        /// <returns>DNI validado.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato) {
            try {
                if (dato < 1)
                    throw new DniInvalidoException("El DNI no puede ser menor a 1");
                else if (nacionalidad == ENacionalidad.Argentino && dato > 89999999)
                    throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el número de DNI");
            }
            catch (DniInvalidoException e) {
                Console.WriteLine(e.Message);
            }

            return dato;
        }

        /// <summary>
        /// Valida si un DNI en formato string cumple con el rango correspondiente de un ciudadano argentino.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad.</param>
        /// <param name="dato">Dato a validar.</param>
        /// <returns>DNI validado.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato) {
            int dni = 0;

            try {
                if (!(int.TryParse(dato, out dni)))
                    throw new DniInvalidoException("El DNI únicamente debe contener números");
                else
                    dni = this.ValidarDni(nacionalidad, dni);
            }
            catch (DniInvalidoException e) {
                Console.WriteLine(e.Message);
            }

            return dni;
        }

        /// <summary>
        /// Valida que un string posea únicamente letras.
        /// </summary>
        /// <param name="dato">String a validar.</param>
        /// <returns>String validado, en caso de que no contenga únicamente letras devuelve una cadena vacía.</returns>
        private string ValidarNombreApellido(string dato) {
            for (int i = 0; i < dato.Length; i++) {
                if (!char.IsLetter(dato[i]))
                    return "";
            }

            return dato;
        }

        /// <summary>
        /// Devuelve todos los datos de la persona.
        /// </summary>
        /// <returns>Datos de la persona en formato string.</returns>
        public override string ToString() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("NOMBRE COMPLETO: {1}, {0}\n", this._nombre, this._apellido);
            retorno.AppendFormat("NACIONALIDAD: {0}\n", (this._nacionalidad).ToString());
            //retorno.AppendFormat("DNI: {0}\n", this._dni);

            return retorno.ToString();
        }
    }
}
