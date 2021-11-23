using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        // Metodo que le agrega funcionalidad al boton de cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Metodo que da funcionalidad al boton de convertir a decimal
        // Llama al metodo BinarioDecimal de la clase Operando
        // Muestra lo devuelto por ese metodo en el label resultado
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.BinarioDecimal(this.lblResultado.Text);
        }
        // Metodo que da funcionalidad al boton de convertir a binario
        // Llama a la sobrecarga del metodo de DecimalBinario con el parametro string
        // Muestra lo devuelto por ese metodo en el label resultado
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.DecimalBinario(this.lblResultado.Text);
        }
        // Metodo que le da funcion al boton de limpiar
        // Llama al metodo Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        // Metodo que le da funcionalidad al boton de operar
        // Llama al metodo operar pasandole los datos ingresados en los textbox y en el combobox
        // Devuelve el resultado de la operacion en el label resultado y muestra la operacion en el listbox
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double num = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text[0]);
            
            if (num == double.MinValue)
                this.lblResultado.Text = "Operacion no valida";
            else
                this.lblResultado.Text = Convert.ToString(num);

            double n1;
            double n2;
            double.TryParse(this.txtNumero1.Text, out n1);
            double.TryParse(this.txtNumero1.Text, out n2);

            string item = n1.ToString() +" "+ this.cmbOperador.Text+" "+ n2.ToString() +" = "+ this.lblResultado.Text;
            this.lstOperaciones.Items.Add(item);
        }
        // Metodo que incializa la calculadora en blanco
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        // Metodo que detiene el cerrado de la aplicacion para una segunda confirmacion por el usuario
        // De ser afirmativo se cierra la aplicacion, de no serlo continua utilizandola
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de querer salir?", "Salir",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        // Metodo que deja en blanco los campos de textbox, combobox y el label
        #region Metodos
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = " ";
            this.lblResultado.Text = "";
        }
        // Metodo que hace la operacion requerida por el usuario para mostrarla por la interfaz
        // Recibe los numeros ingresados por los textbox y el operador ingresado por combobox
        // Llama al metodo operar de la clase calculadora y le pasa los numeros en objetos de la clase Operando
        // retorna el resultado de la operacion
        private static double Operar(string numero1, string numero2, char operador)
        {
            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);
            return Calculadora.Operar(n1, n2, operador);
        }
        #endregion
    }
}
