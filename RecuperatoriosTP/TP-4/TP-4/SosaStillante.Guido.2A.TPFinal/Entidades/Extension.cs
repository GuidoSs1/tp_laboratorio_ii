using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extension
    {
        public static string DatosIncorrectos(this DatosIncorrectException exc)
        {
            return "Datos ingresados inconrrectamente. \nPor favor, vuelva a intentarlo.";
        }

        public static string NoSeAgrego(this NoAddException exc)
        {
            return "No se pudo agregar el vendedor.";
        }

        public static string SelectItem(this SelectItemException exc)
        {
            return "Seleccione un item valido en la lista.";
        }

    }
}
