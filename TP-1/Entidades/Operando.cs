using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        #region Set
        // Propiedad que setea los numeros ingresados por el usuario utilizando el metodo ValidarOperando
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        #endregion

        #region Constructores
        // Constructor por defecto de un Objeto de la clase Operando
        public Operando()
        {
            this.numero = 0;
        }
        // Constructor con parametro double 
        public Operando(double numero)
        {
            this.numero = numero;
        }
        // Constructor con el numero en una variable del tipo string que llama a la propiedad que lo setea
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        #endregion

        #region Metodos
        // Metodo que recibe el numero ingresado por el usuario en una variable tipo string
        // Lo convierte a double de ser un numero valido y de nos serlo devuelve 0
        public static double ValidarOperando(string strNumero)
        {
            double rtn;
            double.TryParse(strNumero, out rtn);
            return rtn;
        }
        // Metodo que valida que el string pasado por parametro sea un numero del tipo binario
        // Devuelve un booleano
        private static bool EsBinario(string binario)
        {
            int cont = 0;
            foreach (var item in binario)
            {
                if (item == 1 || item == 0)
                    cont++;
            }
            if(cont == binario.Length)
            {
                return true;
            }
            return false;
        }
        // Metodo que toma el binario y lo convierte a decimal
        // Recibe el binario pasado por parametro, lo valida y lo convierte a decimal
        // Retorna el binario convertido a decimal en string, de no ser posible retorna un mensaje indicando VALOR INVALIDO
        public static string BinarioDecimal(string binario)
        {
            bool validacion = true;
            string rtn = "Valor inválido";

            foreach (var item in binario)
            {
                if (item != '0' && item != '1')
                {
                    validacion = false;
                }
            }

            if (validacion == true)
            {
                rtn = Convert.ToInt32(binario, 2).ToString();
            }

            return rtn;
        }
        // Metodo que transforma el decimal a binario
        // Recibe por parametro el numero decimal y lo convierte a binario
        // Retorna el numero decimal en binario
        public static string DecimalBinario(double numero)
        {
            return Convert.ToString((int)Math.Abs(numero), 2);
        }
        // Sobrecarga del metodo que tranforma un numero decimal a binario
        // Valida el numero decimal pasado por parametro y de serlo se lo pasa al metodo DecimalBinario
        // Retorna el numero decimal convertido a binario en una varibale tipo string
        public static string DecimalBinario(string strNumero)
        {
            string rtn = "Valor Inválido";
            double valor;
            if(double.TryParse(strNumero, out valor))
            {
                rtn = DecimalBinario(valor);
            }
            return rtn;
        }
        #endregion

        #region Operadores
        // Sobrecargas de los operadores disponibles, entre objetos de la clase Operando
        public static double operator +(Operando n1, Operando n2)
        {
            double rtn = n1.numero + n2.numero;
            return rtn;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            double rtn = n1.numero - n2.numero;
            return rtn;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            double rtn = n1.numero * n2.numero;
            return rtn;
        }
        // Esta sobrecarga valida que el segundo numero no sea 0, y de serlo devuelve double.MinValue
        public static double operator /(Operando n1, Operando n2)
        {
            double rtn = double.MinValue;
            if(n2.numero != 0)
            {
                rtn = n1.numero / n2.numero;
            }
            return rtn;
        }
        #endregion

    }
}
