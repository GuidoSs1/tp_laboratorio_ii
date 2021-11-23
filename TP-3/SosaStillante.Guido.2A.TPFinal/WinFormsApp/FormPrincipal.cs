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
        }

        /// <summary>
        /// Carga el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {

            Xml<Tienda> tiendaGuardada = new Xml<Tienda>();
            try
            {
                tiendaGuardada.Importar(Environment.SpecialFolder.MyDocuments + @"\TiendaApps\Xml\Tienda.xml", out this.tienda);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
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
