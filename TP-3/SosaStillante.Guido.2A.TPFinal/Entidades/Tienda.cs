using System;
using System.Text;

namespace Entidades
{
    public class Tienda
    {

        #region Atributos
        /// <summary>
        /// Atributos de la clase publica Tienda
        /// </summary>
        public Listado<Vendedor> listVen;
        public Listado<Comprador> listCom;
        private string nombre;
        private int capacidadVen;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de Tienda
        /// </summary>
        public Tienda()
        {
            
        }

        /// <summary>
        /// Sobrecarga de constructor con parametro string invoca a la sobrecarga de dos parametros
        /// </summary>
        /// <param name="nombre">Nombre de la tienda</param>
        public Tienda(string nombre) : this(5,nombre) { }

        /// <summary>
        /// Sobrecarga de constructor con parametro int invoca a la sobrecarga de dos parametros 
        /// </summary>
        /// <param name="capacidad">Capacidad maxima de vendedores en la tienda</param>
        public Tienda(int capacidad) : this(capacidad, "TiendaCrypto") { }

        /// <summary>
        /// Sobrecarga de constructor con dos parametros que invoca al constructor por defecto para inicializar las listas
        /// </summary>
        /// <param name="capacidad"></param>
        /// <param name="nombre"></param>
        public Tienda(int capacidad, string nombre) : this()
        {
            listCom = new Listado<Comprador>();
            listVen = new Listado<Vendedor>();
            this.capacidadVen = capacidad;
            this.nombre = nombre;
        }
        #endregion

        #region Prop

        /// <summary>
        /// Propiedad de lectura y escritura para el atributo nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el atributo capacidadVen
        /// </summary>
        public int CapacidadVen
        {
            get { return this.capacidadVen; }
            set { this.capacidadVen = value; }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para mostrar por pantalla el listado de vendedores
        /// </summary>
        /// <returns>Retorna un objeto tipo StringBuilder parseado a string</returns>
        public string MostrarVendedores()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vendedores: ");
            foreach(Vendedor item in this.listVen.Lista)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Metodo para mostrar el listado de compradores totales de la tienda
        /// </summary>
        /// <returns>Retorna un objeto del tipo StringBuilder parseado a string</returns>
        public string MostrarCompradores()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Compradores: ");
            foreach(Comprador item in this.listCom.Lista)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Metodo para mostrar la informacion completa de la tienda
        /// </summary>
        /// <returns>Retorna un objeto del tipo StringBuilder parseado a String</returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nombre: " + this.Nombre);
            sb.AppendLine("Cantidad Maxima de Vendedores: " + this.CapacidadVen);
            sb.AppendLine(this.MostrarVendedores());
            sb.AppendLine(this.MostrarCompradores());
            return sb.ToString();
        }

        /// <summary>
        /// Metodo de Compra y venta de la tienda que luego de verificar que los parametros no sean nulos, invoca a los metodos correspondientes de cada objeto
        /// </summary>
        /// <param name="ven">Vendedor</param>
        /// <param name="com">Comprador</param>
        public void CompraVenta(Vendedor ven, Comprador com)
        {
            if(ven is not null && com is not null)
            {
                if(ven.Btc >= 1 && com.Billetera >= 63000)
                {
                    ven.Venta(com);
                    com.Compra();
                }
            }
        }

