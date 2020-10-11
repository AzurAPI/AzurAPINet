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
            AzurAPIClient client = new AzurAPIClient(new AzurAPIClientOptions());
            //AzurAPIClient client = new AzurAPIClient(new AzurAPIClientOptions());
            //var chapters = client.GetAllChapters();
            //var info = client.GetDatabaseVersionInfo();
            //var ships = client.GetAllShips();
            //var ss = client.GetShipByEnglishName("takao");
            //var s = client.GetShip("takao");
            //var ships = client.GetAllShips();
            //var events = client.GetAllEvents();
            // var evs = events.Where((e) => e.NewShipsSkins.Count != 0).ToList();
            //var b = client.GetAllBarrage();
            //var ba = b.Where((bar) => bar.Ships.Count != 1).ToList();
            //var t = client.GetBarrageForShip("takao");
            //var mems = client.GetAllMemories();
            //var eqs = client.GetAllEquipment();
            var vls = client.GetAllVoiceLines();
            /*
            int max = 0;
            List<Equipment> maxEq = new List<Equipment>();
            foreach(var eq in eqs)
            {
                foreach(var tier in eq.Value.Tiers)
                {
                    if (tier.Value.Stars.Count == 6) 
                    {
                        max = tier.Value.Stars.Count;
                        maxEq.Add(eq.Value);
                    }
                }
            }*/
            /*
            GC.Collect(int.MaxValue, GCCollectionMode.Forced, true);
            await Task.Delay(5000);
            GC.Collect(int.MaxValue, GCCollectionMode.Forced, true);
            await Task.Delay(5000);
            */
            Console.WriteLine($"Test took {stopwatch.ElapsedMilliseconds} milliseconds");
        }
    }
}
