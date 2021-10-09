using System;

using MySql.Data.MySqlClient;


namespace CapaDeDatos
{
    public class Modelo
    {
        public MySqlDataReader reader;
        public MySqlCommand command;
        public string username;
        public string password;
        public string ip;
        public string bdName = "escrito";

        public Modelo(string username, string password, string ip)
        {
            this.username = username;
            this.password = password;
            this.ip = ip;

            try
            {
                connection();
            }
            catch (MySqlException e)
            {
                throw new Exception($"{e.Number}\n{e.Message}");
            }
       }

        public void connection()
        {
            MySqlConnection myConnection = new MySqlConnection(
                "server=" + this.ip + ";" +
                "userid=" + this.username + ";" +
                "password=" + this.password + ";" +
                "database=" + this.bdName + ";" +
                "pooling=false;"
                );
            myConnection.Open();
            this.command = new MySqlCommand();
            this.command.Connection = myConnection;
        }

        public void EjecutarQuery(MySqlCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                throw new Exception($"{e.Number}\n{e.Message}");
            }
        }
    }
}
