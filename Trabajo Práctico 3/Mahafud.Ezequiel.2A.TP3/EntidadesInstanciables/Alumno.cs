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

        public Alumno() : this(1, "", "", "1", ENacionalidad.Argentino, EClases.Laboratorio, EEstadoCuenta.AlDia) { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
         : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.AlDia) { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
         : base(id, nombre, apellido, dni, nacionalidad) {
            this._claseQueToma = claseQueToma;
            this._estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendFormat("ESTADO DE LA CUENTA: {0}\n", this._estadoCuenta == EEstadoCuenta.AlDia ? "Cuota Al Día" : (this._estadoCuenta).ToString());
            retorno.AppendFormat(this.ParticiparEnClase());

            return retorno.ToString();
        }

        public static bool operator ==(Alumno a, EClases clase) {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;

            return false;
        }

        public static bool operator !=(Alumno a, EClases clase) {
            if (a._claseQueToma != clase)
                return true;

            return false;
        }

        protected override string ParticiparEnClase() {
            return "TOMA CLASE DE " + (this._claseQueToma).ToString();
        }

        public override string ToString() {
            return this.MostrarDatos();
        }
    }
}
