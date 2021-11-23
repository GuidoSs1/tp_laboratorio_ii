using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace WinFormsApp
{
    public partial class FormAgregarVendedor : Form
    {
        public Vendedor vendedor;

        /// <summary>
        /// Contructor del form que inicializa el combobox con los valores del enumerado de genero
        /// </summary>
        public FormAgregarVendedor()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.cboGenero.DataSource = Enum.GetValues(typeof(EGenero));
            this.cboGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboGenero.SelectedItem = EGenero.NoBinario;

            this.cboNacionalidad.DataSource = Enum.GetValues(typeof(ENacionalidad));
            this.cboNacionalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboNacionalidad.SelectedItem = ENacionalidad.Argentina;
        }

        /// <summary>
        /// Metodo que controla los datos ingresados por el usuario para agregar un vendedor, de no llenar todos los campos se cancelara la accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            double btc;
            Double.TryParse(this.txtBtc.Text, out btc);
            int dni;
            Int32.TryParse(this.txtDocumento.Text, out dni);
            int name;
            Int32.TryParse(this.txtApellido.Text, out name);
            int surname;
            Int32.TryParse(this.txtNombre.Text, out surname);

            try
            {
                if (btc == 0 || dni == 0)
                {
                    throw new DatosIncorrectException();
                    
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(this.txtNombre.Text) || String.IsNullOrWhiteSpace(this.txtApellido.Text) || String.IsNullOrWhiteSpace(this.cboGenero.Text) || String.IsNullOrWhiteSpace(this.cboNacionalidad.Text))
                    {
                        throw new DatosIncorrectException();
                        
                    }
                    else
                    {

                        if (name == 0 && surname == 0)
                        {
                            this.vendedor = new Vendedor(this.txtNombre.Text, this.txtApellido.Text,
                                    this.txtDocumento.Text, (EGenero)this.cboGenero.SelectedItem, this.txtBtc.Text, (ENacionalidad)this.cboNacionalidad.SelectedItem);
                        }
                        else
                        {
                            throw new DatosIncorrectException();
                            
                        }

                    }

                    this.DialogResult = DialogResult.OK;
                }
            }catch(DatosIncorrectException exc) { MessageBox.Show(exc.DatosIncorrectos()); this.DialogResult = DialogResult.Cancel; }
            

        }

        /// <summary>
        /// Cancela la accion y cierra el formulario
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
