using System;

namespace Biblioteca
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Constructores
        public Numero() {
            this.numero = 0;
        }

        public Numero(string strNumero) {
                setNumero(strNumero);
        }

        public Numero(double num) {
            this.numero = num;
        }
        #endregion

        #region Métodos
        public double getNumero() {
            return this.numero;
        }

        private void setNumero(string strNumero) {
            this.numero = validarNumero(strNumero);
        }

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
