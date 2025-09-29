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
            txtNumero = new TextBox();
            rdbImportado = new RadioButton();
            rdbNacional = new RadioButton();
            btnCancelar = new Button();
            btnGuardar = new Button();
            mskPrecio = new MaskedTextBox();
            txtDescripcion = new TextBox();
            cmbMarca = new ComboBox();
            tbcVentanas = new TabControl();
            tbpDatos = new TabPage();
            tbpConsultas = new TabPage();
            grpConsultar = new GroupBox();
            lstConsultas = new ListBox();
            btnConsultar = new Button();
            rdbImportadoConsulta = new RadioButton();
            rdbNacionalConsulta = new RadioButton();
            cmbMarcaConsulta = new ComboBox();
            lblMarcaConsulta = new Label();
            lblOrigenConsulta = new Label();
            grpDatosRepuestos.SuspendLayout();
            tbcVentanas.SuspendLayout();
            tbpDatos.SuspendLayout();
            tbpConsultas.SuspendLayout();
            grpConsultar.SuspendLayout();
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
            lblOrigen.Location = new Point(6, 62);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(76, 30);
            lblOrigen.TabIndex = 1;
            lblOrigen.Text = "Origen";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Font = new Font("Segoe UI", 15.75F);
            lblNumero.Location = new Point(6, 143);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(89, 30);
            lblNumero.TabIndex = 2;
            lblNumero.Text = "Número";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 15.75F);
            lblDescripcion.Location = new Point(6, 184);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(121, 30);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 15.75F);
            lblPrecio.Location = new Point(6, 330);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(70, 30);
            lblPrecio.TabIndex = 4;
            lblPrecio.Text = "Precio";
            // 
            // grpDatosRepuestos
            // 
            grpDatosRepuestos.Controls.Add(txtNumero);
            grpDatosRepuestos.Controls.Add(rdbImportado);
            grpDatosRepuestos.Controls.Add(rdbNacional);
            grpDatosRepuestos.Controls.Add(btnCancelar);
            grpDatosRepuestos.Controls.Add(btnGuardar);
            grpDatosRepuestos.Controls.Add(mskPrecio);
            grpDatosRepuestos.Controls.Add(txtDescripcion);
            grpDatosRepuestos.Controls.Add(cmbMarca);
            grpDatosRepuestos.Controls.Add(lblPrecio);
            grpDatosRepuestos.Controls.Add(lblMarca);
            grpDatosRepuestos.Controls.Add(lblDescripcion);
            grpDatosRepuestos.Controls.Add(lblOrigen);
            grpDatosRepuestos.Controls.Add(lblNumero);
            grpDatosRepuestos.Location = new Point(6, 6);
            grpDatosRepuestos.Name = "grpDatosRepuestos";
            grpDatosRepuestos.Size = new Size(331, 418);
            grpDatosRepuestos.TabIndex = 0;
            grpDatosRepuestos.TabStop = false;
            grpDatosRepuestos.Text = "Datos de los repuestos";
            // 
            // txtNumero
            // 
            txtNumero.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNumero.Location = new Point(142, 140);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(170, 35);
            txtNumero.TabIndex = 3;
            txtNumero.TextChanged += txtNumero_TextChanged;
            // 
            // rdbImportado
            // 
            rdbImportado.AutoSize = true;
            rdbImportado.Font = new Font("Segoe UI", 15.75F);
            rdbImportado.Location = new Point(142, 100);
            rdbImportado.Name = "rdbImportado";
            rdbImportado.Size = new Size(128, 34);
            rdbImportado.TabIndex = 2;
            rdbImportado.TabStop = true;
            rdbImportado.Text = "Importado";
            rdbImportado.UseVisualStyleBackColor = true;
            rdbImportado.CheckedChanged += rdbImportado_CheckedChanged;
            // 
            // rdbNacional
            // 
            rdbNacional.AutoSize = true;
            rdbNacional.Font = new Font("Segoe UI", 15.75F);
            rdbNacional.Location = new Point(142, 60);
            rdbNacional.Name = "rdbNacional";
            rdbNacional.Size = new Size(113, 34);
            rdbNacional.TabIndex = 1;
            rdbNacional.TabStop = true;
            rdbNacional.Text = "Nacional";
            rdbNacional.UseVisualStyleBackColor = true;
            rdbNacional.CheckedChanged += rdbNacional_CheckedChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(110, 368);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 35);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(214, 368);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(98, 35);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // mskPrecio
            // 
            mskPrecio.Font = new Font("Segoe UI", 15.75F);
            mskPrecio.Location = new Point(142, 327);
            mskPrecio.Mask = "99999";
            mskPrecio.Name = "mskPrecio";
            mskPrecio.PromptChar = ' ';
            mskPrecio.Size = new Size(170, 35);
            mskPrecio.TabIndex = 5;
            mskPrecio.ValidatingType = typeof(int);
            mskPrecio.TextChanged += mskPrecio_TextChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Segoe UI", 15.75F);
            txtDescripcion.Location = new Point(142, 181);
            txtDescripcion.MaxLength = 50;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(170, 140);
            txtDescripcion.TabIndex = 4;
            txtDescripcion.TextChanged += txtDescripcion_TextChanged;
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.Font = new Font("Segoe UI", 15.75F);
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(142, 16);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(170, 38);
            cmbMarca.TabIndex = 0;
            cmbMarca.SelectedIndexChanged += cmbMarca_SelectedIndexChanged;
            // 
            // tbcVentanas
            // 
            tbcVentanas.Controls.Add(tbpDatos);
            tbcVentanas.Controls.Add(tbpConsultas);
            tbcVentanas.Location = new Point(12, 12);
            tbcVentanas.Name = "tbcVentanas";
            tbcVentanas.SelectedIndex = 0;
            tbcVentanas.Size = new Size(351, 458);
            tbcVentanas.TabIndex = 0;
            // 
            // tbpDatos
            // 
            tbpDatos.Controls.Add(grpDatosRepuestos);
            tbpDatos.Location = new Point(4, 24);
            tbpDatos.Name = "tbpDatos";
            tbpDatos.Padding = new Padding(3);
            tbpDatos.Size = new Size(343, 430);
            tbpDatos.TabIndex = 0;
            tbpDatos.Text = "Datos";
            tbpDatos.UseVisualStyleBackColor = true;
            // 
            // tbpConsultas
            // 
            tbpConsultas.Controls.Add(grpConsultar);
            tbpConsultas.Location = new Point(4, 24);
            tbpConsultas.Name = "tbpConsultas";
            tbpConsultas.Padding = new Padding(3);
            tbpConsultas.Size = new Size(343, 430);
            tbpConsultas.TabIndex = 1;
            tbpConsultas.Text = "Consultas";
            tbpConsultas.UseVisualStyleBackColor = true;
            // 
            // grpConsultar
            // 
            grpConsultar.Controls.Add(lstConsultas);
            grpConsultar.Controls.Add(btnConsultar);
            grpConsultar.Controls.Add(rdbImportadoConsulta);
            grpConsultar.Controls.Add(rdbNacionalConsulta);
            grpConsultar.Controls.Add(cmbMarcaConsulta);
            grpConsultar.Controls.Add(lblMarcaConsulta);
            grpConsultar.Controls.Add(lblOrigenConsulta);
            grpConsultar.Location = new Point(6, 6);
            grpConsultar.Name = "grpConsultar";
            grpConsultar.Size = new Size(331, 418);
            grpConsultar.TabIndex = 0;
            grpConsultar.TabStop = false;
            grpConsultar.Text = "Consultar";
            // 
            // lstConsultas
            // 
            lstConsultas.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstConsultas.FormattingEnabled = true;
            lstConsultas.ItemHeight = 30;
            lstConsultas.Location = new Point(6, 196);
            lstConsultas.Name = "lstConsultas";
            lstConsultas.Size = new Size(319, 214);
            lstConsultas.TabIndex = 4;
            // 
            // btnConsultar
            // 
            btnConsultar.Font = new Font("Segoe UI", 15.75F);
            btnConsultar.Location = new Point(201, 149);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(124, 41);
            btnConsultar.TabIndex = 3;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // rdbImportadoConsulta
            // 
            rdbImportadoConsulta.AutoSize = true;
            rdbImportadoConsulta.Font = new Font("Segoe UI", 15.75F);
            rdbImportadoConsulta.Location = new Point(197, 109);
            rdbImportadoConsulta.Name = "rdbImportadoConsulta";
            rdbImportadoConsulta.Size = new Size(128, 34);
            rdbImportadoConsulta.TabIndex = 2;
            rdbImportadoConsulta.TabStop = true;
            rdbImportadoConsulta.Text = "Importado";
            rdbImportadoConsulta.UseVisualStyleBackColor = true;
            rdbImportadoConsulta.CheckedChanged += rdbImportadoConsulta_CheckedChanged;
            // 
            // rdbNacionalConsulta
            // 
            rdbNacionalConsulta.AutoSize = true;
            rdbNacionalConsulta.Font = new Font("Segoe UI", 15.75F);
            rdbNacionalConsulta.Location = new Point(197, 69);
            rdbNacionalConsulta.Name = "rdbNacionalConsulta";
            rdbNacionalConsulta.Size = new Size(113, 34);
            rdbNacionalConsulta.TabIndex = 1;
            rdbNacionalConsulta.TabStop = true;
            rdbNacionalConsulta.Text = "Nacional";
            rdbNacionalConsulta.UseVisualStyleBackColor = true;
            rdbNacionalConsulta.CheckedChanged += rdbNacionalConsulta_CheckedChanged;
            // 
            // cmbMarcaConsulta
            // 
            cmbMarcaConsulta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarcaConsulta.Font = new Font("Segoe UI", 15.75F);
            cmbMarcaConsulta.FormattingEnabled = true;
            cmbMarcaConsulta.Location = new Point(83, 25);
            cmbMarcaConsulta.Name = "cmbMarcaConsulta";
            cmbMarcaConsulta.Size = new Size(242, 38);
            cmbMarcaConsulta.TabIndex = 0;
            cmbMarcaConsulta.SelectedIndexChanged += cmbMarcaConsulta_SelectedIndexChanged;
            // 
            // lblMarcaConsulta
            // 
            lblMarcaConsulta.AutoSize = true;
            lblMarcaConsulta.Font = new Font("Segoe UI", 15.75F);
            lblMarcaConsulta.Location = new Point(6, 28);
            lblMarcaConsulta.Name = "lblMarcaConsulta";
            lblMarcaConsulta.Size = new Size(71, 30);
            lblMarcaConsulta.TabIndex = 1;
            lblMarcaConsulta.Text = "Marca";
            // 
            // lblOrigenConsulta
            // 
            lblOrigenConsulta.AutoSize = true;
            lblOrigenConsulta.Font = new Font("Segoe UI", 15.75F);
            lblOrigenConsulta.Location = new Point(6, 71);
            lblOrigenConsulta.Name = "lblOrigenConsulta";
            lblOrigenConsulta.Size = new Size(76, 30);
            lblOrigenConsulta.TabIndex = 2;
            lblOrigenConsulta.Text = "Origen";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 481);
            Controls.Add(tbcVentanas);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Venta de repuestos";
            Load += frmPrincipal_Load;
            grpDatosRepuestos.ResumeLayout(false);
            grpDatosRepuestos.PerformLayout();
            tbcVentanas.ResumeLayout(false);
            tbpDatos.ResumeLayout(false);
            tbpConsultas.ResumeLayout(false);
            grpConsultar.ResumeLayout(false);
            grpConsultar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblMarca;
        private Label lblOrigen;
        private Label lblNumero;
        private Label lblDescripcion;
        private Label lblPrecio;
        private GroupBox grpDatosRepuestos;
        private ComboBox cmbMarca;
        private MaskedTextBox mskPrecio;
        private TextBox txtDescripcion;
        private Button btnGuardar;
        private Button btnCancelar;
        private TabControl tbcVentanas;
        private TabPage tbpDatos;
        private TabPage tbpConsultas;
        private GroupBox grpConsultar;
        private ListBox lstConsultas;
        private Button btnConsultar;
        private RadioButton rdbImportadoConsulta;
        private RadioButton rdbNacionalConsulta;
        private ComboBox cmbMarcaConsulta;
        private Label lblMarcaConsulta;
        private Label lblOrigenConsulta;
        private RadioButton rdbImportado;
        private RadioButton rdbNacional;
        private TextBox txtNumero;
    }
}
