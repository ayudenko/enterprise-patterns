using System;
using System.Data.SqlClient;
using System.Text;

namespace SQLQueriesLib
{
    public class SqlQuery
    {

        private SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();

        public SqlQuery(string DataSource, string InitialCatalog, bool IntegratedSecurity = true)
        {
            _builder.DataSource = DataSource;
            _builder.InitialCatalog = InitialCatalog;
            _builder.IntegratedSecurity = IntegratedSecurity;
        }

        public void GetActiveUsers()
        {
            using (SqlConnection connection = new SqlConnection(_builder.ConnectionString))
            {
                Console.WriteLine("\nQuery data example");
                Console.WriteLine("=========================================\n");

                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT TOP 20 u.Email as Email, u.IsActive as IsActive ");
                sb.Append("FROM [User] u ");
                sb.AppendFormat("WHERE IsActive={0} ", 1);
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetBoolean(1));
                        }
                    }
                }
            }
        }
        
    }
}
