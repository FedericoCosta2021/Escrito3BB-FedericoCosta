using System;
using System.Windows.Forms;

using CapaLogica;


namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                new usernamePWform(dgvProductos.CurrentRow.Cells["descripcion"].Value.ToString(),
                    dgvProductos.CurrentRow.Cells["nombre de producto"].Value.ToString(),
                    dgvProductos.CurrentRow.Cells["cantidad"].Value.ToString(),
                    dgvProductos.CurrentRow.Cells["precio por unidad"].Value.ToString(),
                    dgvProductos.CurrentRow.Cells["id"].Value.ToString(),
                    "false",
                    true).ShowDialog();
            }
            catch { }
            reloadDgv();
        }

        private void cbDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDelete.Checked)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (cbMod.Checked)
            {
                clearTxt();
                txtDescripcion.Text = dgvProductos.CurrentRow.Cells["descripcion"].Value.ToString();
                txtName.Text= dgvProductos.CurrentRow.Cells["nombre de producto"].Value.ToString();
                txtStock.Text= dgvProductos.CurrentRow.Cells["cantidad"].Value.ToString();
                txtPrecio.Text= dgvProductos.CurrentRow.Cells["precio por unidad"].Value.ToString();
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if(!cbMod.Checked)
                new usernamePWform(txtDescripcion.Text, txtName.Text, txtStock.Text, txtPrecio.Text).ShowDialog();
            else
                new usernamePWform(txtDescripcion.Text,
                    txtName.Text, 
                    txtStock.Text, 
                    txtPrecio.Text,
                    dgvProductos.CurrentRow.Cells["id"].Value.ToString(),
                    "false",
                    false).ShowDialog();

            reloadDgv();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            new usernamePWform().ShowDialog();
            if (Controlador.valid)
            {
                reloadDgv();
                this.Visible = true;
            }
            else
                Dispose();

        }

        private void setDgvVisibility()
        {
            dgvProductos.Columns["id"].Visible = false;
            dgvProductos2.Columns["id"].Visible = true;
            dgvProductos2.Columns["descripcion"].Visible = false;
            dgvCompras.Columns["id_C"].Visible = false;
            dgvCompras.Columns["id_P"].Visible = false;
        }

        private void cbMod_CheckedChanged(object sender, EventArgs e)
        {
            clearTxt();
            if (cbMod.Checked)
                gbProductos.Text = "Modificar productos";
            else
                gbProductos.Text = "Nuevo producto";
        }
        private void reloadDgv()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Controlador.getProductos(Controlador.user, Controlador.clave);
            dgvProductos2.DataSource = null;
            dgvProductos2.DataSource = Controlador.getProductos(Controlador.user, Controlador.clave);
            dgvCompras.DataSource = null;
            dgvCompras.DataSource = Controlador.getCompras(Controlador.user, Controlador.clave);
            setDgvVisibility();

        }
        private void clearTxt()
        {
            txtPrecio.Clear();
            txtName.Clear();
            txtStock.Clear();
            txtDescripcion.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new usernamePWform(txtCantidad.Text, txtID.Text).ShowDialog();
            reloadDgv();
        }
        
    }
}
