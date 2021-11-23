using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Vendedor))]
    [XmlInclude(typeof(Comprador))]
    public abstract class Persona
    {

        #region Atributos
        /// <summary>
        /// Atributos de la clase base persona
        /// </summary>
        protected string nombre;
        protected string apellido;
        protected long dni;
        protected EGenero genero;
        protected ENacionalidad nacio;
        #endregion

        #region Prop

        /// <summary>
        /// Propiedades de lectura para los atributos de la clase
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }
        public long Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }
        public EGenero Genero
        {
            get { return this.genero; }
            set { this.genero = value; }
        }
        public ENacionalidad Nacio
        {
            get { return this.nacio; }
            set { this.nacio = value; }
        }

        /// <summary>
        /// Propiedad que valida el documento que se quiere asignar al atributo
        /// </summary>
        public string stringDNI
        {
            set
            {
                this.dni = ValidarDni(value);
            }
        }
        #endregion

        #region Constructores
        
        /// <summary>
        /// Constructor por defecto que invoca a la sobrecarga pasandole como parametros valores predeterminados
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Sobrecarga de constructo completo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="genero"></param>
        public Persona(string nombre, string apellido, long dni, EGenero genero, ENacionalidad nacio)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.genero = genero;
            this.nacio = nacio;
        }

        /// <summary>
        /// Sobrecarga de constructor completo con dni de tipo string
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="genero"></param>
        public Persona(string nombre, string apellido, string dni, EGenero genero,ENacionalidad nacio) : this(nombre,apellido,0,genero,nacio)
        {
            this.stringDNI = dni;
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Sobrecarga del operador '==' entre objetos del tipo persona o derivados
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>retorna true si el documento de ambas personas es igual, false en caso contrario</returns>
        public static bool operator ==(Persona a, Persona b)
        {
            bool rtn = false;
            if (a is null || b is null) { } else
            {
                if (a.dni == b.dni && a.nacio == b.nacio)
                {
                    rtn = true;
                }
            }
            return rtn;
        }

        /// <summary>
        /// Sobrecarga del operador '!='
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Retorna true si los obejtos son diferentes, false de caso contrario</returns>
        public static bool operator !=(Persona a, Persona b)
        {
            return !(a == b);
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Sobrecarga del metodo ToString, forma una cadena con los datos nombre, apellido y genero de la persona
        /// </summary>
        /// <returns>Datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\n\nNombre: {0}    \nApellido: {1}   \nGenero: {2} \nNacionalidad: {3}",
                this.nombre, this.apellido, this.genero, this.nacio);
            return sb.ToString();
        }

        /// <summary>
        /// Metodo estaticos que valida que el string pasado por parametro sea un double
        /// </summary>
        /// <param name="dString"></param>
        /// <returns>Retorna el string parseado a double de serlo, en caso contrario 0</returns>
        public static double ValidarDouble(string dString)
        {
            double money;
            Double.TryParse(dString, out money);
            return money;
        }

        /// <summary>
        /// Metodo privado que valida que el string documento pasado por parametro sea correcto
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Retorna el documento en int32, en caso contrario -1</returns>
        private int ValidarDni(string dato)
        {
            int numeroDni = 0;
            if (dato.Length >= 7 && dato.Length <= 10)
            {
                Int32.TryParse(dato, out numeroDni);
            }
            return numeroDni;
        }

        #endregion



    }
}
