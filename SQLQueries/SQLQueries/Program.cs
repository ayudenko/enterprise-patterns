using SQLQueriesLib;
using System;
using System.Data.SqlClient;
using System.Text;

namespace SQLQueries
{
    sealed class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var query = new SqlQuery("(localdb)\\MSSQLLocalDB", "SQLQueries");
                query.GetActiveUsers();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }
    }
}
