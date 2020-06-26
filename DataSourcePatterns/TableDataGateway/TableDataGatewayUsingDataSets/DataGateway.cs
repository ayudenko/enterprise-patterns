using System;
using System.Data;

namespace TableDataGatewayUsingDataSets
{
    abstract class DataGateway
    {

        public DataSetHolder Holder;
        public DataSet Data
        {
            get { return Holder.Data; }
        }

        public DataRow this[string key]
        {
            get
            {
                string filter = $"Email = '{key}'";
                return Table.Select(filter)[0];
            }
        }

        public DataTable Table
        {
            get { return Data.Tables[TableName]; }
        }

        abstract public String TableName { get; }

        protected DataGateway()
        {
            Holder = new DataSetHolder();
        }

        protected DataGateway(DataSetHolder holder)
        {
            Holder = holder;
        }

        public void LoadAll()
        {
            String commandString = String.Format("SELECT * FROM {0}", TableName);
            Holder.FillData(commandString, TableName);
        }

        public void LoadWhere(String whereClause)
        {
            String commandString = String.Format("SELECT * FROM '{0}' WHERE {1}", TableName, whereClause);
            Holder.FillData(commandString, TableName);
        }

        public Guid Insert(string email, string password, bool isActive)
        {
            Guid key = Guid.NewGuid();
            DataRow newRow = Table.NewRow();
            newRow["id"] = key;
            newRow["email"] = email;
            newRow["password"] = password;
            newRow["isActive"] = isActive;
            Table.Rows.Add(newRow);
            return key;
        }

    }
}
