
namespace WinFormsApp
{
    partial class FormTienda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstVendedores = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboOrdenamiento = new System.Windows.Forms.ComboBox();
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnQuitarVendedor = new System.Windows.Forms.Button();
            this.btnAgregarVendedor = new System.Windows.Forms.Button();
            this.btnDetallarVen = new System.Windows.Forms.Button();
            this.btnlistarAllCom = new System.Windows.Forms.Button();
            this.btnGuardarProgreso = new System.Windows.Forms.Button();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.btnCargarDatos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstVendedores);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 330);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colocar el nombre de la tienda aquí";
            // 
            // lstVendedores
            // 
            this.lstVendedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVendedores.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstVendedores.FormattingEnabled = true;
            this.lstVendedores.ItemHeight = 17;
            this.lstVendedores.Location = new System.Drawing.Point(3, 19);
            this.lstVendedores.Name = "lstVendedores";
            this.lstVendedores.Size = new System.Drawing.Size(533, 308);
            this.lstVendedores.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(557, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Ordenamiento:";
            // 
            // cboOrdenamiento
            // 
            this.cboOrdenamiento.FormattingEnabled = true;
            this.cboOrdenamiento.Location = new System.Drawing.Point(557, 31);
            this.cboOrdenamiento.Name = "cboOrdenamiento";
            this.cboOrdenamiento.Size = new System.Drawing.Size(171, 23);
            this.cboOrdenamiento.TabIndex = 3;
            this.cboOrdenamiento.SelectedIndexChanged += new System.EventHandler(this.cboOrdenamiento_SelectedIndexChanged);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(304, 348);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(200, 42);
            this.btnComprar.TabIndex = 2;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnQuitarVendedor
            // 
            this.btnQuitarVendedor.Location = new System.Drawing.Point(568, 92);
            this.btnQuitarVendedor.Name = "btnQuitarVendedor";
            this.btnQuitarVendedor.Size = new System.Drawing.Size(151, 42);
            this.btnQuitarVendedor.TabIndex = 4;
            this.btnQuitarVendedor.Text = "Quitar Vendedor";
            this.btnQuitarVendedor.UseVisualStyleBackColor = true;
            this.btnQuitarVendedor.Click += new System.EventHandler(this.btnQuitarVendedor_Click);
            // 
            // btnAgregarVendedor
            // 
            this.btnAgregarVendedor.Location = new System.Drawing.Point(56, 348);
            this.btnAgregarVendedor.Name = "btnAgregarVendedor";
            this.btnAgregarVendedor.Size = new System.Drawing.Size(195, 42);
            this.btnAgregarVendedor.TabIndex = 1;
            this.btnAgregarVendedor.Text = "Agregar vendedor";
            this.btnAgregarVendedor.UseVisualStyleBackColor = true;
            this.btnAgregarVendedor.Click += new System.EventHandler(this.btnAgregarVendedor_Click);
            // 
            // btnDetallarVen
            // 
            this.btnDetallarVen.Location = new System.Drawing.Point(568, 149);
            this.btnDetallarVen.Name = "btnDetallarVen";
            this.btnDetallarVen.Size = new System.Drawing.Size(151, 42);
            this.btnDetallarVen.TabIndex = 5;
            this.btnDetallarVen.Text = "Detalle del Vendedor";
            this.btnDetallarVen.UseVisualStyleBackColor = true;
            this.btnDetallarVen.Click += new System.EventHandler(this.btnDetalleVendedor_Click);
            // 
            // btnlistarAllCom
            // 
            this.btnlistarAllCom.Location = new System.Drawing.Point(568, 208);
            this.btnlistarAllCom.Name = "btnlistarAllCom";
            this.btnlistarAllCom.Size = new System.Drawing.Size(151, 42);
            this.btnlistarAllCom.TabIndex = 6;
            this.btnlistarAllCom.Text = "Listar todos los compradores";
            this.btnlistarAllCom.UseVisualStyleBackColor = true;
            this.btnlistarAllCom.Click += new System.EventHandler(this.btnListarAllCompradores_Click);
            // 
            // btnGuardarProgreso
            // 
            this.btnGuardarProgreso.Location = new System.Drawing.Point(594, 362);
            this.btnGuardarProgreso.Name = "btnGuardarProgreso";
            this.btnGuardarProgreso.Size = new System.Drawing.Size(66, 28);
            this.btnGuardarProgreso.TabIndex = 8;
            this.btnGuardarProgreso.Text = "Guardar";
            this.btnGuardarProgreso.UseVisualStyleBackColor = true;
            this.btnGuardarProgreso.Click += new System.EventHandler(this.btnGuardarProgreso_Click);
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(568, 266);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(151, 42);
            this.btnAnalizar.TabIndex = 7;
            this.btnAnalizar.Text = "Analizar Datos";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // button1
            // 
            this.btnCargarDatos.Location = new System.Drawing.Point(662, 362);
            this.btnCargarDatos.Name = "button1";
            this.btnCargarDatos.Size = new System.Drawing.Size(66, 28);
            this.btnCargarDatos.TabIndex = 22;
            this.btnCargarDatos.Text = "Cargar";
            this.btnCargarDatos.UseVisualStyleBackColor = true;
            this.btnCargarDatos.Click += new System.EventHandler(btnCargarDatos_Click);
            // 
            // FormTienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 400);
            this.Controls.Add(this.btnCargarDatos);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.btnGuardarProgreso);
            this.Controls.Add(this.btnlistarAllCom);
            this.Controls.Add(this.btnDetallarVen);
            this.Controls.Add(this.btnAgregarVendedor);
            this.Controls.Add(this.btnQuitarVendedor);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.cboOrdenamiento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormTienda";
            this.Text = "Tienda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.ListBox lstVendedores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboOrdenamiento;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnQuitarVendedor;
        private System.Windows.Forms.Button btnAgregarVendedor;
        private System.Windows.Forms.Button btnDetallarVen;
        private System.Windows.Forms.Button btnlistarAllCom;
        private System.Windows.Forms.Button btnGuardarProgreso;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Button btnCargarDatos;
    }
}