namespace TableDataGatewayUsingDataSets
{
    class UserGateway : DataGateway
    {

        public override string TableName
        {
            get { return "[User]"; }
        }

    }
}
