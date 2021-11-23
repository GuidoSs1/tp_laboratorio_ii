using System;
using System.Windows.Forms;
using Entidades;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using conexionSql;
using System.Threading;
using System.Threading.Tasks;


namespace WinFormsApp
{
    public delegate void delegadoHilo();
    public partial class FormTienda : Form
    {
        Tienda tienda;
        DataBase testDB = new DataBase();
        Task tActualizar;

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

            this.tActualizar = Task.Run(() => this.ActualizarListado());
        }

        /// <summary>
        /// Metodo al presionar el boton comprar, valida que tenga un vendedor de la lista seleccionado y capta una exception de no tenerlo(null) e invoca al form para crear un comprador y realizar una compra por medio del metodo CompraVenta de la clase Tienda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            FormRegistrarComprador frm = null;          
            try
            {
                if (this.lstVendedores.SelectedItem != null)
                {
                    frm = new FormRegistrarComprador();
                }
                else
                {
                    throw new SelectItemException();  
                }
                frm.StartPosition = FormStartPosition.CenterScreen;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Vendedor aux = (Vendedor)this.lstVendedores.SelectedItem;
                    bool confirm = false;
                    if(this.tienda != frm.comprador) { confirm = true; }

                    this.tienda += frm.comprador;

                    this.tienda.CompraVenta(aux, frm.comprador);

                    if (confirm)
                    {
                        this.testDB.ExportarDatos(frm.comprador.Nombre,
                                              frm.comprador.Apellido,
                                              (int)frm.comprador.Dni,
                                              frm.comprador.Nacio,
                                              frm.comprador.Genero,
                                              (int)frm.comprador.Btc,
                                              (int)frm.comprador.Billetera,
                                              "esComprador");
                    }

                    this.testDB.ActualizarDatos(aux);

                    this.ActualizarListado();
                }

            } catch(SelectItemException exc)
            {
                MessageBox.Show(exc.SelectItem());
            }
            
        }

        /// <summary>
        /// Metodo del boton agregar vendedor que instancia el formVendedor para completar los datos y agregar un nuevo vendedor de la lista, cumpliendo con las propias condiciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarVendedor_Click(object sender, EventArgs e)
        {
            FormAgregarVendedor frm = null;
            if (((Button)sender).Name == "btnAgregarVendedor")
            {
                frm = new FormAgregarVendedor();
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if(this.tienda != frm.vendedor) 
                {
                    this.tienda += frm.vendedor;

                    this.testDB.ExportarDatos(frm.vendedor.Nombre,
                                              frm.vendedor.Apellido,
                                              (int)frm.vendedor.Dni,
                                              frm.vendedor.Nacio,
                                              frm.vendedor.Genero,
                                              (int)frm.vendedor.Btc,
                                              (int)frm.vendedor.ganancia,
                                                  "esVendedor");
                }
                
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
                    this.tienda.listVen.Remove(vendedor);

                    this.testDB.EliminarDato((int)vendedor.Dni);
                }
                this.ActualizarListado();
            }
        }

        /// <summary>
        /// Metodo que actualza el listbox, verificando los objetos que se encuentran el la tienda
        /// </summary>
        private void ActualizarListado()
        {
            if (this.lstVendedores.InvokeRequired)
            {
                delegadoHilo delegado = new delegadoHilo(this.ActualizarListado);
                this.Invoke(delegado);
            }
            else
            {
                this.lstVendedores.Items.Clear();

                this.tienda.listVen.ForEach((v) => this.lstVendedores.Items.Add(v));
            }
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
        private void btnDetalleVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstVendedores.SelectedItem != null)
                {
                    Vendedor ven = (Vendedor)this.lstVendedores.SelectedItem;
                    MessageBox.Show(ven.Mostrar());
                }
                else
                {
                    throw new SelectItemException();
                }
            }catch(SelectItemException exc)
            {
                MessageBox.Show(exc.SelectItem());
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

            try
            {
                if (this.testDB.EliminarVendedores())
                {
                    foreach (Vendedor item in this.tienda.listVen)
                    {
                        this.testDB.ExportarDatos(item.Nombre,
                                                  item.Apellido,
                                                  (int)item.Dni,
                                              item.Nacio,
                                              item.Genero,
                                              (int)item.Btc,
                                              (int)item.ganancia,
                                                  "esVendedor");
                    }
                }
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            
            try
            {
                Tienda tiendaAux = new Tienda();

                Xml<Tienda> tiendaGuardada = new Xml<Tienda>();
                string path = Environment.SpecialFolder.MyDocuments + @"\TiendaApps\Xml\Tienda.xml";
                tiendaGuardada.Importar(path, out tiendaAux);
                if (tiendaAux is null)
                {
                    this.tienda = tiendaAux;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            try
            {
                this.tienda = this.testDB.ImportarData();
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            this.ActualizarListado();
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
                if(this.tActualizar.Status == TaskStatus.Running)
                {
                    this.tActualizar.Wait();
                }
                e.Cancel = true;
            }
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(this.tienda.Analizar());
            
        }
    }
}
