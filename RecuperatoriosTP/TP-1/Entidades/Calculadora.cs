using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        // Metodo que valida el operador ingresado por el usuario entre las posibles opciones
        // Recibe el operador ingresado por el usuario dentro de una variable tipo char
        // Devuelve el operador en caso de que se valide correctamente, en caso contrario devuelve + por defecto
        private static char ValidarOperador(char operador)
        {
            char rtn = '+';
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                rtn = operador;
            }
            return rtn;
        }
        // Metodo que realiza la operacion deseada por el usuario entre los numeros ingresados por el mismo
        // Recibe por parametros el operador, el cual lo valida con el metodo ValidarOperador, y los numeros en dos objetos de la clase Operando
        // Devuelve el resultado si se validan los datos pasados por parametros o 0 en caso contrario
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double rtn = 0;
            operador = ValidarOperador(operador);
            if(num1 != null && num2 != null)
            {
                switch (operador)
                {
                    case '+':
                        rtn = num1 + num2;
                        break;
                    case '-':
                        rtn = num1 - num2;
                        break;
                    case '/':
                        rtn = num1 / num2;
                        break;
                    case '*':
                        rtn = num1 * num2;
                        break;
                    default:
                        break;
                }
            }
            return rtn;
        }
        #endregion
    }
}
