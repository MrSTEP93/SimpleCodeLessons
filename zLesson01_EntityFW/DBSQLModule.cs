using System.Data;
using System.Data.SqlClient;

namespace Zlesson01_EntityFW
{
    internal class DBSQLModule
    {
        public static void OpenSqlConnection()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testDB_01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand command = new SqlCommand("SELECT * FROM t_customer");
                command.Connection = connection;
                connection.Open();

                Console.WriteLine("ServerVersion: {0}", connection.ConnectionString);
                Console.WriteLine("State: {0}", connection.State);
            }

        }
    }
}
