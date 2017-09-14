using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Calculadora
    {
        #region Métodos
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

        public static string validarOperador(string operador) {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                return operador;

            return "+";
        }
        #endregion
    }
}
