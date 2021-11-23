using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vendedor : Persona
    {

        #region Atributos
        /// <summary>
        /// Atributos propios de la clase Vendedor (Derivada de persona)
        /// </summary>
        private double btc;
        public Listado<Comprador> listaCompradores;
        public double ganancia;
        #endregion

        #region Prop

        /// <summary>
        /// Propieda de lectura y escritura para el atributo btc de vendedor
        /// </summary>
        public double Btc
        {
            get { return this.btc; }
            set { this.btc = value; }
        }

        /// <summary>
        /// Propiedad de escritura de atributo btc invocando al metodo ValidarDouble de la clase base
        /// </summary>
        public string btcString
        {
            set { this.btc = ValidarDouble(value); }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase vendedor
        /// </summary>
        public Vendedor() { }

        /// <summary>
        /// Sobrecarga de constructor con todos los parametros necesarios de la clase base, invoca a la sobrecarga de la clase base correspondiente
        /// </summary>
        /// <param name="nombre">Nombre del vendedor</param>
        /// <param name="apellido">Apellido del vendedor</param>
        /// <param name="dni">Documento del vendedor</param>
        /// <param name="genero">Genero del vendedor</param>
        /// <param name="btc">Btc del vendedor</param>
        public Vendedor(string nombre, string apellido, long dni, EGenero genero, double btc) 
            : base(nombre, apellido, dni, genero)
        {
            this.btc = btc;
            listaCompradores = new Listado<Comprador>(100);
        }
        /// <summary>
        /// Sobrecarga de constructor con todos los parametros necesarios de la clase base, invoca a la sobrecarga de la clase base correspondiente
        /// </summary>
        /// <param name="nombre">Nombre del vendedor</param>
        /// <param name="apellido">Apellido del vendedor</param>
        /// <param name="dni">Documento del vendedor String</param>
        /// <param name="genero">Genero del vendedor</param>
        /// <param name="btc">Btc del vendedor</param>
        public Vendedor(string nombre, string apellido, string dni, EGenero genero, string btc)
            : base(nombre, apellido, dni, genero)
        {
            this.btcString = btc;
            listaCompradores = new Listado<Comprador>(100);
        }
        #endregion

        #region Metodos

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();   
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Documento: {0} ", this.dni);
            sb.AppendFormat("BTC: {0} ", this.btc);
            sb.AppendFormat("Compradores: {0}", this.listaCompradores.Cantidad);
            return sb.ToString();
        }
        public string MostrarCompradores()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Compradores: ");
            foreach(Comprador item in this.listaCompradores.Lista)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Venta(Comprador com)
        {
            this.btc -= 1;
            this.ganancia += 63000;
            if(this != com)
            {
                this.listaCompradores.Lista.Add(com);
            }
        }
        #endregion

        #region Operadores
        public static bool operator ==(Vendedor ven, Comprador com)
        {
            bool rtn = false;
            if(ven is not null && com is not null)
            {
                foreach(Comprador item in ven.listaCompradores.Lista)
                {
                    if(item == (Persona)com)
                    {
                        rtn = true;
                    }
                }
            }
            return rtn;
        }

        public static bool operator !=(Vendedor ven, Comprador com)
        {
            return !(ven == com);
        }

        public static explicit operator String(Vendedor ven)
        {
            return ven.ToString();
        }

        #endregion


    }
}
