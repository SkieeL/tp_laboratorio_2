using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Constructor parametrizado, inicializa los atributos del objeto.
        /// </summary>
        /// <param name="marca">Marca</param>
        /// <param name="codigo">Código de barras</param>
        /// <param name="color">Color primario del empaque</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color) {
        }

        /// <summary>
        /// Retorna la cantidad de calorías (80).
        /// </summary>
        protected override short CantidadCalorias {
            get { return 80; }
        }

        /// <summary>
        /// Devuelve todos los datos del Producto.
        /// </summary>
        /// <returns>Datos del producto en formato string</returns>
        public override sealed string Mostrar() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
