using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }

        private ETipo _tipo;

        /// <summary>
        /// Retorna la cantidad de calorías (20).
        /// </summary>
        protected override short CantidadCalorias {
            get { return 20; }
        }

        /// <summary>
        /// Constructor por defecto, inicializa los atributos del Producto y el tipo de Leche en "Entera".
        /// </summary>
        /// <param name="marca">Marca</param>
        /// <param name="codigo">Código de barras</param>
        /// <param name="color">Color primario del empaque</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color) {
            this._tipo = ETipo.Entera;
        }

        /// <summary>
        /// Constructor parametrizado, inicializa todos los atributos del Producto.
        /// </summary>
        /// <param name="marca">Marca</param>
        /// <param name="codigo">Código de barras</param>
        /// <param name="color">Color primario del empaque</param>
        /// <param name="tipo">Tipo de leche (Entera/Descremada)</param>param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo) : base(codigo, marca, color) {
            this._tipo = tipo;
        }

        /// <summary>
        /// Devuelve todos los datos del Producto.
        /// </summary>
        /// <returns>Datos del producto en formato string</returns>
        public override sealed string Mostrar() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine((string) this);
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this._tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