        /// <summary>
        /// Metodo de Ordenamiento por medio de un enumerado
        /// </summary>
        /// <param name="o">Tipo de ordenamiento</param>
        public void OrdenarListadoVend(EOrdenamiento o)
        {
            switch (o)
            {
                case EOrdenamiento.Nombre:
                    this.listVen.Lista.Sort(OrdenarPorNombre);
                    break;
                case EOrdenamiento.MayorGanancia:
                    this.listVen.Lista.Sort(OrdenarPorGanancia);
                    break;
                case EOrdenamiento.Apellido:
                    this.listVen.Lista.Sort(OrdenarPorApellido);
                    break;
                case EOrdenamiento.CantCompradores:
                    this.listVen.Lista.Sort(OrdenarPorCantCompradores);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Metodo de ordenamiento por Apellido(alfabeticamente)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int OrdenarPorApellido(Vendedor a, Vendedor b)
        {
            return (a.Apellido).CompareTo(b.Apellido);
        }

        /// <summary>
        /// Metodo de ordenamiento por Ganacia, de mayor a menor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int OrdenarPorGanancia(Vendedor a, Vendedor b)
        {
            return (int)(b.ganancia - a.ganancia);
        }
        /// <summary>
        /// Metodo de ordenamiento por Ganacia, de mayor a menor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int OrdenarPorCantCompradores(Vendedor a, Vendedor b)
        {
            return (int)(b.listaCompradores.Cantidad - a.listaCompradores.Cantidad);
        }
        /// <summary>
        /// Metodo de ordenamiento por nombre(alfabeticamente)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int OrdenarPorNombre(Vendedor a, Vendedor b)
        {
            return (a.Nombre).CompareTo(b.Nombre);
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Sobrecarga de operador '==' entre un objeto tipo tienda y uno tipo vendedor para verificar que el vendedor forma parte de la tienda
        /// </summary>
        /// <param name="a">Objeto tienda</param>
        /// <param name="b">Objeto vendedor</param>
        /// <returns>Retorna un booleano, false si el vendedor no se encuentra en la tienda y true si lo esta</returns>
        public static bool operator ==(Tienda a, Vendedor b)
        {
            bool rtn = false;
            if (a is not null && b is not null)
            {
                foreach (Vendedor item in a.listVen.Lista)
                {
                    if (b == item)
                    {
                        rtn = true;
                        break;
                    }
                }
            }
            return rtn;
        }

        /// <summary>
        /// Sobrecarga de operador '!=' contrario a '=='
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Retorna false si el vendedor esta en la tienda y true si no esta</returns>
        public static bool operator !=(Tienda a, Vendedor b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Sobrecarga del operador '+' entre objetos del tipo tienda y vendedor, si la tienda tiene espacio en su listado, agrega al vendedor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Retorna la tienda pasada por parametro con el vendedor agregado o la misma si ya lo contenia</returns>
        public static Tienda operator +(Tienda a, Vendedor b)
        {
            if ((a.listVen.Lista.Count + 1) <= a.capacidadVen && a != b)
            {
                a.listVen.Lista.Add(b);
            }
            return a;
        }

        /// <summary>
        /// Sobrecarga de operador '==' entre un objeto tipo tienda y uno tipo comprador para verificar que el comprador forma parte de la tienda
        /// </summary>
        /// <param name="a">Obejto tipo tienda</param>
        /// <param name="b">Objeto tipo comprador</param>
        /// <returns>Retorna true si el comprador se encuentra en la tienda false si no</returns>
        public static bool operator ==(Tienda a, Comprador b)
        {
            bool rtn = false;
            if (a is not null && b is not null)
            {
                foreach (Comprador item in a.listCom.Lista)
                {
                    if (b == item)
                    {
                        rtn = true;
                        break;
                    }
                }
            }
            return rtn;
        }

        /// <summary>
        /// Sorbrecarga operador '!=' contrario a '=='
        /// </summary>
        /// <param name="a">Objeto tipo tienda</param>
        /// <param name="b">Objeto tipo comprador</param>
        /// <returns>Retorna true si no se encuentra el comprador en la tienda, true si si se encuentra</returns>
        public static bool operator !=(Tienda a, Comprador b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Sobrecarga operador '+' entre objetos del tipo tienda y comprador, si la tienda no tiene a ese comprador, lo suma a su coleccion
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>la tienda con el comprador pasado por parametros</returns>
        public static Tienda operator +(Tienda a, Comprador b)
        {
            if (a != b)
            {
                a.listCom.Lista.Add(b);
            }
            return a;
        }
        #endregion

    }
}
