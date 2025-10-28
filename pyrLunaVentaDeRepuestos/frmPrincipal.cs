namespace pyrLunaVentaDeRepuestos
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        // Variables
        string marca;
        string origen;
        int numero;
        string descripcion;
        float precio;
        string[] repuestos = new string[100]; // para cargar los repuestos
        int contador = 0;

        string[,] matRespuesto = new string[100, 5];
        int indiceGrabar = 0;

        string archivoRepuestos = "repuestos.txt"; // archivo de guardado

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

            // cargar datos desde archivo si existe
            if (File.Exists(archivoRepuestos))
            {
                string[] lineas = File.ReadAllLines(archivoRepuestos);
                for (int i = 0; i < lineas.Length && i < 100; i++)
                {
                    string[] partes = lineas[i].Split(',');
                    if (partes.Length == 5)
                    {
                        matRespuesto[i, 0] = partes[0]; // marca
                        matRespuesto[i, 1] = partes[1]; // origen
                        matRespuesto[i, 2] = partes[2]; // numero
                        matRespuesto[i, 3] = partes[3]; // precio
                        matRespuesto[i, 4] = partes[4]; // descripcion
                        repuestos[i] = string.Join(" ", partes);
                        dgvGrilla.Rows.Add(partes[0], partes[1], partes[2], partes[3], partes[4]);
                        indiceGrabar++;
                        contador++;
                    }
                }
            }
            // cargar datos de prueba siempre que se abra
            CargadorDatos();
            MessageBox.Show("Datos cargados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List<string> origenes = new List<string>();
            List<string> listaMarcas = new List<string>();
            for (int filas = 0; filas < matRespuesto.GetLength(0); filas++)
            {
                dgvGrilla.Rows.Add(matRespuesto[filas, 0],
                matRespuesto[filas, 1],
                matRespuesto[filas, 2],
                matRespuesto[filas, 3],
                matRespuesto[filas, 4]);
                if (!listaMarcas.Contains(matRespuesto[filas, 0]))
                {
                    listaMarcas.Add(matRespuesto[filas, 0]);
                }
                if (!origenes.Contains(matRespuesto[filas, 1]))
                {
                    origenes.Add(matRespuesto[filas, 1]);
                }
            }
        }
        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdbNacional.Enabled = cmbMarca.SelectedIndex != -1;
            rdbImportado.Enabled = cmbMarca.SelectedIndex != -1;

            if (cmbMarca.SelectedIndex == -1)
            {
                rdbNacional.Checked = false;
                rdbImportado.Checked = false;
            }
        }
        private void rdbNacional_CheckedChanged(object sender, EventArgs e)
        {
            txtNumero.Enabled = rdbNacional.Checked;
            if (!rdbNacional.Checked) txtNumero.Clear();
        }
        private void rdbImportado_CheckedChanged(object sender, EventArgs e)
        {
            txtNumero.Enabled = rdbImportado.Checked;
            if (!rdbImportado.Checked) txtNumero.Clear();
        }
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = txtNumero.Text.Length > 0;
            if (!txtDescripcion.Enabled) txtDescripcion.Clear();
        }
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            mskPrecio.Enabled = txtDescripcion.Text.Length > 0;
            if (!mskPrecio.Enabled) mskPrecio.Clear();
        }
        private void mskPrecio_TextChanged(object sender, EventArgs e)
        {
            btnGuardar.Enabled = mskPrecio.Text.Length > 0;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbMarca.SelectedIndex = -1;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (contador >= 100)
            {
                MessageBox.Show("No se pueden agregar más repuestos. El límite es de 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardar.Enabled = false;
                return;
            }
            // verificar duplicados
            for (int i = 0; i < contador; i++)
            {
                if (repuestos[i].Contains(cmbMarca.Text) && repuestos[i].Contains(txtNumero.Text))
                {
                    MessageBox.Show("El número de repuesto ya existe para la marca y origen seleccionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // guardar datos
            marca = cmbMarca.Text;
            origen = rdbNacional.Checked ? "(N) Nacional" : "(I) Importado";
            numero = int.Parse(txtNumero.Text);
            descripcion = txtDescripcion.Text;
            precio = float.Parse(mskPrecio.Text);

            // guardar en matriz
            matRespuesto[indiceGrabar, 0] = marca;
            matRespuesto[indiceGrabar, 1] = origen;
            matRespuesto[indiceGrabar, 2] = numero.ToString();
            matRespuesto[indiceGrabar, 3] = precio.ToString();
            matRespuesto[indiceGrabar, 4] = descripcion;
            indiceGrabar++;

            // guardar en vector de repuestos
            repuestos[contador] = string.Join(" ", marca, origen, numero, descripcion, precio);
            contador++;

            // agregar a DataGridView
            dgvGrilla.Rows.Add(marca, origen, numero, precio, descripcion);

            // guardar en archivo
            GuardarEnArchivo();

            // limpiar controles
            cmbMarca.SelectedIndex = -1;
            txtNumero.Clear();
            txtDescripcion.Clear();
            mskPrecio.Clear();

            MessageBox.Show("Repuesto guardado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // guardar matriz en archivo
        private void GuardarEnArchivo()
        {
            using (StreamWriter sw = new StreamWriter(archivoRepuestos))
            {
                for (int i = 0; i < indiceGrabar; i++)
                {
                    if (!string.IsNullOrEmpty(matRespuesto[i, 0]))
                    {
                        sw.WriteLine(string.Join(",", matRespuesto[i, 0], matRespuesto[i, 1],
                            matRespuesto[i, 2], matRespuesto[i, 3], matRespuesto[i, 4]));
                    }
                }
            }
        }
        private void cmbMarcaConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdbNacionalConsulta.Enabled = cmbMarcaConsulta.SelectedIndex != -1;
            rdbImportadoConsulta.Enabled = cmbMarcaConsulta.SelectedIndex != -1;

            if (cmbMarcaConsulta.SelectedIndex == -1)
            {
                rdbNacionalConsulta.Checked = false;
                rdbImportadoConsulta.Checked = false;
            }
        }
        private void rdbNacionalConsulta_CheckedChanged(object sender, EventArgs e)
        {
            btnConsultar.Enabled = rdbNacionalConsulta.Checked || rdbImportadoConsulta.Checked;
        }
        private void rdbImportadoConsulta_CheckedChanged(object sender, EventArgs e)
        {
            btnConsultar.Enabled = rdbNacionalConsulta.Checked || rdbImportadoConsulta.Checked;
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            lstConsultas.Items.Clear();
            marca = cmbMarcaConsulta.Text;
            origen = rdbNacionalConsulta.Checked ? "(N) Nacional" : "(I) Importado";
            for (int i = 0; i < contador; i++)
            {
                if (repuestos[i].Contains(marca) && repuestos[i].Contains(origen))
                    lstConsultas.Items.Add(repuestos[i]);
            }
            if (lstConsultas.Items.Count == 0)
                MessageBox.Show("No se encontraron repuestos que coincidan con la consulta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
private void CargadorDatos()
        {
            // Fila 0
            matRespuesto[0, 0] = "TechNova";
            matRespuesto[0, 1] = "Japón";
            matRespuesto[0, 2] = "54321";
            matRespuesto[0, 3] = "499.99";
            matRespuesto[0, 4] = "Smartphone de alta gama con cámara triple.";

            // Fila 1
            matRespuesto[1, 0] = "EcoWear";
            matRespuesto[1, 1] = "Vietnam";
            matRespuesto[1, 2] = "98765";
            matRespuesto[1, 3] = "29.50";
            matRespuesto[1, 4] = "Camiseta de algodón orgánico, talla M.";

            // Fila 2
            matRespuesto[2, 0] = "AeroWheels";
            matRespuesto[2, 1] = "EE. UU.";
            matRespuesto[2, 2] = "11223";
            matRespuesto[2, 3] = "1250.00";
            matRespuesto[2, 4] = "Bicicleta de montaña con suspensión completa.";

            // Fila 3
            matRespuesto[3, 0] = "GourmetChef";
            matRespuesto[3, 1] = "Francia";
            matRespuesto[3, 2] = "67890";
            matRespuesto[3, 3] = "45.99";
            matRespuesto[3, 4] = "Set de cuchillos de chef de acero inoxidable.";

            // Fila 4
            matRespuesto[4, 0] = "PowerUp";
            matRespuesto[4, 1] = "China";
            matRespuesto[4, 2] = "33445";
            matRespuesto[4, 3] = "19.95";
            matRespuesto[4, 4] = "Batería portátil de 10000mAh.";

            // Fila 5
            matRespuesto[5, 0] = "AquaFlow";
            matRespuesto[5, 1] = "México";
            matRespuesto[5, 2] = "20210";
            matRespuesto[5, 3] = "15.00";
            matRespuesto[5, 4] = "Filtro de agua de repuesto, pack de 3.";

            // Fila 6
            matRespuesto[6, 0] = "StyleFit";
            matRespuesto[6, 1] = "Italia";
            matRespuesto[6, 2] = "76543";
            matRespuesto[6, 3] = "89.00";
            matRespuesto[6, 4] = "Zapatos deportivos de cuero, color negro.";

            // Fila 7
            matRespuesto[7, 0] = "HomeLux";
            matRespuesto[7, 1] = "Alemania";
            matRespuesto[7, 2] = "88990";
            matRespuesto[7, 3] = "249.99";
            matRespuesto[7, 4] = "Aspiradora robótica con mapeo láser.";

            // Fila 8
            matRespuesto[8, 0] = "SweetTreats";
            matRespuesto[8, 1] = "Argentina";
            matRespuesto[8, 2] = "41414";
            matRespuesto[8, 3] = "5.50";
            matRespuesto[8, 4] = "Caja de alfajores artesanales (6 unidades).";

            // Fila 9
            matRespuesto[9, 0] = "OfficePro";
            matRespuesto[9, 1] = "Canadá";
            matRespuesto[9, 2] = "10010";
            matRespuesto[9, 3] = "120.75";
            matRespuesto[9, 4] = "Silla ergonómica de escritorio, color gris.";

            // Fila 10
            matRespuesto[10, 0] = "MediCare";
            matRespuesto[10, 1] = "India";
            matRespuesto[10, 2] = "90001";
            matRespuesto[10, 3] = "8.25";
            matRespuesto[10, 4] = "Termómetro digital de precisión.";

            // Fila 11
            matRespuesto[11, 0] = "UrbanArt";
            matRespuesto[11, 1] = "Brasil";
            matRespuesto[11, 2] = "25813";
            matRespuesto[11, 3] = "35.00";
            matRespuesto[11, 4] = "Lienzo para pintar, 50x70 cm.";

            // Fila 12
            matRespuesto[12, 0] = "SoundBliss";
            matRespuesto[12, 1] = "Corea del Sur";
            matRespuesto[12, 2] = "60606";
            matRespuesto[12, 3] = "189.99";
            matRespuesto[12, 4] = "Auriculares inalámbricos con cancelación de ruido.";

            // Fila 13
            matRespuesto[13, 0] = "AgriGrow";
            matRespuesto[13, 1] = "España";
            matRespuesto[13, 2] = "71717";
            matRespuesto[13, 3] = "12.90";
            matRespuesto[13, 4] = "Semillas orgánicas de tomate cherry.";

            // Fila 14
            matRespuesto[14, 0] = "FlexiPly";
            matRespuesto[14, 1] = "Suecia";
            matRespuesto[14, 2] = "82828";
            matRespuesto[14, 3] = "55.00";
            matRespuesto[14, 4] = "Juego de bloques de construcción de madera.";

            // Fila 15
            matRespuesto[15, 0] = "DataVault";
            matRespuesto[15, 1] = "Taiwán";
            matRespuesto[15, 2] = "93939";
            matRespuesto[15, 3] = "79.99";
            matRespuesto[15, 4] = "Disco duro externo de 1TB.";

            // Fila 16
            matRespuesto[16, 0] = "PuraVida";
            matRespuesto[16, 1] = "Costa Rica";
            matRespuesto[16, 2] = "10101";
            matRespuesto[16, 3] = "6.50";
            matRespuesto[16, 4] = "Café molido de origen, 250g.";

            // Fila 17
            matRespuesto[17, 0] = "ProGears";
            matRespuesto[17, 1] = "Reino Unido";
            matRespuesto[17, 2] = "12121";
            matRespuesto[17, 3] = "450.00";
            matRespuesto[17, 4] = "Taladro percutor profesional.";

            // Fila 18
            matRespuesto[18, 0] = "SoftDream";
            matRespuesto[18, 1] = "Portugal";
            matRespuesto[18, 2] = "13131";
            matRespuesto[18, 3] = "39.99";
            matRespuesto[18, 4] = "Almohada viscoelástica.";

            // Fila 19
            matRespuesto[19, 0] = "AutoShine";
            matRespuesto[19, 1] = "EE. UU.";
            matRespuesto[19, 2] = "14141";
            matRespuesto[19, 3] = "18.75";
            matRespuesto[19, 4] = "Cera protectora para carrocería.";

            // Fila 20
            matRespuesto[20, 0] = "TechNova";
            matRespuesto[20, 1] = "Japón";
            matRespuesto[20, 2] = "54322";
            matRespuesto[20, 3] = "699.99";
            matRespuesto[20, 4] = "Laptop ultradelgada 13 pulgadas.";

            // Fila 21
            matRespuesto[21, 0] = "EcoWear";
            matRespuesto[21, 1] = "Vietnam";
            matRespuesto[21, 2] = "98766";
            matRespuesto[21, 3] = "45.00";
            matRespuesto[21, 4] = "Pantalón deportivo transpirable, talla L.";

            // Fila 22
            matRespuesto[22, 0] = "AeroWheels";
            matRespuesto[22, 1] = "EE. UU.";
            matRespuesto[22, 2] = "11224";
            matRespuesto[22, 3] = "850.50";
            matRespuesto[22, 4] = "Casco de bicicleta aerodinámico.";

            // Fila 23
            matRespuesto[23, 0] = "GourmetChef";
            matRespuesto[23, 1] = "Francia";
            matRespuesto[23, 2] = "67891";
            matRespuesto[23, 3] = "15.90";
            matRespuesto[23, 4] = "Molde de silicona para repostería.";

            // Fila 24
            matRespuesto[24, 0] = "PowerUp";
            matRespuesto[24, 1] = "China";
            matRespuesto[24, 2] = "33446";
            matRespuesto[24, 3] = "9.99";
            matRespuesto[24, 4] = "Cable USB-C de carga rápida, 2 metros.";

            // Fila 25
            matRespuesto[25, 0] = "AquaFlow";
            matRespuesto[25, 1] = "México";
            matRespuesto[25, 2] = "20211";
            matRespuesto[25, 3] = "25.00";
            matRespuesto[25, 4] = "Ducha de mano con alta presión.";

            // Fila 26
            matRespuesto[26, 0] = "StyleFit";
            matRespuesto[26, 1] = "Italia";
            matRespuesto[26, 2] = "76544";
            matRespuesto[26, 3] = "199.00";
            matRespuesto[26, 4] = "Bolso de mano de diseño.";

            // Fila 27
            matRespuesto[27, 0] = "HomeLux";
            matRespuesto[27, 1] = "Alemania";
            matRespuesto[27, 2] = "88991";
            matRespuesto[27, 3] = "15.99";
            matRespuesto[27, 4] = "Set de toallas de microfibra, 4 piezas.";

            // Fila 28
            matRespuesto[28, 0] = "SweetTreats";
            matRespuesto[28, 1] = "Argentina";
            matRespuesto[28, 2] = "41415";
            matRespuesto[28, 3] = "8.00";
            matRespuesto[28, 4] = "Barra de chocolate amargo 70% cacao.";

            // Fila 29
            matRespuesto[29, 0] = "OfficePro";
            matRespuesto[29, 1] = "Canadá";
            matRespuesto[29, 2] = "10011";
            matRespuesto[29, 3] = "25.50";
            matRespuesto[29, 4] = "Resma de papel A4 ecológico.";

            // Fila 30
            matRespuesto[30, 0] = "MediCare";
            matRespuesto[30, 1] = "India";
            matRespuesto[30, 2] = "90002";
            matRespuesto[30, 3] = "15.50";
            matRespuesto[30, 4] = "Vendas elásticas de soporte.";

            // Fila 31
            matRespuesto[31, 0] = "UrbanArt";
            matRespuesto[31, 1] = "Brasil";
            matRespuesto[31, 2] = "25814";
            matRespuesto[31, 3] = "55.00";
            matRespuesto[31, 4] = "Pintura acrílica set de 12 colores.";

            // Fila 32
            matRespuesto[32, 0] = "SoundBliss";
            matRespuesto[32, 1] = "Corea del Sur";
            matRespuesto[32, 2] = "60607";
            matRespuesto[32, 3] = "49.99";
            matRespuesto[32, 4] = "Parlante Bluetooth portátil resistente al agua.";

            // Fila 33
            matRespuesto[33, 0] = "AgriGrow";
            matRespuesto[33, 1] = "España";
            matRespuesto[33, 2] = "71718";
            matRespuesto[33, 3] = "8.50";
            matRespuesto[33, 4] = "Kit de germinación de hierbas aromáticas.";

            // Fila 34
            matRespuesto[34, 0] = "FlexiPly";
            matRespuesto[34, 1] = "Suecia";
            matRespuesto[34, 2] = "82829";
            matRespuesto[34, 3] = "29.99";
            matRespuesto[34, 4] = "Rompecabezas 3D de madera.";

            // Fila 35
            matRespuesto[35, 0] = "DataVault";
            matRespuesto[35, 1] = "Taiwán";
            matRespuesto[35, 2] = "93940";
            matRespuesto[35, 3] = "119.99";
            matRespuesto[35, 4] = "Memoria USB 128GB alta velocidad.";

            // Fila 36
            matRespuesto[36, 0] = "PuraVida";
            matRespuesto[36, 1] = "Costa Rica";
            matRespuesto[36, 2] = "10102";
            matRespuesto[36, 3] = "12.50";
            matRespuesto[36, 4] = "Miel de abeja pura de montaña.";

            // Fila 37
            matRespuesto[37, 0] = "ProGears";
            matRespuesto[37, 1] = "Reino Unido";
            matRespuesto[37, 2] = "12122";
            matRespuesto[37, 3] = "89.90";
            matRespuesto[37, 4] = "Sierra de mano multiusos.";

            // Fila 38
            matRespuesto[38, 0] = "SoftDream";
            matRespuesto[38, 1] = "Portugal";
            matRespuesto[38, 2] = "13132";
            matRespuesto[38, 3] = "19.95";
            matRespuesto[38, 4] = "Manta ligera de microfibra.";

            // Fila 39
            matRespuesto[39, 0] = "AutoShine";
            matRespuesto[39, 1] = "EE. UU.";
            matRespuesto[39, 2] = "14142";
            matRespuesto[39, 3] = "35.00";
            matRespuesto[39, 4] = "Aspiradora de mano para coche.";

            // Fila 40
            matRespuesto[40, 0] = "TechNova";
            matRespuesto[40, 1] = "Japón";
            matRespuesto[40, 2] = "54323";
            matRespuesto[40, 3] = "129.99";
            matRespuesto[40, 4] = "Tablet de 7 pulgadas para lectura.";

            // Fila 41
            matRespuesto[41, 0] = "EcoWear";
            matRespuesto[41, 1] = "Vietnam";
            matRespuesto[41, 2] = "98767";
            matRespuesto[41, 3] = "19.99";
            matRespuesto[41, 4] = "Calcetines deportivos (pack de 5).";

            // Fila 42
            matRespuesto[42, 0] = "AeroWheels";
            matRespuesto[42, 1] = "EE. UU.";
            matRespuesto[42, 2] = "11225";
            matRespuesto[42, 3] = "59.99";
            matRespuesto[42, 4] = "Bomba de aire portátil para neumáticos.";

            // Fila 43
            matRespuesto[43, 0] = "GourmetChef";
            matRespuesto[43, 1] = "Francia";
            matRespuesto[43, 2] = "67892";
            matRespuesto[43, 3] = "99.99";
            matRespuesto[43, 4] = "Olla de cocción lenta eléctrica.";

            // Fila 44
            matRespuesto[44, 0] = "PowerUp";
            matRespuesto[44, 1] = "China";
            matRespuesto[44, 2] = "33447";
            matRespuesto[44, 3] = "29.90";
            matRespuesto[44, 4] = "Base de carga inalámbrica rápida.";

            // Fila 45
            matRespuesto[45, 0] = "AquaFlow";
            matRespuesto[45, 1] = "México";
            matRespuesto[45, 2] = "20212";
            matRespuesto[45, 3] = "5.99";
            matRespuesto[45, 4] = "Pastillas desinfectantes para inodoro.";

            // Fila 46
            matRespuesto[46, 0] = "StyleFit";
            matRespuesto[46, 1] = "Italia";
            matRespuesto[46, 2] = "76545";
            matRespuesto[46, 3] = "45.00";
            matRespuesto[46, 4] = "Falda plisada de seda, talla S.";

            // Fila 47
            matRespuesto[47, 0] = "HomeLux";
            matRespuesto[47, 1] = "Alemania";
            matRespuesto[47, 2] = "88992";
            matRespuesto[47, 3] = "49.99";
            matRespuesto[47, 4] = "Máquina de hacer café de filtro.";

            // Fila 48
            matRespuesto[48, 0] = "SweetTreats";
            matRespuesto[48, 1] = "Argentina";
            matRespuesto[48, 2] = "41416";
            matRespuesto[48, 3] = "10.00";
            matRespuesto[48, 4] = "Caja de bombones de licor.";

            // Fila 49
            matRespuesto[49, 0] = "OfficePro";
            matRespuesto[49, 1] = "Canadá";
            matRespuesto[49, 2] = "10012";
            matRespuesto[49, 3] = "8.99";
            matRespuesto[49, 4] = "Bolígrafos de gel (caja de 12).";

            // Fila 50
            matRespuesto[50, 0] = "MediCare";
            matRespuesto[50, 1] = "India";
            matRespuesto[50, 2] = "90003";
            matRespuesto[50, 3] = "3.99";
            matRespuesto[50, 4] = "Tiritas adhesivas hipoalergénicas.";

            // Fila 51
            matRespuesto[51, 0] = "UrbanArt";
            matRespuesto[51, 1] = "Brasil";
            matRespuesto[51, 2] = "25815";
            matRespuesto[51, 3] = "12.50";
            matRespuesto[51, 4] = "Pinceles de diferentes tamaños (set).";

            // Fila 52
            matRespuesto[52, 0] = "SoundBliss";
            matRespuesto[52, 1] = "Corea del Sur";
            matRespuesto[52, 2] = "60608";
            matRespuesto[52, 3] = "99.00";
            matRespuesto[52, 4] = "Reloj inteligente con monitor de actividad.";

            // Fila 53
            matRespuesto[53, 0] = "AgriGrow";
            matRespuesto[53, 1] = "España";
            matRespuesto[53, 2] = "71719";
            matRespuesto[53, 3] = "25.00";
            matRespuesto[53, 4] = "Tijeras de podar ergonómicas.";

            // Fila 54
            matRespuesto[54, 0] = "FlexiPly";
            matRespuesto[54, 1] = "Suecia";
            matRespuesto[54, 2] = "82830";
            matRespuesto[54, 3] = "15.99";
            matRespuesto[54, 4] = "Coche de juguete a escala de madera.";

            // Fila 55
            matRespuesto[55, 0] = "DataVault";
            matRespuesto[55, 1] = "Taiwán";
            matRespuesto[55, 2] = "93941";
            matRespuesto[55, 3] = "45.00";
            matRespuesto[55, 4] = "Lector de tarjetas SD y MicroSD.";

            // Fila 56
            matRespuesto[56, 0] = "PuraVida";
            matRespuesto[56, 1] = "Costa Rica";
            matRespuesto[56, 2] = "10103";
            matRespuesto[56, 3] = "9.50";
            matRespuesto[56, 4] = "Jabón artesanal de lavanda.";

            // Fila 57
            matRespuesto[57, 0] = "ProGears";
            matRespuesto[57, 1] = "Reino Unido";
            matRespuesto[57, 2] = "12123";
            matRespuesto[57, 3] = "299.99";
            matRespuesto[57, 4] = "Set de herramientas de mecánica.";

            // Fila 58
            matRespuesto[58, 0] = "SoftDream";
            matRespuesto[58, 1] = "Portugal";
            matRespuesto[58, 2] = "13133";
            matRespuesto[58, 3] = "65.00";
            matRespuesto[58, 4] = "Cortinas opacas, color beige.";

            // Fila 59
            matRespuesto[59, 0] = "AutoShine";
            matRespuesto[59, 1] = "EE. UU.";
            matRespuesto[59, 2] = "14143";
            matRespuesto[59, 3] = "9.99";
            matRespuesto[59, 4] = "Esponjas de microfibra para limpieza (pack).";

            // Fila 60
            matRespuesto[60, 0] = "TechNova";
            matRespuesto[60, 1] = "Japón";
            matRespuesto[60, 2] = "54324";
            matRespuesto[60, 3] = "249.00";
            matRespuesto[60, 4] = "Monitor de PC 24 pulgadas Full HD.";

            // Fila 61
            matRespuesto[61, 0] = "EcoWear";
            matRespuesto[61, 1] = "Vietnam";
            matRespuesto[61, 2] = "98768";
            matRespuesto[61, 3] = "39.90";
            matRespuesto[61, 4] = "Chaqueta cortavientos ultraligera.";

            // Fila 62
            matRespuesto[62, 0] = "AeroWheels";
            matRespuesto[62, 1] = "EE. UU.";
            matRespuesto[62, 2] = "11226";
            matRespuesto[62, 3] = "19.99";
            matRespuesto[62, 4] = "Luces LED recargables para bicicleta.";

            // Fila 63
            matRespuesto[63, 0] = "GourmetChef";
            matRespuesto[63, 1] = "Francia";
            matRespuesto[63, 2] = "67893";
            matRespuesto[63, 3] = "22.00";
            matRespuesto[63, 4] = "Especiero giratorio de bambú.";

            // Fila 64
            matRespuesto[64, 0] = "PowerUp";
            matRespuesto[64, 1] = "China";
            matRespuesto[64, 2] = "33448";
            matRespuesto[64, 3] = "59.99";
            matRespuesto[64, 4] = "Auriculares para gaming con micrófono.";

            // Fila 65
            matRespuesto[65, 0] = "AquaFlow";
            matRespuesto[65, 1] = "México";
            matRespuesto[65, 2] = "20213";
            matRespuesto[65, 3] = "9.99";
            matRespuesto[65, 4] = "Ambientador para baño, aroma marino.";

            // Fila 66
            matRespuesto[66, 0] = "StyleFit";
            matRespuesto[66, 1] = "Italia";
            matRespuesto[66, 2] = "76546";
            matRespuesto[66, 3] = "75.00";
            matRespuesto[66, 4] = "Polo de piqué de algodón, talla M.";

            // Fila 67
            matRespuesto[67, 0] = "HomeLux";
            matRespuesto[67, 1] = "Alemania";
            matRespuesto[67, 2] = "88993";
            matRespuesto[67, 3] = "8.99";
            matRespuesto[67, 4] = "Bombillas LED de bajo consumo (pack de 4).";

            // Fila 68
            matRespuesto[68, 0] = "SweetTreats";
            matRespuesto[68, 1] = "Argentina";
            matRespuesto[68, 2] = "41417";
            matRespuesto[68, 3] = "6.90";
            matRespuesto[68, 4] = "Galletas de avena y pasas (paquete grande).";

            // Fila 69
            matRespuesto[69, 0] = "OfficePro";
            matRespuesto[69, 1] = "Canadá";
            matRespuesto[69, 2] = "10013";
            matRespuesto[69, 3] = "45.99";
            matRespuesto[69, 4] = "Destructora de papel de uso personal.";

            // Fila 70
            matRespuesto[70, 0] = "MediCare";
            matRespuesto[70, 1] = "India";
            matRespuesto[70, 2] = "90004";
            matRespuesto[70, 3] = "25.00";
            matRespuesto[70, 4] = "Nebulizador ultrasónico compacto.";

            // Fila 71
            matRespuesto[71, 0] = "UrbanArt";
            matRespuesto[71, 1] = "Brasil";
            matRespuesto[71, 2] = "25816";
            matRespuesto[71, 3] = "8.99";
            matRespuesto[71, 4] = "Bloc de dibujo tamaño A3.";

            // Fila 72
            matRespuesto[72, 0] = "SoundBliss";
            matRespuesto[72, 1] = "Corea del Sur";
            matRespuesto[72, 2] = "60609";
            matRespuesto[72, 3] = "14.99";
            matRespuesto[72, 4] = "Cable auxiliar de audio 3.5mm.";

            // Fila 73
            matRespuesto[73, 0] = "AgriGrow";
            matRespuesto[73, 1] = "España";
            matRespuesto[73, 2] = "71720";
            matRespuesto[73, 3] = "15.50";
            matRespuesto[73, 4] = "Guantes de jardinería reforzados.";

            // Fila 74
            matRespuesto[74, 0] = "FlexiPly";
            matRespuesto[74, 1] = "Suecia";
            matRespuesto[74, 2] = "82831";
            matRespuesto[74, 3] = "45.90";
            matRespuesto[74, 4] = "Tren de juguete eléctrico con rieles.";

            // Fila 75
            matRespuesto[75, 0] = "DataVault";
            matRespuesto[75, 1] = "Taiwán";
            matRespuesto[75, 2] = "93942";
            matRespuesto[75, 3] = "69.99";
            matRespuesto[75, 4] = "Router Wi-Fi de doble banda.";

            // Fila 76
            matRespuesto[76, 0] = "PuraVida";
            matRespuesto[76, 1] = "Costa Rica";
            matRespuesto[76, 2] = "10104";
            matRespuesto[76, 3] = "18.00";
            matRespuesto[76, 4] = "Té verde con jengibre (caja de 20).";

            // Fila 77
            matRespuesto[77, 0] = "ProGears";
            matRespuesto[77, 1] = "Reino Unido";
            matRespuesto[77, 2] = "12124";
            matRespuesto[77, 3] = "15.00";
            matRespuesto[77, 4] = "Nivel de burbuja magnético.";

            // Fila 78
            matRespuesto[78, 0] = "SoftDream";
            matRespuesto[78, 1] = "Portugal";
            matRespuesto[78, 2] = "13134";
            matRespuesto[78, 3] = "12.90";
            matRespuesto[78, 4] = "Sábanas de franela, tamaño matrimonial.";

            // Fila 79
            matRespuesto[79, 0] = "AutoShine";
            matRespuesto[79, 1] = "EE. UU.";
            matRespuesto[79, 2] = "14144";
            matRespuesto[79, 3] = "49.99";
            matRespuesto[79, 4] = "Pistola de limpieza a presión.";

            // Fila 80
            matRespuesto[80, 0] = "TechNova";
            matRespuesto[80, 1] = "Japón";
            matRespuesto[80, 2] = "54325";
            matRespuesto[80, 3] = "39.99";
            matRespuesto[80, 4] = "Ratón ergonómico inalámbrico.";

            // Fila 81
            matRespuesto[81, 0] = "EcoWear";
            matRespuesto[81, 1] = "Vietnam";
            matRespuesto[81, 2] = "98769";
            matRespuesto[81, 3] = "59.00";
            matRespuesto[81, 4] = "Zapatillas minimalistas de running.";

            // Fila 82
            matRespuesto[82, 0] = "AeroWheels";
            matRespuesto[82, 1] = "EE. UU.";
            matRespuesto[82, 2] = "11227";
            matRespuesto[82, 3] = "35.00";
            matRespuesto[82, 4] = "Candado de seguridad U-lock para bicicleta.";

            // Fila 83
            matRespuesto[83, 0] = "GourmetChef";
            matRespuesto[83, 1] = "Francia";
            matRespuesto[83, 2] = "67894";
            matRespuesto[83, 3] = "33.50";
            matRespuesto[83, 4] = "Máquina para hacer pasta casera.";

            // Fila 84
            matRespuesto[84, 0] = "PowerUp";
            matRespuesto[84, 1] = "China";
            matRespuesto[84, 2] = "33449";
            matRespuesto[84, 3] = "15.00";
            matRespuesto[84, 4] = "Adaptador de corriente universal de viaje.";

            // Fila 85
            matRespuesto[85, 0] = "AquaFlow";
            matRespuesto[85, 1] = "México";
            matRespuesto[85, 2] = "20214";
            matRespuesto[85, 3] = "19.99";
            matRespuesto[85, 4] = "Botella de agua reutilizable de acero.";

            // Fila 86
            matRespuesto[86, 0] = "StyleFit";
            matRespuesto[86, 1] = "Italia";
            matRespuesto[86, 2] = "76547";
            matRespuesto[86, 3] = "150.00";
            matRespuesto[86, 4] = "Cinturón de cuero genuino, hebilla plateada.";

            // Fila 87
            matRespuesto[87, 0] = "HomeLux";
            matRespuesto[87, 1] = "Alemania";
            matRespuesto[87, 2] = "88994";
            matRespuesto[87, 3] = "159.99";
            matRespuesto[87, 4] = "Robot limpiacristales automático.";

            // Fila 88
            matRespuesto[88, 0] = "SweetTreats";
            matRespuesto[88, 1] = "Argentina";
            matRespuesto[88, 2] = "41418";
            matRespuesto[88, 3] = "4.50";
            matRespuesto[88, 4] = "Bolsa de caramelos duros surtidos.";

            // Fila 89
            matRespuesto[89, 0] = "OfficePro";
            matRespuesto[89, 1] = "Canadá";
            matRespuesto[89, 2] = "10014";
            matRespuesto[89, 3] = "19.95";
            matRespuesto[89, 4] = "Calculadora científica avanzada.";

            // Fila 90
            matRespuesto[90, 0] = "MediCare";
            matRespuesto[90, 1] = "India";
            matRespuesto[90, 2] = "90005";
            matRespuesto[90, 3] = "1.50";
            matRespuesto[90, 4] = "Mascarillas faciales desechables (pack de 10).";

            // Fila 91
            matRespuesto[91, 0] = "UrbanArt";
            matRespuesto[91, 1] = "Brasil";
            matRespuesto[91, 2] = "25817";
            matRespuesto[91, 3] = "29.99";
            matRespuesto[91, 4] = "Caballlete de mesa para pintura.";

            // Fila 92
            matRespuesto[92, 0] = "SoundBliss";
            matRespuesto[92, 1] = "Corea del Sur";
            matRespuesto[92, 2] = "60610";
            matRespuesto[92, 3] = "299.00";
            matRespuesto[92, 4] = "Barra de sonido para TV con subwoofer.";

            // Fila 93
            matRespuesto[93, 0] = "AgriGrow";
            matRespuesto[93, 1] = "España";
            matRespuesto[93, 2] = "71721";
            matRespuesto[93, 3] = "9.00";
            matRespuesto[93, 4] = "Regadera de metal galvanizado.";

            // Fila 94
            matRespuesto[94, 0] = "FlexiPly";
            matRespuesto[94, 1] = "Suecia";
            matRespuesto[94, 2] = "82832";
            matRespuesto[94, 3] = "8.50";
            matRespuesto[94, 4] = "Cubo de Rubik de alta velocidad.";

            // Fila 95
            matRespuesto[95, 0] = "DataVault";
            matRespuesto[95, 1] = "Taiwán";
            matRespuesto[95, 2] = "93943";
            matRespuesto[95, 3] = "25.99";
            matRespuesto[95, 4] = "Hub USB 3.0 de 4 puertos.";

            // Fila 96
            matRespuesto[96, 0] = "PuraVida";
            matRespuesto[96, 1] = "Costa Rica";
            matRespuesto[96, 2] = "10105";
            matRespuesto[96, 3] = "7.99";
            matRespuesto[96, 4] = "Sal marina con hierbas finas.";

            // Fila 97
            matRespuesto[97, 0] = "ProGears";
            matRespuesto[97, 1] = "Reino Unido";
            matRespuesto[97, 2] = "12125";
            matRespuesto[97, 3] = "75.00";
            matRespuesto[97, 4] = "Lijadora orbital eléctrica.";

            // Fila 98
            matRespuesto[98, 0] = "SoftDream";
            matRespuesto[98, 1] = "Portugal";
            matRespuesto[98, 2] = "13135";
            matRespuesto[98, 3] = "22.50";
            matRespuesto[98, 4] = "Toalla de baño de algodón egipcio.";

            // Fila 99
            matRespuesto[99, 0] = "AutoShine";
            matRespuesto[99, 1] = "EE. UU.";
            matRespuesto[99, 2] = "14145";
            matRespuesto[99, 3] = "12.50";
            matRespuesto[99, 4] = "Ambientador de coche de larga duración.";

        }
    }
}
