using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Snacks : Producto
    {
        /// <summary>
        /// Constructor por defecto, inicializa los atributos del Producto.
        /// </summary>
        /// <param name="marca">Marca</param>
        /// <param name="codigo">Código de barras</param>
        /// <param name="color">Color primario del empaque</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color) {
        }

        /// <summary>
        /// Retorna la cantidad de calorías (104).
        /// </summary>
        protected override short CantidadCalorias {
            get { return 104; }
        }

        /// <summary>
        /// Devuelve todos los datos del Producto.
        /// </summary>
        /// <returns>Datos del producto en formato string</returns>
        public override sealed string Mostrar() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine((string) this);
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
