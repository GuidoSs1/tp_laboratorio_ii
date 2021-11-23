using System;
using System.Windows.Forms;
using Entidades;

namespace WinFormsApp
{
    public partial class FormComprar : Form
    {
        public Comprador comprador;

        /// <summary>
        /// Se inicializan los controles con el constructor por defecto
        /// </summary>
        public FormComprar()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.cboCompradorGenero.DataSource = Enum.GetValues(typeof(EGenero));
            this.cboCompradorGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCompradorGenero.SelectedItem = EGenero.SinGenero;
        }

        /// <summary>
        /// Metodo que controla el boton aceptar, verificando los datos ingresados por el usuario, siendo el documento y la billetera datos obligatorios si la billetera no contiene por lo menos 63000 no podra realizar la compra minima de 1 BTC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            double bille;
            Double.TryParse(this.txtBilletera.Text, out bille);
            int dni;
            Int32.TryParse(this.txtDocumento.Text, out dni);
            int name;
            Int32.TryParse(this.txtNombre.Text, out name);
            int surname;
            Int32.TryParse(this.txtApellido.Text, out surname);

            if(bille == 0 || dni == 0)
            {
                MessageBox.Show("Datos Incorrectos. Vuelva a Intentarlo");
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                if(Int64.Parse(this.txtBilletera.Text) >= 63000)
                {
                    if (String.IsNullOrWhiteSpace(this.txtNombre.Text) || String.IsNullOrWhiteSpace(this.txtApellido.Text) || String.IsNullOrWhiteSpace(this.cboCompradorGenero.Text))
                    {
                        MessageBox.Show("Datos Incorrectos. Vuelva a Intentarlo");
                        this.DialogResult = DialogResult.Cancel;
                    }
                    else
                    {
                        if(name == 0 && surname == 0)
                        {
                            this.comprador = new Comprador(this.txtNombre.Text, this.txtApellido.Text,
                                    this.txtDocumento.Text, (EGenero)this.cboCompradorGenero.SelectedItem, this.txtBilletera.Text);
                        }
                        else
                        {
                            MessageBox.Show("Datos Incorrectos. Vuelva a Intentarlo");
                            this.DialogResult = DialogResult.Cancel;
                        }
                        
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No tiene dinero suficiente para realizar la compra minima.(1 BTC)");
                    this.DialogResult = DialogResult.Cancel;
                }
                
            }
            
        }

        /// <summary>
        /// Metodo que controla el boton cancelar, cerrando el formulario y cancelando la operacion
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
