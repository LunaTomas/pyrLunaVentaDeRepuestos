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
            cmbOrigen.Enabled = false;
            mskNumero.Enabled = false;
            txtDescripcion.Enabled = false;
            mskPrecio.Enabled = false;
            btnGuardar.Enabled = false;
        }
        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMarca.SelectedIndex != -1)
                cmbOrigen.Enabled = true;
            else
                cmbOrigen.Enabled = false;
        }
        private void cmbOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            mskNumero.Enabled = true;
            mskNumero.Focus();
        }
        private void mskNumero_TextChanged(object sender, EventArgs e)
        {
            if (mskNumero.Text.Length > 0)
                txtDescripcion.Enabled = true;
            else
                txtDescripcion.Enabled = false;
            txtDescripcion.Clear();
        }
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length > 0)
                mskPrecio.Enabled = true;
            else
                mskPrecio.Enabled = false;
            mskPrecio.Clear();
        }
        private void mskPrecio_TextChanged(object sender, EventArgs e)
        {
            if (mskPrecio.Text.Length > 1)
                btnGuardar.Enabled = true;
            else
                btnGuardar.Enabled = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbMarca.SelectedIndex = -1;
            cmbOrigen.SelectedIndex = -1;
            mskNumero.Clear();
            txtDescripcion.Clear();
            mskPrecio.Clear();
            cmbOrigen.Enabled = false;
            mskNumero.Enabled = false;
            txtDescripcion.Enabled = false;
            mskPrecio.Enabled = false;
            btnGuardar.Enabled = false;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
