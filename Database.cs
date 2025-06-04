using MySql.Data.MySqlClient;
using System;

namespace SkySea
{
    public class Database
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "skysea";
        private string username = "root";
        private string password = "";

        public Database()
        {
            string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }
}