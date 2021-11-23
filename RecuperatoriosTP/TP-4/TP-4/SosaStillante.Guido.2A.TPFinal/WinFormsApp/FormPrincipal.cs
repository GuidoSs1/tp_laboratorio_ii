using System;
using System.Windows.Forms;
using Entidades;
using System.Xml.Serialization;
using System.Xml;

namespace WinFormsApp
{
    public partial class FormPrincipal : Form
    {
        protected Tienda tienda;

        public FormPrincipal()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Carga el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Normal;
            
        }

        /// <summary>
        /// Metodo que maneja el boton del menu crear, abriendo un formulario de incio para crear una tienda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tiendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.tienda is null)
            {
                FormInicio frm = new FormInicio();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.tienda = frm.TiendaDelForm;

                    //Se agregan tres vendedores para hacer mas rapidas las pruebas a pedido del docente 
                    // SE DEBERA GUARDAR PARA QUE SE REGISTREN EN LA BASE DE DATOS, LOS INGRESADOS MANUALMENTE SE AGREGAN AL AGREGAR VENDEDOR O COMPRAR

                    this.tienda += new Vendedor("carlos", "rodrigues", 23232332, EGenero.Masculino, 30, ENacionalidad.Argentina);
                    this.tienda += new Vendedor("marcos", "escobar", "43242424", EGenero.NoBinario, "340", ENacionalidad.Chile);
                    this.tienda += new Vendedor("guido", "sosa", 43784626, EGenero.Masculino, 10, ENacionalidad.Argentina);

                    FormTienda frmV = new FormTienda(this.tienda);
                    frmV.StartPosition = FormStartPosition.CenterScreen;

                    frmV.MdiParent = this;

                    frmV.Show();
                }
            } else
            {
                FormTienda frmV = new FormTienda(this.tienda);
                frmV.StartPosition = FormStartPosition.CenterScreen;

                frmV.MdiParent = this;

                frmV.Show();
            }
            
        }

        /// <summary>
        /// Metodo del boton salir que llama al metodo de cierre del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo de cierre del formulario que confirma la decision del usuario a treves de un messagebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Atención",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {   
                e.Cancel = true;
            }
        }

    }
}
