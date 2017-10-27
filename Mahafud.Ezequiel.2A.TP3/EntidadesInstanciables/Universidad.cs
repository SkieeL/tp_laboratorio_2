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

        public Universidad() {
            this._alumnos = new List<Alumno>();
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
        }

        private static string MostrarDatos(Universidad gim) {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("JORNADA:");

            for (int i = 0; i < gim._jornada.Count; i++) {
                retorno.AppendLine(gim._jornada[i].ToString());
                retorno.AppendLine("<------------------------------------------------>");
            }

            return retorno.ToString();
        }

        public override string ToString() {
            return Universidad.MostrarDatos(this);
        }

        public static bool operator ==(Universidad g, Alumno a) {
            for (int i = 0; i < g._alumnos.Count; i++) {
                if (g._alumnos[i] == a)
                    return true;
            }

            return false;
        }

        public static bool operator !=(Universidad g, Alumno a) {
            if (!(g == a))
                return true;

            return false;
        }

        public static bool operator ==(Universidad g, Profesor i) {
            for (int j = 0; j < g._profesores.Count; j++) {
                if (g._profesores[j] == i)
                    return true;
            }

            return false;
        }

        public static bool operator !=(Universidad g, Profesor i) {
            if (!(g == i))
                return true;

            return false;
        }

        public static Profesor operator ==(Universidad g, EClases clase) {
            for (int i = 0; i < g._profesores.Count; i++) {
                if (g._profesores[i] == clase)
                    return g._profesores[i];
            }

            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad g, EClases clase) {
            for (int i = 0; i < g._profesores.Count; i++) {
                if (g._profesores[i] != clase)
                    return g._profesores[i];
            }

            return null;
        }

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

        public static Universidad operator +(Universidad g, Profesor i) {
            Universidad auxUniversidad;
            auxUniversidad = g;

            if (auxUniversidad != i)
                auxUniversidad._profesores.Add(i);

            return auxUniversidad;
        }

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

        public static bool Guardar(Universidad gim) {
            Xml<Universidad> archivo = new Xml<Universidad>();

            archivo.guardar("Universidad.xml", gim);

            return true;
        }

        public static Universidad Leer() {
            Universidad retorno = new Universidad();
            Xml<Universidad> archivo = new Xml<Universidad>();

            archivo.leer("Universidad.xml", out retorno);

            return retorno;
        }
    }
}
