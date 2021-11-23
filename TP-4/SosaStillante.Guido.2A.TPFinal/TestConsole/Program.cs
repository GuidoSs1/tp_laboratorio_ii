using System;
using Entidades;
using conexionSql;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tienda tienda = new Tienda(4);

            //Vendedor a1 = new Vendedor("carlos","rodrigues",23232332 , EGenero.Masculino,30, ENacionalidad.Argentina);
            //Vendedor a2 = new Vendedor("marcos", "escobar", "43242424", EGenero.NoBinario, "340", ENacionalidad.Chile);
            //Vendedor a3 = new Vendedor("guido", "sosa", 43784626,EGenero.Masculino, 10,ENacionalidad.Argentina);
            //Vendedor a4 = new Vendedor("pepe", "martinez", 43784626, EGenero.NoBinario, 310,ENacionalidad.Argentina);
            //Vendedor a5 = new Vendedor("marto", "gonzales",23232232, EGenero.Femenino, 90,ENacionalidad.Uruguay);
            //Vendedor a6 = new Vendedor("marcelo", "bustos", "434343434", EGenero.Masculino, "5", ENacionalidad.Peru);

            //tienda += a1;
            //tienda += a2;
            //tienda += a6;
            //tienda += a3;
            //tienda += a4;

            //try
            //{
            //    tienda += a5;
            //    if (tienda != a5) { throw new NoAddException(); }
            //}
            //catch (NoAddException exc)
            //{
            //    Console.WriteLine(exc.NoSeAgrego());
            //}

            //Comprador b1 = new Comprador("mirco", "sanchez", 33434242, EGenero.Masculino, 126000,ENacionalidad.Argentina);
            //Comprador b2 = new Comprador("guido", "pedro", 23323223, EGenero.Masculino, 63000,ENacionalidad.Uruguay);
            //Comprador b3 = new Comprador("guido", "pedro", 23323223, EGenero.Masculino, 0,ENacionalidad.Uruguay);
            //Comprador b4 = new Comprador("guido", "nopuede", 23323243, EGenero.Masculino, 0,ENacionalidad.Paraguay);
            //Comprador b5 = new Comprador("guido", "pepe", 23323323, EGenero.Masculino, 189000,ENacionalidad.Peru);
            //Comprador b6 = new Comprador("marco", "guido", 23323223, EGenero.Masculino, 93000,ENacionalidad.Chile);

            //tienda += b1;
            //tienda += b2;
            //tienda += b3;
            //tienda += b4;
            //tienda += b5;
            //tienda += b6;

            //Console.WriteLine(tienda.Mostrar());

            //Console.WriteLine(tienda.Analizar());

            //Console.ReadKey();

            //tienda.CompraVenta(a1, b4);
            //tienda.CompraVenta(a2, b5);
            //tienda.CompraVenta(a1, b5);
            //tienda.CompraVenta(a1, b5);
            //tienda.CompraVenta(a1, b5);

            //if (b5.Btc == 3)
            //{
            //    Console.WriteLine("El comprador 'b5' NO pudo realizar la ultima compra");
            //}


            //Console.WriteLine(a1.MostrarCompradores());

            //Test Base de Datos

            Tienda tienda = new Tienda();
            DataBase testDB = new DataBase();

            if (testDB.ProbarConexion()) { Console.WriteLine("hola"); }

            tienda = testDB.ImportarData();

            Console.WriteLine(tienda.Mostrar());

            //tienda += new Vendedor("carlos", "rodrigues", 23232332, EGenero.Masculino, 30, ENacionalidad.Argentina);
            //tienda += new Comprador("mirco", "sanchez", 33434242, EGenero.Masculino, 126000, ENacionalidad.Argentina);

            bool prueba;

            //prueba = testDB.ExportarDatos("mirco", "sanchez", 33434242, ENacionalidad.Argentina, EGenero.Masculino, 0, 126000, "esComprador");

            prueba = testDB.EliminarDato(33434242);

            //if (prueba == true) { Console.WriteLine("Se agrego exitosamente"); }
            if (prueba == true) { Console.WriteLine("Se elimino exitosamente"); }

            Console.ReadKey();


        }
    }
}
