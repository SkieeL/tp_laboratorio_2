using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario() : this(1, "", "", "1", ENacionalidad.Argentino) { }


        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="legajo">Legajo del universitario.</param>
        /// <param name="nombre">Nombre del universitario.</param>
        /// <param name="apellido">Apellido del universitario.</param>
        /// <param name="dni">DNI del universitario.</param>
        /// <param name="nacionalidad">Nacionalidad del universitario.</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :
        base(nombre, apellido, dni, nacionalidad) {
            this._legajo = legajo;
        }

        /// <summary>
        /// Devuelve todos los datos del universitario.
        /// </summary>
        /// <returns>Datos del universitario en formato string.</returns>
        protected virtual string MostrarDatos() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.ToString());
            retorno.AppendFormat("LEGAJO NÚMERO: {0}\n", this._legajo);

            return retorno.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Verifica si un objeto es de tipo Universitario.
        /// </summary>
        /// <param name="obj">Objeto a verificar.</param>
        /// <returns>True en caso de que lo sea, false en caso contrario.</returns>
        public override bool Equals(object obj) {
            if (obj is Universitario)
                return true;

            return false;
        }

        /// <summary>
        /// Verifica si dos objetos de tipo Universitario son iguales mediante el legajo y el DNI.
        /// </summary>
        /// <param name="pg1">Primer Universitario a comparar.</param>
        /// <param name="pg2">Segundo Universitario a comparar.</param>
        /// <returns>True en caso de éxito, false en caso de que sean distintos.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2) {
            if (pg1.Equals(pg2) && (pg1._legajo == pg2._legajo || pg1.DNI == pg2.DNI))
                return true;

            return false;
        }

        /// <summary>
        /// Verifica si dos objetos de tipo Universitario son diferentes mediante el legajo y el DNI.
        /// </summary>
        /// <param name="pg1">Primer Universitario a comparar.</param>
        /// <param name="pg2">Segundo Universitario a comparar.</param>
        /// <returns>True en caso de éxito, false en caso de que sean iguales.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2) {
            if (!(pg1 == pg2))
                return true;

            return false;
        }
    }
}
