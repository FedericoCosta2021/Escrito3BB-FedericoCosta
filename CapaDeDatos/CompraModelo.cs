using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CompraModelo : Modelo
    {
        public string id;
        public string cantidad;
        public string id_P;
        public CompraModelo(string username, string password, string ip) : base(username, password, ip) { }
        public void altaCompra(string cantidad, string id_P) {
            this.command.Parameters.Clear();
            this.command.CommandText = "INSERT INTO Compra (cantidad, id_P) VALUES (@cantidad, @id_P);";
            this.command.Parameters.AddWithValue("@cantidad", cantidad);
            this.command.Parameters.AddWithValue("@id_P", id_P);
            this.command.Prepare();
            EjecutarQuery(this.command);
        }
        public List<List<string>> getCompras()
        {
            this.command.Parameters.Clear();
            this.command.CommandText = "SELECT c.id, c.id_P, p.nombre, c.fechaAlta, c.cantidad, p.precio " +
                "FROM Compra c, Producto p " +
                "WHERE c.id_P = p.id;";
            this.command.Prepare();
            reader = command.ExecuteReader();
            List< List <string>> compras = new List<List<string>>();
            int x = 0;
            int y = 0;
            while (reader.Read())
            {
                List<string> compra = new List<string>();
                compra.Add(reader[0].ToString());
                compra.Add(reader[1].ToString());
                compra.Add(reader[2].ToString());
                compra.Add(reader[3].ToString());
                compra.Add(reader[4].ToString());
                compra.Add(reader[5].ToString());
                compras.Add(compra);
            }
            reader.Close();
            return compras;
        }
    }
}
