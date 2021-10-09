using System;
using System.Windows.Forms;


using CapaLogica;

namespace GUI
{
    public partial class usernamePWform : Form
    {
        private string descripcion;
        private string nombre;
        private string stock;
        private string precio;
        private string type;
        private string id;
        private string isDeleted;

        public usernamePWform(string descripcion, string nombre, string stock, string precio)
        {
            this.descripcion = descripcion;
            this.nombre = nombre;
            this.stock = stock;
            this.precio = precio;
            InitializeComponent();
            type = "alta";
        }

        public usernamePWform(string descripcion, string nombre, string stock, string precio, string id, string isDeleted, bool tryDelete)
        {
            if (tryDelete)
                type = "baja";
            else
                type = "mod";

            this.descripcion = descripcion;
            this.nombre = nombre;
            this.stock = stock;
            this.precio = precio;
            this.id = id;
            this.isDeleted = isDeleted;
            InitializeComponent();
        }
        public usernamePWform(string stock, string id)
        {
            this.id = id;
            this.stock = stock;
            InitializeComponent();
            type = "compra";
        }

        public usernamePWform()
        {
            InitializeComponent();
            type = "login";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (type)
                {
                    case "login":
                        login();
                        break;
                    case "alta":
                        alta();
                        break;
                    case "mod":
                        mod("false");
                        break;
                    case "baja":
                        baja();
                        break;
                    case "compra":
                        compra();
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }


        public void login()
        {
            Controlador.ip = textBox1.Text;
            Controlador.getProductos(txtUsername.Text, txtClave.Text);
            Controlador.valid = true;
            Controlador.user = txtUsername.Text;
            Controlador.clave = txtClave.Text;
            Dispose();
        }
        public void alta()
        {
            Controlador.nuevoProducto(txtUsername.Text, txtClave.Text, precio, stock, descripcion, nombre);
            Dispose();
        }
        public void mod(string isDeleted)
        {
            Controlador.modificarProducto(txtUsername.Text,txtClave.Text, id, nombre, descripcion, precio, stock, isDeleted);
            Dispose();
        }
        public void baja()
        {
            try
            {
                Controlador.borrarProducto(txtUsername.Text, txtClave.Text, id);
                Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                mod("true");
            }
        }
        public void compra()
        {
            Controlador.nuevaCompra(txtUsername.Text,txtClave.Text,stock,id);
            Dispose();
        }
    }
}
