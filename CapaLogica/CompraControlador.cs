using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDeDatos;

namespace CapaLogica
{
    public static partial class Controlador
    {
        public static string ip;
        public static bool valid = false;
        public static string user;
        public static string clave; 

        public static void nuevaCompra(string username, string password,string cantidad, string id_P) =>
            new CompraModelo(username, password, ip).altaCompra(cantidad,id_P);
        public static System.Data.DataTable getCompras(string username, string password) {
            System.Data.DataTable d = new System.Data.DataTable(); //c.id, c.id_P, p.nombre, c.fechaAlta, c.cantidad, p.precio
            d.Columns.Add("id_C");
            d.Columns.Add("id_P");
            d.Columns.Add("nombre de producto");
            d.Columns.Add("fecha de compra");
            d.Columns.Add("cantidad");
            d.Columns.Add("precio por unidad");
            d.Columns.Add("total");
            foreach (var item in new CompraModelo(username, password, ip).getCompras())
                d.Rows.Add(item[0],item[1], item[2], item[3], item[4], item[5], (float.Parse(item[5]) * float.Parse(item[4])).ToString());
            return d;
        }
    }
}
