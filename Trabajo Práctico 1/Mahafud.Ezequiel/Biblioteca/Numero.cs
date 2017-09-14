using System;

namespace Biblioteca
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto, inicializa el atributo numero en 0.
        /// </summary>
        public Numero() {
            this.numero = 0;
        }

        /// <summary>
        /// Sobrecarga del constructor, inicializa el atributo numero con el valor que contenga el string del parámetro, si no se puede castear el string, inicializa el atributo en 0.
        /// </summary>
        /// <param name="strNumero">String a castear a dato tipo double para inicializar el atributo.</param>
        public Numero(string strNumero) {
                setNumero(strNumero);
        }

        /// <summary>
        /// Sobrecarga del constructor, inicializa el atributo numero con el valor pasado por parámetro.
        /// </summary>
        /// <param name="num">Valor que tomará el atributo numero.</param>
        public Numero(double num) {
            this.numero = num;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Getter, retorna el valor del atributo numero.
        /// </summary>
        /// <returns>Valor del atributo número.</returns>
        public double getNumero() {
            return this.numero;
        }

        /// <summary>
        /// Setter, asigna el valor del atributo numero a partir del string pasado como parámetro, el cual es validado, si no se logra castear el dato, se le asigna el valor 0 al atributo.
        /// </summary>
        /// <param name="strNumero">Cadena a validar y asignar como valor del atributo.</param>
        private void setNumero(string strNumero) {
            this.numero = validarNumero(strNumero);
        }

        /// <summary>
        /// Valida que una cadena se pueda castear a double, si lo logra retorna el valor en formato double, sino devuelve 0.
        /// </summary>
        /// <param name="strNumero">Valor casteado a double.</param>
        /// <returns></returns>
        private static double validarNumero(string strNumero) {
            double num;

            if (double.TryParse(strNumero, out num)) {
                return num;
            }

            return 0;
        }
        #endregion

    }
}
