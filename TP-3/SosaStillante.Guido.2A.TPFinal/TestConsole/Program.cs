using System;
using Entidades;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Tienda tienda = new Tienda(4);

            Vendedor a1 = new Vendedor("carlos","rodrigues",23232332 , EGenero.Masculino,30);
            Vendedor a2 = new Vendedor("marcos","escobar","43242424",EGenero.NoBinario, "340");
            Vendedor a6 = new Vendedor("marcelo","bustos","434343434",EGenero.Masculino, "5");
            Vendedor a3 = new Vendedor("guido", "sosa", 43784626,EGenero.Masculino, 10);
            Vendedor a4 = new Vendedor("pepe", "martinez", 43784626, EGenero.NoBinario, 310);
            Vendedor a5 = new Vendedor("marto", "gonzales",23232232, EGenero.Femenino, 90);

            tienda += a1;
            tienda += a2;
            tienda += a6;
            tienda += a3;
            tienda += a4;
            tienda += a5;

            Comprador b1 = new Comprador(33434242, 126000);
            Comprador b2 = new Comprador("guido", "pedro", 23323223, EGenero.Masculino, 63000);
            Comprador b3 = new Comprador("guido", "pedro", 23323223, EGenero.Masculino, 0);
            Comprador b4 = new Comprador("guido", "nopuede", 23323243, EGenero.Masculino, 0);
            Comprador b5 = new Comprador("guido", "pepe", 23323323, EGenero.Masculino, 189000);
            Comprador b6 = new Comprador("marco", "guido", 23323223, EGenero.Masculino, 93000);

            tienda += b1;
            tienda += b2;
            try
            {
                tienda += b3;
            }catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            
            tienda += b4;
            tienda += b5;
            tienda += b6;

            Console.WriteLine(tienda.Mostrar());
            Console.ReadKey();

            try
            {
                tienda.CompraVenta(a1, b4);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            tienda.CompraVenta(a2, b5);
            tienda.CompraVenta(a1, b5);
            tienda.CompraVenta(a1, b5);

            try
            {
                tienda.CompraVenta(a1, b5);
            }catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            Console.WriteLine(a1.MostrarCompradores());

            Console.WriteLine(tienda.Mostrar());
            Console.ReadKey();


        }
    }
}
