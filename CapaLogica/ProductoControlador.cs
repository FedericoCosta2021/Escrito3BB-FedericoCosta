using CapaDeDatos;

namespace CapaLogica
{
    public static partial class Controlador
    {
        public static void nuevoProducto(string username, string password, string precio, string stock, string descripcion, string nombre)
        {
            ProductoModelo producto = new ProductoModelo(username, password, ip);
            producto.precio = precio;
            producto.stock = stock;
            producto.descripcion = descripcion;
            producto.nombre = nombre;
            producto.altaProducto();
        }

        public static System.Data.DataTable getProductos(string username, string password)
        {
            System.Data.DataTable d = new System.Data.DataTable(); //id, nombre, descripcion, fechaAlta, cantidad, precio
            d.Columns.Add("id");
            d.Columns.Add("nombre de producto");
            d.Columns.Add("descripcion");
            d.Columns.Add("fecha de ingreso");
            d.Columns.Add("cantidad");
            d.Columns.Add("precio por unidad");
            foreach (var item in new ProductoModelo(username, password, ip).getProducto(false))
                d.Rows.Add(item[0], item[1], item[2], item[3], item[4], item[5]);
            return d;
        }

        public static void borrarProducto(string user,string password,string id) => 
            new ProductoModelo(user,password,ip).bajaProducto(id);

        public static void modificarProducto(string user, string password, string id, string nombre, string descripcion,
            string precio, string stock, string isDeleted)
        {
            ProductoModelo p = new ProductoModelo(user, password, ip);
            p.stock = stock;
            p.id = id;
            p.precio = precio;
            p.nombre = nombre;
            p.descripcion = descripcion;
            p.isDeleted = isDeleted;
            p.modificacionProducto();
        }
    }
}
