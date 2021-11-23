
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDetalleVendedor = new System.Windows.Forms.TextBox();
            this.btnAgregarVendedor = new System.Windows.Forms.Button();
            this.txtGanancia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listarCompradores = new System.Windows.Forms.Button();
            this.listarAllCom = new System.Windows.Forms.Button();
            this.btnGuardarProgreso = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstVendedores);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 330);
            this.groupBox1.TabIndex = 0;
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
            this.lstVendedores.Size = new System.Drawing.Size(611, 308);
            this.lstVendedores.TabIndex = 0;
            this.lstVendedores.SelectedIndexChanged += new System.EventHandler(this.lstVendedores_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ordenamiento:";
            // 
            // cboOrdenamiento
            // 
            this.cboOrdenamiento.FormattingEnabled = true;
            this.cboOrdenamiento.Location = new System.Drawing.Point(635, 31);
            this.cboOrdenamiento.Name = "cboOrdenamiento";
            this.cboOrdenamiento.Size = new System.Drawing.Size(171, 23);
            this.cboOrdenamiento.TabIndex = 2;
            this.cboOrdenamiento.SelectedIndexChanged += new System.EventHandler(this.cboOrdenamiento_SelectedIndexChanged);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(635, 60);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(171, 42);
            this.btnComprar.TabIndex = 3;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnQuitarVendedor
            // 
            this.btnQuitarVendedor.Location = new System.Drawing.Point(635, 156);
            this.btnQuitarVendedor.Name = "btnQuitarVendedor";
            this.btnQuitarVendedor.Size = new System.Drawing.Size(171, 42);
            this.btnQuitarVendedor.TabIndex = 4;
            this.btnQuitarVendedor.Text = "Quitar Vendedor";
            this.btnQuitarVendedor.UseVisualStyleBackColor = true;
            this.btnQuitarVendedor.Click += new System.EventHandler(this.btnQuitarVendedor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDetalleVendedor);
            this.groupBox2.Location = new System.Drawing.Point(15, 369);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(611, 69);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle del Vendedor:";
            // 
            // txtDetalleVendedor
            // 
            this.txtDetalleVendedor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDetalleVendedor.Location = new System.Drawing.Point(6, 22);
            this.txtDetalleVendedor.Name = "txtDetalleVendedor";
            this.txtDetalleVendedor.ReadOnly = true;
            this.txtDetalleVendedor.Size = new System.Drawing.Size(599, 25);
            this.txtDetalleVendedor.TabIndex = 20;
            // 
            // btnAgregarVendedor
            // 
            this.btnAgregarVendedor.Location = new System.Drawing.Point(635, 108);
            this.btnAgregarVendedor.Name = "btnAgregarVendedor";
            this.btnAgregarVendedor.Size = new System.Drawing.Size(171, 42);
            this.btnAgregarVendedor.TabIndex = 17;
            this.btnAgregarVendedor.Text = "Agregar vendedor";
            this.btnAgregarVendedor.UseVisualStyleBackColor = true;
            this.btnAgregarVendedor.Click += new System.EventHandler(this.btnAgregarVendedor_Click);
            // 
            // txtGanancia
            // 
            this.txtGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtGanancia.Location = new System.Drawing.Point(635, 400);
            this.txtGanancia.Name = "txtGanancia";
            this.txtGanancia.ReadOnly = true;
            this.txtGanancia.Size = new System.Drawing.Size(171, 38);
            this.txtGanancia.TabIndex = 18;
            this.txtGanancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(635, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 28);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ganancia(USD):";
            // 
            // listarCompradores
            // 
            this.listarCompradores.Location = new System.Drawing.Point(635, 204);
            this.listarCompradores.Name = "listarCompradores";
            this.listarCompradores.Size = new System.Drawing.Size(171, 42);
            this.listarCompradores.TabIndex = 20;
            this.listarCompradores.Text = "Listar compradores";
            this.listarCompradores.UseVisualStyleBackColor = true;
            this.listarCompradores.Click += new System.EventHandler(this.btnListarCompradoreDelVen_Click);
            // 
            // listarAllCom
            // 
            this.listarAllCom.Location = new System.Drawing.Point(635, 252);
            this.listarAllCom.Name = "listarAllCom";
            this.listarAllCom.Size = new System.Drawing.Size(171, 42);
            this.listarAllCom.TabIndex = 21;
            this.listarAllCom.Text = "Listar todos los compradores";
            this.listarAllCom.UseVisualStyleBackColor = true;
            this.listarAllCom.Click += new System.EventHandler(this.btnListarAllCompradores_Click);
            // 
            // button1
            // 
            this.btnGuardarProgreso.Location = new System.Drawing.Point(635, 300);
            this.btnGuardarProgreso.Name = "btnGuardarProgreso";
            this.btnGuardarProgreso.Size = new System.Drawing.Size(171, 42);
            this.btnGuardarProgreso.TabIndex = 22;
            this.btnGuardarProgreso.Text = "Guardar Progreso";
            this.btnGuardarProgreso.UseVisualStyleBackColor = true;
            this.btnGuardarProgreso.Click += new System.EventHandler(this.btnGuardarProgreso_Click);
            // 
            // FormTienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 450);
            this.Controls.Add(this.btnGuardarProgreso);
            this.Controls.Add(this.listarAllCom);
            this.Controls.Add(this.listarCompradores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGanancia);
            this.Controls.Add(this.btnAgregarVendedor);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnQuitarVendedor);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.cboOrdenamiento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormTienda";
            this.Text = "FormTienda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAgregarVendedor;
        private System.Windows.Forms.TextBox txtGanancia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetalleVendedor;
        private System.Windows.Forms.Button listarCompradores;
        private System.Windows.Forms.Button listarAllCom;
        private System.Windows.Forms.Button btnGuardarProgreso;
    }
}