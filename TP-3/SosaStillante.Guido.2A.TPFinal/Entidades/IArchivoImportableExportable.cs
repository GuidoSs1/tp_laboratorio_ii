using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface IArchivoImportableExportable<T>
    {
        bool Exportar(T datos);
        bool Importar(string path, out T datos);
    }
}
