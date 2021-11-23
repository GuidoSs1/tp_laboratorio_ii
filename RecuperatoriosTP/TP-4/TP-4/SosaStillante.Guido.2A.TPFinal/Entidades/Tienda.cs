using System;
using System.Text;
using System.Collections.Generic;

namespace Entidades
{
    public class Tienda
    {

        #region Atributos
        /// <summary>
        /// Atributos de la clase publica Tienda
        /// </summary>
        public List<Vendedor> listVen;
        public List<Comprador> listCom;
        private string nombre;
        private int capacidadVen;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de Tienda
        /// </summary>
        public Tienda() {
            listCom = new List<Comprador>();
            listVen = new List<Vendedor>();
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
        public Tienda(int capacidad, string nombre):this()
        {
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
            foreach(Vendedor item in this.listVen)
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
            foreach(Comprador item in this.listCom)
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
            if(ven != null && com != null)
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
                    this.listVen.Sort(OrdenarPorNombre);
                    break;
                case EOrdenamiento.MayorGanancia:
                    this.listVen.Sort(OrdenarPorGanancia);
                    break;
                case EOrdenamiento.Apellido:
                    this.listVen.Sort(OrdenarPorApellido);
                    break;
                case EOrdenamiento.CantCompradores:
                    this.listVen.Sort(OrdenarPorCantCompradores);
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
            return (int)(b.listaCompradores.Count - a.listaCompradores.Count);
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

        #region Metodos de analisis

        /// <summary>
        /// En esta region de codigo se encuentra el informe de todos los analisis y la logica de los mismos, la cual es parecida entre si, solo cambia el atributo por el cual se analisa
        /// </summary>
        /// <returns></returns>
        public string Analizar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nacionalidad de los vendedores en la tienda: ");
            sb.AppendFormat("El porcentaje de vendedores Argentinos en la Tienda es %{0}", this.PorcentajeArgentina());
            sb.AppendLine("\n----------------------------------------------------------------");
            sb.AppendFormat("El porcentaje de vendedores Peruanos en la Tienda es %{0}", this.PorcentajePeru());
            sb.AppendLine("\n----------------------------------------------------------------");
            sb.AppendFormat("El porcentaje de vendedores Paraguayos en la Tienda es %{0}", this.PorcentajeParaguay());
            sb.AppendLine("\n----------------------------------------------------------------");
            sb.AppendFormat("El porcentaje de vendedores Uruguayos en la Tienda es %{0}", this.PorcentajeUruguay());
            sb.AppendLine("\n----------------------------------------------------------------");
            sb.AppendFormat("El porcentaje de vendedores Chilenos en la Tienda es %{0}", this.PorcentajeChile());

            sb.AppendLine("\n\nAnalisis de ventas en la tienda: ");
            sb.AppendFormat("El porcentaje de vendedores que realizo al menos una venta en la tienda es %{0}", this.PorcentajeVentas());

            sb.AppendLine("\n\nGenero de vendedores en la tienda: ");
            sb.AppendFormat("El porcentaje de vendedores en la Tienda es %{0}", this.PorcentajeMasculino());
            sb.AppendLine("\n----------------------------------------------------------------");
            sb.AppendFormat("El porcentaje de vendedoras en la Tienda es %{0}", this.PorcentajeFemenino());
            sb.AppendLine("\n----------------------------------------------------------------");
            sb.AppendFormat("El porcentaje de vendedores No Binarios en la Tienda es %{0}", this.PorcentajeNoBin());

            sb.AppendLine("\n\nVendedores con stock en la tienda: ");
            sb.AppendFormat("La cantidad de vendedores que cuentan con stock en la tienda es %{0}", this.PorcentajeStockVen());

            return sb.ToString();
        }

        private double PorcentajeArgentina()
        {
            double contArg = 0;
            double cantTotal = this.listVen.Count;
            double porcen = 0;

            if(this.listVen != null)
            {
                foreach(Vendedor item in this.listVen)
                {
                    if(item.Nacio == ENacionalidad.Argentina)
                    {
                        contArg++;
                    }
                }
                
                porcen = contArg / cantTotal * 100;

            }
            return porcen;
        }
        private double PorcentajePeru()
        {
            double contArg = 0;
            double cantTotal = this.listVen.Count;
            double porcen = 0;
            if (this.listVen != null)
            {
                foreach (Vendedor item in this.listVen)
                {
                    if (item.Nacio == ENacionalidad.Peru)
                    {
                        contArg++;
                    }
                }
                porcen = contArg / cantTotal * 100;
            }
            return porcen;
        }
        private double PorcentajeParaguay()
        {
            double contArg = 0;
            double cantTotal = this.listVen.Count;
            double porcen = 0;
            if (this.listVen != null)
            {
                foreach (Vendedor item in this.listVen)
                {
                    if (item.Nacio == ENacionalidad.Paraguay)
                    {
                        contArg++;
                    }
                }
                porcen = contArg / cantTotal * 100;
            }
            return porcen;
        }
        private double PorcentajeUruguay()
        {
            double contArg = 0;
            double cantTotal = this.listVen.Count;
            double porcen = 0;
            if (this.listVen != null)
            {
                foreach (Vendedor item in this.listVen)
                {
                    if (item.Nacio == ENacionalidad.Uruguay)
                    {
                        contArg++;
                    }
                }
                porcen = contArg / cantTotal * 100;
            }
            return porcen;
        }
        private double PorcentajeChile()
        {
            double contArg = 0;
            double cantTotal = this.listVen.Count;
            double porcen = 0;
            if (this.listVen != null)
            {
                foreach (Vendedor item in this.listVen)
                {
                    if (item.Nacio == ENacionalidad.Chile)
                    {
                        contArg++;
                    }
                }
                porcen = contArg / cantTotal * 100;
            }
            return porcen;
        }

        private double PorcentajeVentas()
        {
            double cont = 0;
            double cantTotal = this.listVen.Count;
            double porcen = 0;
            if (this.listVen != null)
            {
                foreach(Vendedor item in this.listVen)
                {
                    if(item.listaCompradores.Count != 0)
                    {
                        cont++;
                    }
                }
                porcen = cont / cantTotal * 100;
            }
            return porcen;
        }

        private double PorcentajeMasculino()
        {
            double cont = 0;
            double cantTotal = this.listVen.Count;
            double porcen = 0;
            if (this.listVen != null)
            {
                foreach (Vendedor item in this.listVen)
                {
                    if (item.Genero == EGenero.Masculino)
                    {
                        cont++;
                    }
                }
                porcen = cont / cantTotal * 100;
            }
            return porcen;
        }
        private double PorcentajeFemenino()
        {
            double cont = 0;
            double cantTotal = this.listVen.Count;
            double porcen = 0;
            if (this.listVen != null)
            {
                foreach (Vendedor item in this.listVen)
                {
                    if (item.Genero == EGenero.Femenino)
                    {
                        cont++;
                    }
                }
                porcen = cont / cantTotal * 100;
            }
            return porcen;
        }
        private double PorcentajeNoBin()
        {
            double cont = 0;
            double cantTotal = this.listVen.Count;
            double porcen = 0;
            if (this.listVen != null)
            {
                foreach (Vendedor item in this.listVen)
                {
                    if (item.Genero == EGenero.NoBinario)
                    {
                        cont++;
                    }
                }
                porcen = cont / cantTotal * 100;
            }
            return porcen;
        }

        private double PorcentajeStockVen()
        {
            double cont = 0;
            double cantTotal = this.listVen.Count;
            double porcen = 0;
            if (this.listVen != null)
            {
                foreach (Vendedor item in this.listVen)
                {
                    if (item.Btc >= 1)
                    {
                        cont++;
                    }
                }
                porcen = cont / cantTotal * 100;
            }
            return porcen;
        }
        #endregion
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
            if (a is null || b is null) { } 
            else
            {
                foreach (Vendedor item in a.listVen)
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
            if(a is null || b is null)
            {
                return a;
            }
            else
            {
                if ((a.listVen.Count + 1) <= a.capacidadVen && a != b)
                {
                    a.listVen.Add(b);
                }
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
            if (a is null || b is null) { } else
            {
                foreach (Comprador item in a.listCom)
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
            if(a is null || b is null) { } else
            {
                if (a != b)
                {
                    a.listCom.Add(b);
                }
            }
            return a;
        }
        #endregion

    }
}
