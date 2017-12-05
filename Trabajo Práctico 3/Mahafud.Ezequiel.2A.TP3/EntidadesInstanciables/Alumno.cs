using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static EntidadesInstanciables.Universidad;

namespace EntidadesInstanciables
{
    public class Alumno : Universitario
    {
        private EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta {
            AlDia,
            Deudor,
            Becado
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Alumno() : this(1, "", "", "1", ENacionalidad.Argentino, EClases.Laboratorio, EEstadoCuenta.AlDia) { }

        /// <summary>
        /// Constructor parametrizado, primera sobrecarga.
        /// </summary>
        /// <param name="id">Legajo del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">DNI del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        /// <param name="claseQueToma">Clase que toma el alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
         : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.AlDia) { }

        /// <summary>
        /// Constructor parametrizado, segunda sobrecarga.
        /// </summary>
        /// <param name="id">Legajo del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">DNI del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        /// <param name="claseQueToma">Clase que toma el alumno.</param>
        /// <param name="estadoCuenta">Estado de la cuenta del alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
         : base(id, nombre, apellido, dni, nacionalidad) {
            this._claseQueToma = claseQueToma;
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Muestra todos los datos del alumno.
        /// </summary>
        /// <returns>Datos del alumno en formato string.</returns>
        protected override string MostrarDatos() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendFormat("ESTADO DE LA CUENTA: {0}\n", this._estadoCuenta == EEstadoCuenta.AlDia ? "Cuota Al Día" : (this._estadoCuenta).ToString());
            retorno.AppendFormat(this.ParticiparEnClase());

            return retorno.ToString();
        }

        /// <summary>
        /// Compara un alumno con una clase verificando si el alumno toma dicha clase y si su estado de cuenta está al día o está becado.
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Retorna true en caso de éxito, caso contrario false.</returns>
        public static bool operator ==(Alumno a, EClases clase) {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;

            return false;
        }

        /// <summary>
        /// Verifica si un alumno no pertenece a una clase.
        /// </summary>
        /// <param name="a">Alumno a verificar</param>
        /// <param name="clase">Clase a verificar.</param>
        /// <returns>Retorna true si el alumno no toma esa clase, caso contrario false.</returns>
        public static bool operator !=(Alumno a, EClases clase) {
            if (a._claseQueToma != clase)
                return true;

            return false;
        }

        /// <summary>
        /// Retorna la clase que toma un alumno.
        /// </summary>
        /// <returns>Retorna la clase que toma un alumno en formato string.</returns>
        protected override string ParticiparEnClase() {
            return "TOMA CLASE DE " + (this._claseQueToma).ToString();
        }

        /// <summary>
        /// Sobreescribe el método ToString mostrando todos los datos del alumno.
        /// </summary>
        /// <returns>Datos del alumno en formato string.</returns>
        public override string ToString() {
            return this.MostrarDatos();
        }
    }
}
