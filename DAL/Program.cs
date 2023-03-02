using System;
using DAL;
using MySql.Data.MySqlClient;

namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBMySQLUtils.GetDBConnection(); 

            try
            {
                Console.WriteLine("Openning Connection ...");

                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
        
    }


}