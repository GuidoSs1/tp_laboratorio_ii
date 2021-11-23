using System;
using System.Windows.Forms;
using Entidades;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace WinFormsApp
{
    public partial class FormTienda : Form
    {
        Tienda tienda;

        public FormTienda()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sobrecarga del constructor con tienda por parametro, instancia la tienda pasada por el formInicio y el ComboBox con los valores del enumerado de ordenamiento
        /// </summary>
        /// <param name="tienda"></param>
        public FormTienda(Tienda tienda)
            : this()
        {
            this.tienda = tienda;
            this.groupBox1.Text = this.tienda.Nombre;

            this.cboOrdenamiento.DataSource = Enum.GetValues(typeof(EOrdenamiento));
            this.cboOrdenamiento.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboOrdenamiento.SelectedItem = EOrdenamiento.Nombre; 
        }

        /// <summary>
        /// Metodo al presionar el boton comprar, valida que tenga un vendedor de la lista seleccionado y capta una exception de no tenerlo(null) e invoca al form para crear un comprador y realizar una compra por medio del metodo CompraVenta de la clase Tienda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            FormComprar frm = null;
            if (this.lstVendedores.SelectedItem != null)
            {
                frm = new FormComprar();
            }
            try
            {
                frm.StartPosition = FormStartPosition.CenterScreen;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.tienda += frm.comprador;
                    this.tienda.CompraVenta((Vendedor)this.lstVendedores.SelectedItem, frm.comprador);
                    this.ActualizarListado();
                }

            } catch(Exception)
            {
                MessageBox.Show("Seleccione un vendedor valido.");
            } 
        }

        /// <summary>
        /// Metodo del boton agregar vendedor que instancia el formVendedor para completar los datos y agregar un nuevo vendedor de la lista, cumpliendo con las propias condiciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarVendedor_Click(object sender, EventArgs e)
        {
            FormVendedor frm = null;
            if (((Button)sender).Name == "btnAgregarVendedor")
            {
                frm = new FormVendedor();
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.tienda += frm.vendedor;
                this.ActualizarListado();
            }
        }

        /// <summary>
        /// Metodo del boton quitar vendedor, que elimina el vendedor seleccionado de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitarVendedor_Click(object sender, EventArgs e)
        {
            if (this.lstVendedores.SelectedItem != null)
            {
                Vendedor vendedor = (Vendedor)this.lstVendedores.SelectedItem;
                if (MessageBox.Show("¿Esta seguro que quiere eliminar al vendedor seleccionado?", "Atención",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.tienda.listVen.Lista.Remove(vendedor);
                }
                this.ActualizarListado();
            }
        }

        /// <summary>
        /// Metodo que actualza el listbox, verificando los objetos que se encuentran el la tienda
        /// </summary>
        private void ActualizarListado()
        {
            this.lstVendedores.Items.Clear();

            foreach (Vendedor item in this.tienda.listVen.Lista)
            {
                this.lstVendedores.Items.Add(item);
            }

            this.LimpiarDetalle();
        }

        /// <summary>
        /// Metodo que limpia el groupbox del detalle al momento de actualizar la lista
        /// </summary>
        private void LimpiarDetalle()
        {
            this.txtDetalleVendedor.Text = "";
            this.txtGanancia.Text = "";
        }

        /// <summary>
        /// Metodo de ordenamiento de la lista de vendedores, teniendo en cuenta el combobox que cuenta con las opciones de enum EOrdenamiento y los metodos de la clase tienda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboOrdenamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((EOrdenamiento)this.cboOrdenamiento.SelectedItem)
            {
                case EOrdenamiento.Nombre:
                    this.tienda.OrdenarListadoVend(EOrdenamiento.Nombre);
                    break;
                case EOrdenamiento.MayorGanancia:
                    this.tienda.OrdenarListadoVend(EOrdenamiento.MayorGanancia);
                    break;
                case EOrdenamiento.Apellido:
                    this.tienda.OrdenarListadoVend(EOrdenamiento.Apellido);
                    break;
                case EOrdenamiento.CantCompradores:
                    this.tienda.OrdenarListadoVend(EOrdenamiento.CantCompradores);
                    break;
                default:
                    break;
            }

            this.ActualizarListado();
        }

        /// <summary>
        /// Metodo que muestra en el groupbox de detalle la informacion completa del objeto vendedor seleccionado en el listado, capta una excepcion si no hay objeto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstVendedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vendedor vendedor = (Vendedor)this.lstVendedores.SelectedItem;
            try
            {
                this.txtDetalleVendedor.Text = vendedor.Mostrar();
                this.txtGanancia.Text = string.Format("{0:C}", vendedor.ganancia);
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        /// <summary>
        /// Metodo que muestra todos los compradores que tuvo la tienda por medio de un messagebox y el metodo de la clase tienda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarAllCompradores_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.tienda.MostrarCompradores());
        }

        /// <summary>
        /// Metodo que muestra los compradores del vendedor seleccionado en la listbox, en un messagebox y con el metodo de la clase vendedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarCompradoreDelVen_Click(object sender, EventArgs e)
        {
            if(this.lstVendedores.SelectedItem != null)
            {
                Vendedor ven = (Vendedor)this.lstVendedores.SelectedItem;
                MessageBox.Show(ven.MostrarCompradores());
            }
        }

        private void btnGuardarProgreso_Click(object sender, EventArgs e)
        {
            try
            {
                Xml<Tienda> tiendaAGuardar = new Xml<Tienda>();
                tiendaAGuardar.Exportar(this.tienda);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            MessageBox.Show("Serializado con exito.");
        }

        /// <summary>
        /// Metodo de cierre de la aplicacion que confirma la intencion del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la tienda?", "Atención",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
