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


        /// <summary>
        /// Constructor estático por defecto, inicializa la propiedad random.
        /// </summary>
        static Profesor() {
            Profesor._random = new Random();
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Profesor() : this(1, "", "", "1", ENacionalidad.Argentino) { }

        /// <summary>
        /// Constructor parametrizado, primera sobrecarga.
        /// </summary>
        /// <param name="id">Identificador del profesor.</param>
        /// <param name="nombre">Nombre del profesor.</param>
        /// <param name="apellido">Apellido del profesor.</param>
        /// <param name="dni">DNI del profesor.</param>
        /// <param name="nacionalidad">Nacionalidad del profesor.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
         : base(id, nombre, apellido, dni, nacionalidad) {
            this._clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Le asigna aleatoriamente una clase del día a un profesor.
        /// </summary>
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

        /// <summary>
        /// Devuelve todos los datos del profesor.
        /// </summary>
        /// <returns>Retorna todos los datos del profesor en formato string.</returns>
        protected override string MostrarDatos() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendLine("CLASES DEL DIA:");
            retorno.AppendLine((this._clasesDelDia.First()).ToString());
            retorno.AppendLine((this._clasesDelDia.Last()).ToString());

            return retorno.ToString();
        }

        /// <summary>
        /// Verifica si un profesor puede dar una clase.
        /// </summary>
        /// <param name="i">Profesor en cuestión.</param>
        /// <param name="clase">Clase a verificar si puede ser dada por el profesor.</param>
        /// <returns>Si la clase puede ser impartida por el profesor retorna true, caso contrario devuelve false.</returns>
        public static bool operator ==(Profesor i, EClases clase) {
            if (i._clasesDelDia.First() == clase || i._clasesDelDia.Last() == clase)
                return true;

            return false;
        }

        /// <summary>
        /// Verifica si un profesor no puede dar una clase.
        /// </summary>
        /// <param name="i">Profesor en cuestión.</param>
        /// <param name="clase">Clase a verificar si no puede ser dada por el profesor.</param>
        /// <returns>Si la clase no puede ser impartida por el profesor retorna true, caso contrario devuelve false.</returns>
        public static bool operator !=(Profesor i, EClases clase) {
            if (!(i == clase))
                return true;

            return false;
        }

        /// <summary>
        /// Devuelve las clases que puede dar un profesor.
        /// </summary>
        /// <returns>Retorna las clases que puede dar un profesor en formato string.</returns>
        protected override string ParticiparEnClase() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("CLASES DEL DÍA:");
            retorno.AppendFormat("{0}\n{1}\n", (this._clasesDelDia.First()).ToString(), (this._clasesDelDia.Last()).ToString());

            return retorno.ToString();
        }

        /// <summary>
        /// Sobreescribe el método ToString mostrando todos los datos del profesor.
        /// </summary>
        /// <returns>Retorna todos los datos del profesor en formato string.</returns>
        public override string ToString() {
            return this.MostrarDatos();
        }
    }
}
