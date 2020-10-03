using System;
using Jan0660.AzurAPINetCore;
using System.Threading.Tasks;
namespace AzurAPINetCoreTests
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Test start");
            //await Task.Delay(3000);
            AzurAPIClient client = new AzurAPIClient(@"D:\00.code\azurapi-js-setup\", new AzurAPIClientOptions());
            //var ships = client.GetAllShips();
            var ss = client.GetShipByEnglishName("takao");
            var s = client.GetShip("takao");
            Console.WriteLine($"Test took {stopwatch.ElapsedMilliseconds} milliseconds");
        }
    }
}
