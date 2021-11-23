using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        // Constructor de la clase ciclomotor que reutiliza el constructor de la clase base
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
        }
        
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        // Muestra los datos del ciclcomotor
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.Append(base.Mostrar());
            sb.AppendLine(String.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
