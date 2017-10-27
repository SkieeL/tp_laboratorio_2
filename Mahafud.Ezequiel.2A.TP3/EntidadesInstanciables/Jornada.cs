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

        private Jornada() {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor) : this() {
            this._clase = clase;
            this._instructor = instructor;
        }

        public static Jornada operator +(Jornada j, Alumno a) {
            Jornada auxJornada;
            auxJornada = j;

            if (auxJornada != a) {
                auxJornada._alumnos.Add(a);
            }

            return auxJornada;
        }

        public static bool operator ==(Jornada j, Alumno a) {
            for (int i = 0; i < j._alumnos.Count; i++) {
                if (j._alumnos[i] == a) {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Jornada j, Alumno a) {
            if (!(j == a))
                return true;

            return false;
        }

        public override string ToString() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("CLASE DE {0} POR {1}\n", this._clase, this._instructor.ToString());
            retorno.AppendLine("ALUMNOS:");

            for (int i = 0; i < this._alumnos.Count; i++) {
                retorno.AppendLine(this._alumnos[i].ToString());
            }

            return retorno.ToString();
        }

        public static bool Guardar(Jornada jornada) {
            Texto archivo = new Texto();

            archivo.guardar("Jornada.txt", jornada.ToString());

            return true;
        }

        public static string Leer() {
            string retorno;
            Texto archivo = new Texto();

            archivo.leer("Jornada.txt", out retorno);

            return retorno;
        }
    }
}
