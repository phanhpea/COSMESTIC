using System;
using DAL;
using MySql.Data.MySqlClient;

namespace DAL
{
    class DBMySQLUtils
    {

        public static MySqlConnection
                 GetDBConnection()
        {
            // Connection String.
            string host = "localhost";
            int port = 3306;
            string database = "qlbh";
            string username = "root";
            string password = "0987862506Dpa";
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);
        
            

            return conn;
        }
       
    }
}