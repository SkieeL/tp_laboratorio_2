using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;

        public enum EClases {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        public List<Alumno> Alumnos {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public List<Profesor> Instructores {
            get { return this._profesores; }
            set { this._profesores = value; }
        }

        public List<Jornada> Jornadas {
            get { return this._jornada; }
            set { this._jornada = value; }
        }

        public Jornada this[int indice] {
            get {
                if (indice >= this._jornada.Count || indice < 0)
                    return null;
                else
                    return this._jornada[indice];
            }
            set {
                if (indice >= 0 && indice < this._jornada.Count)
                    this._jornada[indice] = value;
                else
                    Console.WriteLine("No se puede asignar un valor a este elemento!");
            }
        }

        /// <summary>
        /// Constructor por defecto, inicializa las listas de alumnos, jornadas y profesores.
        /// </summary>
        public Universidad() {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
        }

        /// <summary>
        /// Devuelve todos los datos de la universidad.
        /// </summary>
        /// <param name="gim">Universidad en cuestión.</param>
        /// <returns>Retorna todos los datos de la universidad en formato string.</returns>
        private static string MostrarDatos(Universidad gim) {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("JORNADA:");

            for (int i = 0; i < gim._jornada.Count; i++) {
                retorno.AppendLine(gim._jornada[i].ToString());
                retorno.AppendLine("<------------------------------------------------>");
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Sobreescribe el método ToString mostrando todos los datos de la universidad.
        /// </summary>
        /// <returns>Retorna todos los datos de la universidad en formato string.</returns>
        public override string ToString() {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Verifica si un alumno pertenece a una universidad.
        /// </summary>
        /// <param name="g">Universidad a verificar.</param>
        /// <param name="a">Alumno a buscar.</param>
        /// <returns>Retorna true si el alumno pertenece a la universidad, caso contrario devuelve false.</returns>
        public static bool operator ==(Universidad g, Alumno a) {
            for (int i = 0; i < g._alumnos.Count; i++) {
                if (g._alumnos[i] == a)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica si un alumno no pertenece a una universidad.
        /// </summary>
        /// <param name="g">Universidad a verificar.</param>
        /// <param name="a">Alumno a buscar.</param>
        /// <returns>Retorna true si el alumno no pertenece a la universidad, caso contrario devuelve false.</returns>
        public static bool operator !=(Universidad g, Alumno a) {
            if (!(g == a))
                return true;

            return false;
        }

        /// <summary>
        /// Verifica si un profesor pertenece a una universidad.
        /// </summary>
        /// <param name="g">Universidad a verificar.</param>
        /// <param name="a">Profesor a buscar.</param>
        /// <returns>Retorna true si el profesor pertenece a la universidad, caso contrario devuelve false.</returns>
        public static bool operator ==(Universidad g, Profesor i) {
            for (int j = 0; j < g._profesores.Count; j++) {
                if (g._profesores[j] == i)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Verifica si un profesor no pertenece a una universidad.
        /// </summary>
        /// <param name="g">Universidad a verificar.</param>
        /// <param name="a">Profesor a buscar.</param>
        /// <returns>Retorna true si el profesor no pertenece a la universidad, caso contrario devuelve false.</returns>
        public static bool operator !=(Universidad g, Profesor i) {
            if (!(g == i))
                return true;

            return false;
        }

        /// <summary>
        /// Verifica si hay un profesor en una universidad que pueda dar una clase.
        /// </summary>
        /// <param name="g">Universidad a revisar.</param>
        /// <param name="clase">Clase en cuestión.</param>
        /// <returns>Profesor que puede impartir la clase.</returns>
        public static Profesor operator ==(Universidad g, EClases clase) {
            for (int i = 0; i < g._profesores.Count; i++) {
                if (g._profesores[i] == clase)
                    return g._profesores[i];
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Verifica si hay un profesor en una universidad que no pueda dar una clase.
        /// </summary>
        /// <param name="g">Universidad a revisar.</param>
        /// <param name="clase">Clase en cuestión.</param>
        /// <returns>Profesor que no puede impartir la clase, en caso de no haber retorna null.</returns>
        public static Profesor operator !=(Universidad g, EClases clase) {
            for (int i = 0; i < g._profesores.Count; i++) {
                if (g._profesores[i] != clase)
                    return g._profesores[i];
            }

            return null;
        }

        /// <summary>
        /// Agrega un alumno a una universidad.
        /// </summary>
        /// <param name="g">Universidad donde se agregará el alumno.</param>
        /// <param name="a"> Alumno a agregar.</param>
        /// <returns>Universidad con el alumno ya agregado.</returns>
        public static Universidad operator +(Universidad g, Alumno a) {
            Universidad auxUniversidad;
            auxUniversidad = g;

            try {
                if (auxUniversidad != a)
                    auxUniversidad._alumnos.Add(a);
                else
                    throw new AlumnoRepetidoException();
            }
            catch (AlumnoRepetidoException e) {
                Console.WriteLine(e.Message);
            }

            return auxUniversidad;
        }

        /// <summary>
        /// Agrega un profesor a una universidad.
        /// </summary>
        /// <param name="g">Universidad donde se agregará el profesor.</param>
        /// <param name="i">Profesor a agregar.</param>
        /// <returns>Universidad con el profesor ya agregado.</returns>
        public static Universidad operator +(Universidad g, Profesor i) {
            Universidad auxUniversidad;
            auxUniversidad = g;

            if (auxUniversidad != i)
                auxUniversidad._profesores.Add(i);

            return auxUniversidad;
        }

        /// <summary>
        /// Agrega una clase a una nueva jornada, la cual es agregada a la lista de jornadas de una universidad.
        /// </summary>
        /// <param name="gim">Universidad donse se agregará la clase.</param>
        /// <param name="clase">Clase a agregar.</param>
        /// <returns>Universidad con la nueva jornada que contiene la clase agregada.</returns>
        public static Universidad operator +(Universidad gim, EClases clase) {
            Universidad auxUniversidad;
            auxUniversidad = gim;
            Jornada jornada = new Jornada(clase, auxUniversidad == clase);

            for (int i = 0; i < auxUniversidad._alumnos.Count; i++) {
                if (auxUniversidad._alumnos[i] == clase)
                    jornada += auxUniversidad._alumnos[i];
            }

            auxUniversidad._jornada.Add(jornada);

            return auxUniversidad;
        }

        /// <summary>
        /// Serializa una Universidad en un archivo XML.
        /// </summary>
        /// <param name="gim">Universidad a serializar.</param>
        /// <returns>Retorna true en caso de éxito.</returns>
        public static bool Guardar(Universidad gim) {
            Xml<Universidad> archivo = new Xml<Universidad>();

            archivo.guardar("Universidad.xml", gim);

            return true;
        }

        /// <summary>
        /// Deserializa una Universidad de un archivo XML.
        /// </summary>
        /// <returns>Universidad deserializada.</returns>
        public static Universidad Leer() {
            Universidad retorno = new Universidad();
            Xml<Universidad> archivo = new Xml<Universidad>();

            archivo.leer("Universidad.xml", out retorno);

            return retorno;
        }
    }
}
