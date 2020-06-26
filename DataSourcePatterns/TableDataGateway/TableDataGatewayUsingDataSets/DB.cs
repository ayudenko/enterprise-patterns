using System.Data.SqlClient;

namespace TableDataGatewayUsingDataSets
{
    class DB
    {

        public static SqlConnection Connection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

    }
}
