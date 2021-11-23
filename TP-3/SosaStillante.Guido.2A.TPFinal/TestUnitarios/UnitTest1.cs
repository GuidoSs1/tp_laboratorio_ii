using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        Tienda tienda = new Tienda(5, "TiendaGuido");

        Vendedor a1 = new Vendedor("carlos", "rodrigues", 23232332, EGenero.Masculino, 30);
        Vendedor a2 = new Vendedor("marcos", "escobar", "43242424", EGenero.NoBinario, "340");
        Vendedor a6 = new Vendedor("marcelo", "bustos", "434343434", EGenero.Masculino, "5");
        Vendedor a3 = new Vendedor("guido", "sosa", 43784626, EGenero.Masculino, 10);
        Vendedor a4 = new Vendedor("pepe", "martinez", 43784626, EGenero.NoBinario, 310);
        Vendedor a5 = new Vendedor("marto", "gonzales", 23232232, EGenero.Femenino, 90);
        Vendedor a7 = new Vendedor("marto", "gonzales", 23255232, EGenero.Femenino, 90);
        Vendedor a8 = new Vendedor("marto", "gonzales", 23238832, EGenero.Femenino, 90);

        Comprador b1 = new Comprador(33434242, 126000);
        Comprador b2 = new Comprador("guido", "pedro", 23323223, EGenero.Masculino, 63000);
        Comprador b3 = new Comprador("guido", "pedro", 23323223, EGenero.Masculino, 0);
        Comprador b4 = new Comprador("guido", "nopuede", 23323243, EGenero.Masculino, 0);
        Comprador b5 = new Comprador("guido", "pepe", 23323323, EGenero.Masculino, 189000);
        Comprador b6 = new Comprador("marco", "guido", 23323223, EGenero.Masculino, 93000);

        [TestMethod]
        public void TestOperadorIgualVendedores_True()
        {
            Assert.IsTrue(a3 == a4);

            Assert.IsTrue(a1 == a5);
        }

        [TestMethod]
        public void TestOperadorIgualCompradores_False()
        {
            Assert.IsFalse(b2 == b4);

            Assert.IsFalse(b3 == b1);

            Assert.IsFalse(b5 == b6);
        }

        [TestMethod]
        public void TestAgregarVendedor_False()
        {
            tienda += a1;
            tienda += a2;
            tienda += a3;
            tienda += a6;
            tienda += a7;

            tienda += a8; //No espacio

            Assert.IsFalse(tienda == a8);
        }

        [TestMethod]
        public void TestAgregarVendedorNull_False()
        {
            Vendedor ven = null;

            tienda += ven;

            Assert.IsFalse(tienda == ven);
        }

        [TestMethod]
        public void TestAgregarComprador_True()
        {
            tienda += b1;
            tienda += b2;
            tienda += b3; //Igual b2
            tienda += b4;
            tienda += b5;
            tienda += b6; //Igual b2

            Assert.IsTrue(tienda == b1);
            Assert.IsTrue(tienda == b2);
            Assert.IsTrue(tienda == b4);
            Assert.IsTrue(tienda == b5);
        }
    }
}