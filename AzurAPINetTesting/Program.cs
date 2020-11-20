using System;
using Jan0660.AzurAPINet;
using System.Threading.Tasks;
using System.Linq;
using Jan0660.AzurAPINet.Equipments;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Jan0660.AzurAPINet.Ships;
using Jan0660.AzurAPINet.Enums;

namespace AzurAPINetCoreTests
{
    class Program
    {
        // ignore this trainwreck
        static async Task Main(string[] args)
        {
            //await Task.Delay(10000);
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Test start");
            AzurAPIClient Client = new AzurAPIClient(new AzurAPIClientOptions());
            await WikiDemo();
            GetAllAll(Client);
            var eq = Client.GetEquipment(Client.GetAllEquipments().First().Value.Names.cn);
            Console.WriteLine(eq.Names.cn);
            Console.WriteLine($"No. of ships: {Client.GetAllShips().Count}");
            Console.WriteLine($"Takao's rarity: {Client.GetShip("takao").Rarity}");
            Console.WriteLine($"Javelin's nationality: {Client.GetShipByEnglishName("javelin").Nationality}");
            var client = Client;
            foreach(var ship in client.GetAllShips())
            {
                foreach(var slot in ship.Slots.ToList())
                {
                    if (slot == null)
                        Console.WriteLine("LLLLL " + ship.Names.en);
                }
            }
            client.ReloadEverythingAsync().Wait();
            var l = GetAllRetrofitGrades(client);
            var ships = client.GetAllShips();
            foreach(var s in ships)
            {
                if (s.Retrofittable)
                {
                    foreach(var p in s.RetrofitProjects.ToList())
                    {
                        if(p.Grade != null)
                        {

                        }
                    }
                }
            }
            var sh = client.GetShip("javelin");
            Console.WriteLine($"Test took {stopwatch.ElapsedMilliseconds} milliseconds");
        }
        static async Task WikiDemo(){
            // dotnet add package AzurAPINet
            var client = new AzurAPIClient(new AzurAPIClientOptions());
            
            // check for update
            var isUpdateAvailable = await client.DatabaseUpdateAvailableAsync();
            // reload/update cached data
            await client.ReloadCachedAsync();
            
            // reload cached data to update it
            await client.ReloadEverythingAsync();
            // query a ship by name
            var ship = client.GetShip("Z23");
            // alternative
            var ship2 = client.GetShipByEnglishName("Z23");
            
            // query by id
            var ship3 = client.GetShip("115");
            // alternative
            var ship4 = client.GetShipById("115");
            
            // query for equipment
            var equipment = client.GetEquipment("Quadruple 130mm (Mle 1932)");
            // alternative
            var equipment2 = client.GetEquipmentByEnglishName("Quadruple 130mm (Mle 1932)");
            
            // get all ships
            var ships = client.GetAllShips();
            
            // get all equipments
            var equipments = client.GetAllEquipments();
            
            // get ships from nation
            var shipsFromIronBlood = client.GetAllShipsFromNation("iron blood");
            var shipsFromSakuraEmpire = client.GetAllShipsFromNation("Sakura Empire");
            var shipsFromRoyalNavy = client.GetAllShipsFromNation("Royal Navy");
            
            // add this using statement to the top of your current file
            // using Jan0660.AzurAPINet.Enums;
            // alternatively you can use enums
            var shipsFromIronBlood2 = client.GetAllShipsFromNation(Nationality.IronBlood);
            var shipsFromSakuraEmpire2 = client.GetAllShipsFromNation(Nationality.SakuraEmpire);
            var shipsFromRoyalNavy2 = client.GetAllShipsFromNation(Nationality.RoyalNavy);
            
            
            
        }
        static void GetAllAll(AzurAPIClient Client)
        {
            //var VoiceLines = Client.GetAllVoiceLines();
            var Ships = Client.GetAllShips();
            var j = Client.GetShip("javelin");
            var Memories = Client.GetAllMemories();
            var Events = Client.GetAllEvents();
            var Equipment = Client.GetAllEquipments();
            var Chapters = Client.GetAllChapters();
            var Barrage = Client.GetAllBarrage();
            // enums
            foreach (var equipment in Client.GetAllEquipments())
            {
                equipment.Value.GetCategoryEnum();
            }
        }
        #region ENUM PARSING STUFF IDK
        static List<string> GetAllRetrofitGrades(AzurAPIClient client)
        {
            var res = new List<string>();
            foreach(var s in client.GetAllShips())
            {
                if (s.Retrofittable)
                {
                    foreach(var p in s.RetrofitProjects.ToList())
                    {
                        if (!res.Contains(p.Grade))
                            res.Add(p.Grade);
                    }
                }
            }
            return res;
        }
        static List<string> GetAllNewShipConstructionTypes(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var e in client.GetAllEvents())
            {
                foreach (var s in e.NewShipsConstruction)
                {
                    if (!res.Contains(s.Type))
                        res.Add(s.Type);
                }
            }
            return res;
        }
        static List<string> GetAllRarities(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var ship in client.GetAllShips())
            {
                if (!res.Contains(ship.Rarity))
                    res.Add(ship.Rarity);
            }
            return res;
        }
        static List<string> GetAllBarrageTypes(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var eventt in client.GetAllBarrage())
            {
                if (!res.Contains(eventt.Type))
                    res.Add(eventt.Type);
            }
            return res;
        }
        static List<string> GetAllNewSkinRarities(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var eventt in client.GetAllEvents())
            {
                foreach (var skin in eventt.NewShipsSkins)
                {
                    if (!res.Contains(skin.Rarity))
                        res.Add(skin.Rarity);
                }
            }
            return res;
        }
        static List<string> GetAllNewSkinCurrencies(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            List<string> gem = new List<string>();
            List<string> ruby = new List<string>();
            foreach (var eventt in client.GetAllEvents())
            {
                foreach (var skin in eventt.NewShipsSkins)
                {
                    if (!res.Contains(skin.Currency))
                        res.Add(skin.Currency);
                    if (skin.GetCurrencyEnum() == NewSkinCurrency.Gem)
                        gem.Add($"{skin.Name} - {skin.SkinName}");
                    if (skin.GetCurrencyEnum() == NewSkinCurrency.Ruby)
                        ruby.Add($"{skin.Name} - {skin.SkinName}");
                }
            }
            return res;
        }

        static List<string> GetAllNewSkinTypes(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var eventt in client.GetAllEvents())
            {
                foreach (var skin in eventt.NewShipsSkins)
                {
                    if (!res.Contains(skin.Type))
                        res.Add(skin.Type);
                }
            }
            return res;
        }
        static List<string> GetAllNationalities(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var ship in client.GetAllShips())
            {
                if (!res.Contains(ship.Nationality))
                    res.Add(ship.Nationality);
            }
            return res;
        }
        static List<string> GetEquipmentCategories(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var ship in client.GetAllEquipments())
            {
                if (!res.Contains(ship.Value.Category))
                    res.Add(ship.Value.Category);
            }
            return res;
        }
        static List<string> GetAllHullTypes(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var ship in client.GetAllShips())
            {
                if (!res.Contains(ship.HullType))
                    res.Add(ship.HullType);
            }
            return res;
        }
        static List<string> GetAllBarrageItemHulls(AzurAPIClient client)
        {

            List<string> res = new List<string>();
            foreach (var bar in client.GetAllBarrage())
            {
                if (!res.Contains(bar.Hull))
                    res.Add(bar.Hull);
            }
            return res;
        }
        static List<string> GetAllEquipmentsStatsTiers(AzurAPIClient client)
        {
            var res = new List<string>();
            foreach (var eq in client.GetAllEquipments())
            {
                foreach (var tier in eq.Value.Tiers)
                {
                    if (!res.Contains(tier.Value.Tier))
                        res.Add(tier.Value.Tier);
                }
            }
            return res;
        }
        static List<string> GetAllBarageRoundTypes(AzurAPIClient client)
        {
            var res = new List<string>();
            foreach (var bar in client.GetAllBarrage())
            {
                foreach (var round in bar.Rounds)
                {
                    if (!res.Contains(round.Type))
                        res.Add(round.Type);
                }
            }
            return res;
        }
        #endregion
    }
}
