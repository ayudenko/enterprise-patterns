using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace TableDataGatewayUsingDataSets
{
    class DataSetHolder
    {

        public DataSet Data = new DataSet();
        private Hashtable DataAdapters = new Hashtable();

        public DataTable this[string tableName]
        {
            get { return Data.Tables[tableName]; }
        }

        public void Update()
        {
            foreach (string table in DataAdapters.Keys)
            {
                ((SqlDataAdapter)DataAdapters[table]).Update(Data, table);
            }
        }

        public void FillData(string query, string tableName)
        {
            if (DataAdapters.Contains(tableName)) throw new Exception();
            SqlDataAdapter da = new SqlDataAdapter(query, DB.Connection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SQLQueries;Integrated Security=True;"));
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Fill(Data, tableName);
            DataAdapters.Add(tableName, da);
        }

    }
}
