using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace user
{
    internal class Connector
    {
    
        public static void Connect()
        {
            // connect to the database on localhost
            string connString = "Server=localhost;Port=3306";
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                Console.WriteLine("Connected to the database");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            
        }
    }
}
