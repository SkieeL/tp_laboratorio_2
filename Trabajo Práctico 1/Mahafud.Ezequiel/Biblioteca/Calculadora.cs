using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Calculadora
    {
        #region Métodos
        /// <summary>
        /// Realiza sumas, restas, multiplicaciones y divisiones a partir de dos objetos tipo Numero y el operador en cuestión (string).
        /// </summary>
        /// <param name="numero1">Primer número</param>
        /// <param name="numero2">Segundo número</param>
        /// <param name="operador">Operador</param>
        /// <returns>Resultado de la operación</returns>
        public static double operar(Numero numero1, Numero numero2, string operador) {
            double retorno = 0;
            string operadorValidado;

            operadorValidado = validarOperador(operador);

            switch (operadorValidado) {
                case "+": {
                    retorno = numero1.getNumero() + numero2.getNumero();
                    break;
                }
                case "-": {
                    retorno = numero1.getNumero() - numero2.getNumero();
                    break;
                }
                case "*": {
                    retorno = numero1.getNumero() * numero2.getNumero();
                    break;
                }
                case "/": {
                    if (numero2.getNumero() == 0) {
                        return 0;
                    }

                    retorno = numero1.getNumero() / numero2.getNumero();
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Valida que un string sea un operador matemático de suma, resta, multiplicación o división.
        /// </summary>
        /// <param name="operador">Cadena a validar</param>
        /// <returns>Operador validado, en caso de error, retorna el operador "+".</returns>
        public static string validarOperador(string operador) {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                return operador;

            return "+";
        }
        #endregion
    }
}
