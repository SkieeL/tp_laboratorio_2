﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        public Universitario() : this(1, "", "", "1", ENacionalidad.Argentino) { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :
        base(nombre, apellido, dni, nacionalidad) {
            this._legajo = legajo;
        }

        protected virtual string MostrarDatos() {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.ToString());
            retorno.AppendFormat("LEGAJO NÚMERO: {0}\n", this._legajo);

            return retorno.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj) {
            if (obj is Universitario)
                return true;

            return false;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2) {
            if (pg1.Equals(pg2) && (pg1._legajo == pg2._legajo || pg1.DNI == pg2.DNI))
                return true;

            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2) {
            if (!(pg1 == pg2))
                return true;

            return false;
        }
    }
}