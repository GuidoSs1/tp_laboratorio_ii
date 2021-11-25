using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace conexionSql
{
    public class DataBase
    {

        /// <summary>
        /// Definicion de Objetos de conexion, comando y data reader para el manejo de la base de datos
        /// </summary>
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;


        /// <summary>
        /// Constructor por defecto que conecta la base de datos con el servidor local y la base de datos con nombre TpCuatroDB e instancia el objeto comando
        /// </summary>
        public DataBase()
        {
            this.conexion = new SqlConnection("Server = .; Database = TpCuatroDB; Trusted_Connection = True");
            this.comando = new SqlCommand();
        }


        /// <summary>
        /// Metodo que prueba la conexion con la base de datos
        /// </summary>
        /// <returns>retorna true si fue posible la conexion, false si hubo una excepcion</returns>
        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }


        /// <summary>
        /// Metodo que ejecuta una query para que el lector obtenga la informacion o datos de la base de datos
        /// </summary>
        /// <returns>retorna la tienda con los datos de la base cargados o sin datos por una excepcion</returns>
        public Tienda ImportarData()
        {
            Tienda auxTienda = new Tienda("TiendaPrueba");

            EGenero genero;
            ENacionalidad nacio;

            this.comando.CommandType = CommandType.Text;
            this.comando.Connection = conexion;
            this.comando.CommandText = "SELECT nombre,apellido,documento,nacionalidad,genero,btc,ganancia,tipoObjeto FROM dbo.tienda";

            try
            {
                if (this.conexion.State != ConnectionState.Open)
                {
                    this.conexion.Open();
                }

                lector = this.comando.ExecuteReader();

                while (this.lector.Read())
                {
                    if((this.lector["tipoObjeto"].ToString()).Equals("esVendedor")) 
                    {
                        Vendedor auxVendedor = new Vendedor();

                        ENacionalidad.TryParse(this.lector["nacionalidad"].ToString(), out nacio);
                        EGenero.TryParse(this.lector["genero"].ToString(), out genero);

                        auxVendedor.Nombre = this.lector["nombre"].ToString();
                        auxVendedor.Apellido = this.lector["apellido"].ToString();
                        auxVendedor.stringDNI = this.lector["documento"].ToString();
                        auxVendedor.Nacio = nacio;
                        auxVendedor.Genero = genero;
                        auxVendedor.btcString = this.lector["btc"].ToString();
                        auxVendedor.ganString = this.lector["ganancia"].ToString();


                        auxTienda.listVen.Add(auxVendedor);
                    }
                    else
                    {
                        Comprador auxComprador = new Comprador();

                        ENacionalidad.TryParse(this.lector["nacionalidad"].ToString(), out nacio);
                        EGenero.TryParse(lector["genero"].ToString(), out genero);

                        auxComprador.Nombre = this.lector["nombre"].ToString();
                        auxComprador.Apellido = this.lector["apellido"].ToString();
                        auxComprador.stringDNI = this.lector["documento"].ToString();
                        auxComprador.Nacio = nacio;
                        auxComprador.Genero = genero;
                        auxComprador.btcString = this.lector["btc"].ToString();
                        auxComprador.BilleteraUsd = this.lector["ganancia"].ToString();


                        auxTienda.listCom.Add(auxComprador);
                    }
                    
                    
                }

                
            }
            catch(SqlException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return auxTienda;
        }

        /// <summary>
        /// Metodo que transporta los datos de un vendedor o comprador ingresados en el progrma a la base de datos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="genero"></param>
        /// <param name="btc"></param>
        /// <param name="usd"></param>
        /// <param name="tipoObjeto"></param>
        /// <returns>retorna true si pudo hacerlo correctamente o flase si hubo alguna excepcion</returns>
        public bool ExportarDatos(string nombre, string apellido, int dni, ENacionalidad nacionalidad, EGenero genero, int btc, int usd, string tipoObjeto)
        {
            bool rtn = false;

            try
            {
                this.comando.Connection = this.conexion;
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "INSERT INTO dbo.tienda (nombre,apellido,documento,nacionalidad,genero,btc,ganancia,tipoObjeto) VALUES (@nombre,@apellido,@documento,@nacionalidad,@genero,@btc,@ganancia,@tipoObjeto)";
                
                
                this.comando.Parameters.AddWithValue("@nombre", nombre);
                this.comando.Parameters.AddWithValue("@apellido", apellido);
                this.comando.Parameters.AddWithValue("@documento", dni);
                this.comando.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                this.comando.Parameters.AddWithValue("@genero", genero);
                this.comando.Parameters.AddWithValue("@btc", btc);
                this.comando.Parameters.AddWithValue("@ganancia", usd);
                this.comando.Parameters.AddWithValue("@tipoObjeto", tipoObjeto);


                if (this.conexion.State != ConnectionState.Open)
                {
                    this.conexion.Open();
                    this.comando.ExecuteNonQuery();
                    rtn = true;
                }

            }catch(SqlException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                if(this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rtn;
        }

        /// <summary>
        /// Metodo que elimina un elemento de la base de datos por medio de el numero de documento
        /// </summary>
        /// <param name="documento"></param>
        /// <returns>retorna true si pudo hacerlo correctamente o flase si hubo alguna excepcion</returns>
        public bool EliminarDato(int documento)
        {
            bool rtn = false;

            try
            {
                this.comando.Connection = this.conexion;
                this.comando.CommandType = CommandType.Text;

                this.comando.CommandText = "DELETE FROM dbo.tienda WHERE documento = @documento";

                this.comando.Parameters.AddWithValue("@documento", documento);

                if(this.conexion.State != ConnectionState.Open)
                {
                    this.conexion.Open();
                    this.comando.ExecuteNonQuery();
                    rtn = true;
                }

            }catch(SqlException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                if(this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }


            return rtn;
        }

        /// <summary>
        /// Metodo que actualiza los datos de un vendedor para cuuando realiza una compra
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns>retorna true si pudo hacerlo correctamente o flase si hubo alguna excepcion</returns>
        public bool ActualizarDatos(Vendedor vendedor)
        {
            bool rtn = false;

            try
            {
                this.comando.Connection = this.conexion;
                this.comando.CommandType = CommandType.Text;

                this.comando.CommandText = "UPDATE dbo.tienda btc=@btc,ganancia=@ganancia WHERE documento = @documento";

                this.comando.Parameters.AddWithValue("@btc", vendedor.Btc);
                this.comando.Parameters.AddWithValue("@ganancia", vendedor.ganancia);
                this.comando.Parameters.AddWithValue("@documento", vendedor.Dni);

                if (this.conexion.State != ConnectionState.Open)
                {
                    this.conexion.Open();
                    this.comando.ExecuteNonQuery();
                    rtn = true;
                }

            }
            catch(SqlException exc)
            {
                Console.WriteLine(exc);
            }


            return rtn;
        }

        /// <summary>
        /// Metodo para eliminar a los vendedores de la base de datos para evitar que los mismos sean cargados repetidamente
        /// </summary>
        /// <returns>retorna true si pudo hacerlo correctamente o flase si hubo alguna excepcion</returns>
        public bool EliminarVendedores()
        {
            bool rtn = false;

            try
            {
                this.comando.Connection = this.conexion;
                this.comando.CommandType = CommandType.Text;

                this.comando.CommandText = "DELETE FROM dbo.tienda WHERE tipoObjeto = @tipoObjeto";

                this.comando.Parameters.AddWithValue("@tipoObjeto", "esVendedor");

                if (this.conexion.State != ConnectionState.Open)
                {
                    this.conexion.Open();
                    this.comando.ExecuteNonQuery();
                    rtn = true;
                }

            }
            catch (SqlException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }


            return rtn;
        }

    }
}
