using System.Data;

namespace TableDataGatewayUsingDataSets
{
    class Program
    {
        static void Main(string[] args)
        {
            var userGateway = new UserGateway();
            userGateway.LoadAll();
            userGateway["andrey.yudenko@hiqo-solutions.com"]["email"] = "andrey.yudenko1@hiqo-solutions.com";
            userGateway.Holder.Update();
            var i = 0;
        }
    }
}
