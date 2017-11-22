using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    public class Profesor : Universitario
    {
        private Queue<EClases> _clasesDelDia;
        private static Random _random;

        static Profesor() {
            Profesor._random = new Random();
        }

        public Profesor() : this(1, "", "", "1", ENacionalidad.Argentino) { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
         : base(id, nombre, apellido, dni, nacionalidad) {
            this._clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        private void _randomClases() {
            int numero;

            for (int i = 0; i < 2; i++) {
                numero = Profesor._random.Next(0, 3);

                switch (numero) {
                    case 0:
                        this._clasesDelDia.Enqueue(EClases.Programacion);
                        break;
                    case 1:
                        this._clasesDelDia.Enqueue(EClases.Laboratorio);
                        break;
                    case 2:
                        this._clasesDelDia.Enqueue(EClases.Legislacion);
                        break;
                    case 3:
                        this._clasesDelDia.Enqueue(EClases.SPD);
                        break;
                }
            }
        }

        protected override string MostrarDatos() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendLine("CLASES DEL DIA:");
            retorno.AppendLine((this._clasesDelDia.First()).ToString());
            retorno.AppendLine((this._clasesDelDia.Last()).ToString());

            return retorno.ToString();
        }

        public static bool operator ==(Profesor i, EClases clase) {
            if (i._clasesDelDia.First() == clase || i._clasesDelDia.Last() == clase)
                return true;

            return false;
        }

        public static bool operator !=(Profesor i, EClases clase) {
            if (!(i == clase))
                return true;

            return false;
        }

        protected override string ParticiparEnClase() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("CLASES DEL DÍA:");
            retorno.AppendFormat("{0}\n{1}\n", (this._clasesDelDia.First()).ToString(), (this._clasesDelDia.Last()).ToString());

            return retorno.ToString();
        }

        public override string ToString() {
            return this.MostrarDatos();
        }
    }
}
