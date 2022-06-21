using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace zLesson02_Entity
{
    internal class DBSQLModule
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=testDB_01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static IDbConnection connection = new SqlConnection(connectionString);

        private static void OpenSqlConnection()
        {
            Console.WriteLine("Connecting to database...");
            string myState = "Connection status undefined";
            try
            {
                connection.Open();
                myState = "Connection successfull";
            }
            catch (Exception err)
            {
                myState = "Unable to establish connection to database: " + err.Message;
                //throw;
            } 
            finally
            {
                Console.WriteLine(myState + " connection state: {0}", connection.State);                
            }
        }
        private static void CloseSqlConnection()
        {
            connection.Close();
            Console.WriteLine("Connection was closed, connection state: {0}", connection.State);
        }
        private static IDataReader SelectCustomers()
        {
            IDbCommand command = new SqlCommand("SELECT Id,CustomerName,CustomerPhone FROM TCustomers");
            command.Connection = connection;
            Console.WriteLine("Executing command \"SELECT\"...");
            //if (connection.State == ConnectionState.Open)
            //{
                IDataReader reader = command.ExecuteReader();
                return reader;
            //}
        }
        public static void PrintCustomersFromDB()
        {
            OpenSqlConnection();
            IDataReader data = SelectCustomers();
            while (data.Read())
            {
                Console.WriteLine("ID: {0} \t Name: {1} \t Phone: {2}", data.GetInt32(0), data.GetString(1), data.GetString(2));
                //Console.WriteLine("Name: {0}", reader.GetString(0));
            }
            CloseSqlConnection();
        }
        public static List<CustomerProxy> SaveCustomers()
        {
            OpenSqlConnection();
            IDataReader data = SelectCustomers();
            List<CustomerProxy> customers = new List<CustomerProxy>();
            while (data.Read())
            {
                CustomerProxy customer = new CustomerProxy
                {
                    CustomerId = data.GetInt32(0),
                    CustomerName = data.GetString(1),
                    CustomerPhone = data.GetString(2)
                };
                customers.Add(customer);
            }
            CloseSqlConnection();
            return customers;
        }

    }
}
