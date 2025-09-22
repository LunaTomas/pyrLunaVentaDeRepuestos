namespace pyrLunaVentaDeRepuestos
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            lblMarca = new Label();
            lblOrigen = new Label();
            lblNumero = new Label();
            lblDescripcion = new Label();
            lblPrecio = new Label();
            grpDatosRepuestos = new GroupBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            mskPrecio = new MaskedTextBox();
            txtDescripcion = new TextBox();
            mskNumero = new MaskedTextBox();
            cmbOrigen = new ComboBox();
            cmbMarca = new ComboBox();
            grpDatosRepuestos.SuspendLayout();
            SuspendLayout();
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 15.75F);
            lblMarca.Location = new Point(6, 19);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(71, 30);
            lblMarca.TabIndex = 0;
            lblMarca.Text = "Marca";
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Font = new Font("Segoe UI", 15.75F);
            lblOrigen.Location = new Point(6, 63);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(76, 30);
            lblOrigen.TabIndex = 1;
            lblOrigen.Text = "Origen";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Font = new Font("Segoe UI", 15.75F);
            lblNumero.Location = new Point(6, 107);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(89, 30);
            lblNumero.TabIndex = 2;
            lblNumero.Text = "Número";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 15.75F);
            lblDescripcion.Location = new Point(6, 148);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(121, 30);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 15.75F);
            lblPrecio.Location = new Point(6, 291);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(70, 30);
            lblPrecio.TabIndex = 4;
            lblPrecio.Text = "Precio";
            // 
            // grpDatosRepuestos
            // 
            grpDatosRepuestos.Controls.Add(btnCancelar);
            grpDatosRepuestos.Controls.Add(btnGuardar);
            grpDatosRepuestos.Controls.Add(mskPrecio);
            grpDatosRepuestos.Controls.Add(txtDescripcion);
            grpDatosRepuestos.Controls.Add(mskNumero);
            grpDatosRepuestos.Controls.Add(cmbOrigen);
            grpDatosRepuestos.Controls.Add(cmbMarca);
            grpDatosRepuestos.Controls.Add(lblPrecio);
            grpDatosRepuestos.Controls.Add(lblMarca);
            grpDatosRepuestos.Controls.Add(lblDescripcion);
            grpDatosRepuestos.Controls.Add(lblOrigen);
            grpDatosRepuestos.Controls.Add(lblNumero);
            grpDatosRepuestos.Location = new Point(12, 12);
            grpDatosRepuestos.Name = "grpDatosRepuestos";
            grpDatosRepuestos.Size = new Size(328, 383);
            grpDatosRepuestos.TabIndex = 0;
            grpDatosRepuestos.TabStop = false;
            grpDatosRepuestos.Text = "Datos de los repuestos";
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(110, 332);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 35);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(214, 332);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(98, 35);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // mskPrecio
            // 
            mskPrecio.Font = new Font("Segoe UI", 15.75F);
            mskPrecio.Location = new Point(142, 291);
            mskPrecio.Mask = "$99999";
            mskPrecio.Name = "mskPrecio";
            mskPrecio.PromptChar = ' ';
            mskPrecio.Size = new Size(170, 35);
            mskPrecio.TabIndex = 4;
            mskPrecio.ValidatingType = typeof(int);
            mskPrecio.TextChanged += mskPrecio_TextChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Segoe UI", 15.75F);
            txtDescripcion.Location = new Point(142, 145);
            txtDescripcion.MaxLength = 50;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(170, 140);
            txtDescripcion.TabIndex = 3;
            txtDescripcion.TextChanged += txtDescripcion_TextChanged;
            // 
            // mskNumero
            // 
            mskNumero.Font = new Font("Segoe UI", 15.75F);
            mskNumero.Location = new Point(142, 104);
            mskNumero.Mask = "999999";
            mskNumero.Name = "mskNumero";
            mskNumero.PromptChar = ' ';
            mskNumero.Size = new Size(170, 35);
            mskNumero.TabIndex = 2;
            mskNumero.ValidatingType = typeof(int);
            mskNumero.TextChanged += mskNumero_TextChanged;
            // 
            // cmbOrigen
            // 
            cmbOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrigen.Font = new Font("Segoe UI", 15.75F);
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Items.AddRange(new object[] { "(N) Nacional", "(I) Importado" });
            cmbOrigen.Location = new Point(142, 60);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new Size(170, 38);
            cmbOrigen.TabIndex = 1;
            cmbOrigen.SelectedIndexChanged += cmbOrigen_SelectedIndexChanged;
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.Font = new Font("Segoe UI", 15.75F);
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Items.AddRange(new object[] { "(P) Peugeot", "(F) Fiat", "(R) Renault" });
            cmbMarca.Location = new Point(142, 16);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(170, 38);
            cmbMarca.TabIndex = 0;
            cmbMarca.SelectedIndexChanged += cmbMarca_SelectedIndexChanged;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 406);
            Controls.Add(grpDatosRepuestos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Venta de repuestos";
            Load += frmPrincipal_Load;
            grpDatosRepuestos.ResumeLayout(false);
            grpDatosRepuestos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblMarca;
        private Label lblOrigen;
        private Label lblNumero;
        private Label lblDescripcion;
        private Label lblPrecio;
        private GroupBox grpDatosRepuestos;
        private ComboBox cmbOrigen;
        private ComboBox cmbMarca;
        private MaskedTextBox mskPrecio;
        private TextBox txtDescripcion;
        private MaskedTextBox mskNumero;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
