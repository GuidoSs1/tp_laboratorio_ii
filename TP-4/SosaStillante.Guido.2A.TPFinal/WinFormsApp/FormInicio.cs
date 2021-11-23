using System;
using System.Windows.Forms;
using Entidades;


namespace WinFormsApp
{
    public partial class FormInicio : Form
    {
        private Tienda tienda;
        public Tienda TiendaDelForm { get { return this.tienda; } }

        /// <summary>
        /// Constructor por defecto del formulario de inicio
        /// </summary>
        public FormInicio()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        /// <summary>
        /// Metodo que controla el boton aceptar, verificando los datos ingresados, de no ser correctos se iniciara una tienda de forma predeterminada, de contrario con el nombre y capacidad requerida(capta excepciones de formato)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            string nombre = this.txtNombre.Text;
            string cantMax = this.txtCantMax.Text;

            if (String.IsNullOrWhiteSpace(nombre) && String.IsNullOrWhiteSpace(cantMax))
            {
                this.tienda = new Tienda("TiendaCrypto");
                MessageBox.Show("Se inicializara de forma predeterminada TiendaCrypto, capacidad para 5 vendedores..");
            }
            else if (!String.IsNullOrWhiteSpace(nombre) && String.IsNullOrWhiteSpace(cantMax))
            {
                this.tienda = new Tienda(nombre);
            }
            else if (!String.IsNullOrWhiteSpace(nombre) && !String.IsNullOrWhiteSpace(cantMax))
            {
                try
                {
                    this.tienda = new Tienda(Int32.Parse(cantMax), nombre);
                }catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    MessageBox.Show("Se inicializara de forma predeterminada TiendaCrypto, capacidad para 10 vendedores..");
                    this.tienda = new Tienda("TiendaCrypto");
                }
            }
            else if (String.IsNullOrWhiteSpace(nombre) && !String.IsNullOrWhiteSpace(cantMax))
            {
                try
                {
                    this.tienda = new Tienda(Int32.Parse(cantMax));
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    MessageBox.Show("Se inicializara de forma predeterminada TiendaCrypto, capacidad para 10 vendedores..");
                    this.tienda = new Tienda("TiendaCrypto");
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }

        }

        /// <summary>
        /// Metodo que controla el boton cancelar, cerrando el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
