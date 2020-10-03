using System;
using Jan0660.AzurAPINetCore;
using System.Threading.Tasks;
namespace AzurAPINetCoreTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await Task.Delay(3000);
            AzurAPIClient client = new AzurAPIClient(@"D:\00.code\azurapi-js-setup\");
            client.EnableCaching = true;
            //var ships = client.GetAllShips();
            var ss = await client.GetShipByEnglishName("takao");
            var s = await client.GetShipByEnglishName("takao");
            Console.WriteLine("Hello World!");
        }
    }
}
