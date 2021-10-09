using System.Collections.Generic;


namespace CapaDeDatos
{
    public class ProductoModelo : Modelo
    {
        public string id;
        public string nombre;
        public string stock;
        public string descripcion;
        public string precio;
        public string isDeleted;

        public ProductoModelo(string username, string password, string ip) : base(username, password, ip){}

        public void altaProducto() {
            this.command.Parameters.Clear();
            this.command.CommandText = "INSERT INTO Producto (nombre, stock, descripcion, precio) VALUES (@nombre,@stock, @descripcion, @precio);";
            this.command.Parameters.AddWithValue("@nombre", this.nombre);
            this.command.Parameters.AddWithValue("@stock", this.stock);
            this.command.Parameters.AddWithValue("@descripcion", this.descripcion);
            this.command.Parameters.AddWithValue("@precio", this.precio);
            this.command.Prepare();
            EjecutarQuery(this.command);
        }

        public void modificacionProducto()
        {
            this.command.Parameters.Clear();
            this.command.CommandText = "UPDATE Producto SET stock=@stock, descripcion=@descripcion, precio=@precio, nombre=@nombre, isDeleted=@isDeleted " +
                "WHERE id = @id;";
            this.command.Parameters.AddWithValue("@id", this.id);
            this.command.Parameters.AddWithValue("@nombre", this.nombre);
            this.command.Parameters.AddWithValue("@stock", this.stock);
            this.command.Parameters.AddWithValue("@descripcion", this.descripcion);
            this.command.Parameters.AddWithValue("@precio", this.precio);
            this.command.Parameters.AddWithValue("@isDeleted", bool.Parse(this.isDeleted));
            this.command.Prepare();
            EjecutarQuery(this.command);
        }

        public void bajaProducto(string id)
        {
            this.command.Parameters.Clear();
            this.command.CommandText = "DELETE FROM Producto WHERE id=@id;";
            this.command.Parameters.AddWithValue("@id", id);
            this.command.Prepare();
            EjecutarQuery(this.command);
        }

        public List<List<string>> getProducto(bool isDeleted)
        {
            this.command.Parameters.Clear();
            this.command.CommandText = "SELECT id, nombre,descripcion , fechaAlta, stock, precio " +
                "FROM Producto WHERE isDeleted=@isDeleted;";
            this.command.Parameters.AddWithValue("@isDeleted",isDeleted);
            this.command.Prepare();
            reader = command.ExecuteReader();
            List<List<string>> productos = new List<List<string>>();
            while (reader.Read())
            {
                List<string> producto = new List<string>();
                producto.Add(reader[0].ToString());
                producto.Add(reader[1].ToString());
                producto.Add(reader[2].ToString());
                producto.Add(reader[3].ToString());
                producto.Add(reader[4].ToString());
                producto.Add(reader[5].ToString());
                productos.Add(producto);
            }
            reader.Close();
            return productos;
        }
    }
}
