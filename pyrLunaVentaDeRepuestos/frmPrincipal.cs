namespace pyrLunaVentaDeRepuestos
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        //declaracion de variables
        string marca;
        string origen;
        int numero;
        string descripcion;
        float precio;
        string[] repuestos = new string[100]; //para cargar los repuestos
        int contador = 0;
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            rdbNacional.Enabled = false;
            rdbImportado.Enabled = false;
            txtNumero.Enabled = false;
            txtDescripcion.Enabled = false;
            mskPrecio.Enabled = false;
            btnGuardar.Enabled = false;
            cmbMarca.Items.Add("(P) Peugeot");
            cmbMarca.Items.Add("(F) Fiat");
            cmbMarca.Items.Add("(R) Renault");
            rdbNacionalConsulta.Enabled = false;
            rdbImportadoConsulta.Enabled = false;
            btnConsultar.Enabled = false;
            cmbMarcaConsulta.Items.Add("(P)");
            cmbMarcaConsulta.Items.Add("(F)");
            cmbMarcaConsulta.Items.Add("(R)");
        }
        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMarca.SelectedIndex != -1)
            {
                rdbNacional.Enabled = true;
                rdbImportado.Enabled = true;
            }
            else
            {
                rdbNacional.Enabled = false;
                rdbImportado.Enabled = false;
                rdbNacional.Checked = false;
                rdbImportado.Checked = false;
            }
        }
        private void rdbNacional_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNacional.Checked == true)
            {
                txtNumero.Enabled = true;
            }
            else
            {
            txtNumero.Enabled = false;
            txtNumero.Clear();
            }
        }
        private void rdbImportado_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbImportado.Checked == true)
            {
                txtNumero.Enabled = true;
            }
            else
            {
                txtNumero.Enabled = false;
                txtNumero.Clear();
            }
        }
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite que solo los números se escriban en el TextBox
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true; // Cancela la pulsación de la tecla si no es un número o la tecla Backspace
            }
        }
        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            if (txtNumero.Text.Length > 0)
            {
                txtDescripcion.Enabled = true;
            }
            else
            {
                txtDescripcion.Enabled = false;
                txtDescripcion.Clear();
            }
        }
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length > 0)
            {
                mskPrecio.Enabled = true;
            }
            else
            {
                mskPrecio.Enabled = false;
                mskPrecio.Clear();
            }
        }
        private void mskPrecio_TextChanged(object sender, EventArgs e)
        {
            if (mskPrecio.Text.Length > 0)
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbMarca.SelectedIndex = -1;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //verificar que no se pasen de 100 repuestos
            if (contador >= 100) //puse 5 en lugar de 100 para probar y me funcionó
            {
                MessageBox.Show("No se pueden agregar más repuestos. El límite es de 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                btnGuardar.Enabled = false;
            }
            //no guardar si esta repetido el numero de repuesto para la misma marca y origen
            for (int i = 0; i < contador; i++)
            {
                if (repuestos[i].Contains(cmbMarca.Text) && repuestos[i].Contains(txtNumero.Text))
                {
                    MessageBox.Show("El número de repuesto ya existe para la marca y origen seleccionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //guardar los datos
            marca = cmbMarca.Text;
            //guardar el origen
            if (rdbNacional.Checked == true)
            {
                origen = "(N) Nacional";
            }
            else
            {
                origen = "(I) Importado";
            }
            //parse para convertir el texto a numeros
            numero = int.Parse(txtNumero.Text); //int para el numerico
            descripcion = txtDescripcion.Text;
            precio = float.Parse(mskPrecio.Text); //float para numeros con decimales porque es dinero
            //guardar los datos en el array
            repuestos[contador] = marca + " " + origen + " " + numero + " " + descripcion + " " + precio;
            contador++;
        }
        private void cmbMarcaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMarcaConsulta.SelectedIndex != -1)
            {
                rdbNacionalConsulta.Enabled = true;
                rdbImportadoConsulta.Enabled = true;
            }
            else
            {
                rdbNacionalConsulta.Enabled = false;
                rdbImportadoConsulta.Enabled = false;
                rdbNacionalConsulta.Checked = false;
                rdbImportadoConsulta.Checked = false;
            }
        }
        private void rdbNacionalConsulta_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNacionalConsulta.Checked == true || rdbImportadoConsulta.Checked == true)
            {
                btnConsultar.Enabled = true;
            }
            else
            {
                btnConsultar.Enabled = false;
            }
        }
        private void rdbImportadoConsulta_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNacionalConsulta.Checked == true || rdbImportadoConsulta.Checked == true)
            {
                btnConsultar.Enabled = true;
            }
            else
            {
                btnConsultar.Enabled = false;
            }
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //mostrar los datos en el listbox lstConsultas solo los que coincidan con la consulta
            lstConsultas.Items.Clear();
            marca = cmbMarcaConsulta.Text;
            if (rdbNacionalConsulta.Checked == true)
            {
                origen = "(N) Nacional";
            }
            else
            {
                origen = "(I) Importado";
            }
            for (int i = 0; i < contador; i++)
            {
                if (repuestos[i].Contains(marca) && repuestos[i].Contains(origen))
                {
                    lstConsultas.Items.Add(repuestos[i]);
                }
            }
            //mostrar error si no hay repuestos que coincidan con la consulta
            if (lstConsultas.Items.Count == 0)
            {
                MessageBox.Show("No se encontraron repuestos que coincidan con la consulta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
