using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        private string _codigoDeBarras;
        private ConsoleColor _colorPrimarioEmpaque;
        private EMarca _marca;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorías del artículo.
        /// </summary>
        protected abstract short CantidadCalorias { get; }

        /// <summary>
        /// Constructor parametrizado, inicializa los atributos del Objeto.
        /// </summary>
        /// <param name="codigoDeBarras">Código de barras</param>
        /// <param name="marca">Marca</param>
        /// <param name="color">Color primario del empaque</param>
        public Producto(string codigoDeBarras, EMarca marca, ConsoleColor color) {
            this._codigoDeBarras = codigoDeBarras;
            this._marca = marca;
            this._colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// Devuelve todos los datos del Producto.
        /// </summary>
        /// <returns>Datos del producto en formato string</returns>
        public virtual string Mostrar() {
            return (string) this;
        }

        /// <summary>
        /// Transforma un objeto de tipo Producto a String.
        /// </summary>
        /// <param name="p">Producto a mostrar sus detalles</param>
        public static explicit operator string(Producto p) {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p._marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras.
        /// </summary>
        /// <param name="v1">Primer producto a comparar</param>
        /// <param name="v2">Segundo producto a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2) {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto.
        /// </summary>
        /// <param name="v1">Primer producto a comparar</param>
        /// <param name="v2">Segundo producto a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2) {
            return (!(v1 == v2));
        }
    }
}
