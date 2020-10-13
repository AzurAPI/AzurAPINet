using System;
using Jan0660.AzurAPINet;
using System.Threading.Tasks;
using System.Linq;
using Jan0660.AzurAPINet.Equipments;
using System.Collections.Generic;

namespace AzurAPINetCoreTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await Task.Delay(10000);
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Test start");
            AzurAPIClient client = new AzurAPIClient(@"D:\00.code\azurapi-js-setup\",
                new AzurAPIClientOptions());
            var Client = client;
            //var mem = client.GetChapterMemoryByName("prologue");
            //var yee = DateTimeOffset.FromUnixTimeMilliseconds((long)client.GetDatabaseVersionInfo().Ships.LastDataRefreshDate);
            //GetAllAll(client);
            Console.WriteLine($"Test took {stopwatch.ElapsedMilliseconds} milliseconds");
        }
        static void GetAllAll(AzurAPIClient Client)
        {
            Client.GetAllVoiceLines();
            Client.GetAllShips();
            Client.GetAllMemories();
            Client.GetAllEvents();
            Client.GetAllEquipment();
            Client.GetAllChapters();
            Client.GetAllBarrage();
        }
    }
}
