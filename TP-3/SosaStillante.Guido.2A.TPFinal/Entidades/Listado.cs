using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Listado<T>
    {
        /// <summary>
        /// Atributos de la clase generica
        /// </summary>
        public int capacidadMaxima;
        public List<T> lista;

        /// <summary>
        /// Constructor por defecto que inicializa el atributo lista
        /// </summary>
        public Listado() 
        {
            this.lista = new List<T>();
        }

        /// <summary>
        /// Sobrecarga del constructor con parametro de cantidad maxima de objetos para el atributo lista
        /// </summary>
        /// <param name="capacidad">Capacidad del atributo lista</param>
        public Listado(int capacidad)
        {
            this.lista = new List<T>();
            this.capacidadMaxima = capacidad;
        }

        /// <summary>
        /// Propiedad que devuelve la cantidad de objetos que tiene la lista
        /// </summary>
        public int Cantidad
        {
            get { return lista.Count; }
        }

        /// <summary>
        /// Propiedad que devuelve la lista para acceder a sus metodos
        /// </summary>
        public List<T> Lista
        {
            get { return this.lista; }
        }

        /// <summary>
        /// Sobrecarga de operador que permite la adision de un objeto del tipo que maneja la clase generica al atributo de tipo lista si posee espacio
        /// </summary>
        /// <param name="d">objeto generico</param>
        /// <param name="a">Objeto del tipo que acepta el objeto genrico</param>
        /// <returns></returns>
        public static bool operator +(Listado<T> d, T a)
        {
            bool rtn = false;
            if (d is not null && a is not null)
            {
                if (d.capacidadMaxima > d.lista.Count)
                {
                    d.lista.Add(a);
                    rtn = true;
                }
            }
            return rtn;
        }

        /// <summary>
        /// Metodo que obtiene el indice dentro del atributo del tipo lista si es que se encuentra en la misma
        /// </summary>
        /// <param name="a">Objeto del cual se quiere obtener el indice</param>
        /// <returns></returns>
        public int GetIndice(T a)
        {
            int rtn = -1;
            if (a is not null)
            {
                foreach (T item in this.lista)
                {
                    if (lista.Contains(a))
                    {
                        rtn = lista.IndexOf(a);
                    }
                }
            }
            return rtn;
        }

        /// <summary>
        /// Sobrecarga del operador de sustraccion, elimina de la lista el objeto pasado por parametros de encontrarse en la misma
        /// </summary>
        /// <param name="d">Objeto generico</param>
        /// <param name="a">Objeto del tipo que acepta la lista</param>
        /// <returns></returns>
        public static bool operator -(Listado<T> d, T a)
        {
            bool rtn = false;
            if (d is not null && a is not null)
            {
                if (d.GetIndice(a) != -1)
                {
                    d.lista.Remove(a);
                    rtn = true;
                }
            }
            return rtn;
        }

        /// <summary>
        /// Metodo que llama a la sobrecarga de adicion para agregar el objeto pasado por parametro a la lista
        /// </summary>
        /// <param name="a">Objeto a agregar</param>
        /// <returns></returns>
        public bool Agregar(T a)
        {
            return (this + a);
        }

        /// <summary>
        /// Metodo que llama a la sobrecarga de sustraccion para eliminar el objeto pasado por parametro de la lista
        /// </summary>
        /// <param name="a">Obejto a eliminar</param>
        /// <returns></returns>
        public bool Remover(T a)
        {
            return (this - a);
        }
    }
}
