using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public EClases Clase {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        /// <summary>
        /// Constructor por defecto, inicializa la lista de alumnos.
        /// </summary>
        private Jornada() {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor parametrizado, primera sobrecarga.
        /// </summary>
        /// <param name="clase">Clase de la jornada.</param>
        /// <param name="instructor">Profesor de la jornada.</param>
        public Jornada(EClases clase, Profesor instructor) : this() {
            this._clase = clase;
            this._instructor = instructor;
        }

        /// <summary>
        /// Agrega un Alumno a una Jornada.
        /// </summary>
        /// <param name="j">Jornada donde se agrega el alumno.</param>
        /// <param name="a">Alumno a ser agregado a la jornada.</param>
        /// <returns>Jornada con el alumno agregado.</returns>
        public static Jornada operator +(Jornada j, Alumno a) {
            Jornada auxJornada;
            auxJornada = j;

            if (auxJornada != a) {
                auxJornada._alumnos.Add(a);
            }

            return auxJornada;
        }

        /// <summary>
        /// Verifica si un alumno se encuentra en una jornada.
        /// </summary>
        /// <param name="j">Jornada a verificar.</param>
        /// <param name="a">Alumno a buscar.</param>
        /// <returns>En caso de que el alumno se encuentre en la jornada retorna true, caso contrario false.</returns>
        public static bool operator ==(Jornada j, Alumno a) {
            for (int i = 0; i < j._alumnos.Count; i++) {
                if (j._alumnos[i] == a) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica si un alumno no se encuentra en una jornada.
        /// </summary>
        /// <param name="j">Jornada a verificar.</param>
        /// <param name="a">Alumno a buscar.</param>
        /// <returns>En caso de que el alumno no se encuentre en la jornada retorna true, caso contrario false.</returns>
        public static bool operator !=(Jornada j, Alumno a) {
            if (!(j == a))
                return true;

            return false;
        }

        /// <summary>
        /// Sobreescribe el método ToString mostrando todos los datos de la jornada.
        /// </summary>
        /// <returns>Datos de la jornada y lista de alumnos en formato string.</returns>
        public override string ToString() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("CLASE DE {0} POR {1}\n", this._clase, this._instructor.ToString());
            retorno.AppendLine("ALUMNOS:");

            for (int i = 0; i < this._alumnos.Count; i++) {
                retorno.AppendLine(this._alumnos[i].ToString());
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Guarda una jornada en un documento de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guardar.</param>
        /// <returns>Devuelve true si pudo guardar la jornada exitosamente.</returns>
        public static bool Guardar(Jornada jornada) {
            Texto archivo = new Texto();

            archivo.guardar("Jornada.txt", jornada.ToString());

            return true;
        }

        /// <summary>
        /// Lee una jornada de un archivo de texto.
        /// </summary>
        /// <returns>Jornada leída del archivo en formato string.</returns>
        public static string Leer() {
            string retorno;
            Texto archivo = new Texto();

            archivo.leer("Jornada.txt", out retorno);

            return retorno;
        }
    }
}
