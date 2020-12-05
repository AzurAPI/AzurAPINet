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
        static void Main(string[] args)
        {
            //await Task.Delay(10000);
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Test start");
            AzurAPIClient Client = new AzurAPIClient(ClientType.Hiei, new AzurAPIClientOptions(){
                HieiUrl = "http://raspi:1024"});
            var bruh = Client.getShipsByRarity(ShipRarity.UltraRare);
            var sh = Client.getShipById("200");
            Console.WriteLine(sh.Names.en);
            Console.WriteLine(Client.getShip("200").Names.en);
            var eq = Client.getEquipmentByEnglishName("Single 102mm Auxiliary Gun");
            Console.WriteLine(eq.Names.en);
            //await WikiDemo();
            /*
            getAllAll(Client);
            var eq = Client.getEquipment(Client.getAllEquipments().First().Value.Names.cn);
            Console.WriteLine(eq.Names.cn);
            Console.WriteLine($"No. of ships: {Client.getAllShips().Count}");
            Console.WriteLine($"Takao's rarity: {Client.getShip("takao").Rarity}");
            Console.WriteLine($"Javelin's nationality: {Client.getShipByEnglishName("javelin").Nationality}");
            var client = Client;
            foreach(var ship in client.getAllShips())
            {
                foreach(var slot in ship.Slots.ToList())
                {
                    if (slot == null)
                        Console.WriteLine("LLLLL " + ship.Names.en);
                }
            }
            client.ReloadEverythingAsync().Wait();
            var l = getAllRetrofitGrades(client);
            var ships = client.getAllShips();
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
            var sh = client.getShip("javelin");
            */
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
            var ship = client.getShip("Z23");
            // alternative
            var ship2 = client.getShipByEnglishName("Z23");
            
            // query by id
            var ship3 = client.getShip("115");
            // alternative
            var ship4 = client.getShipById("115");
            
            // query for equipment
            var equipment = client.getEquipment("Quadruple 130mm (Mle 1932)");
            // alternative
            var equipment2 = client.getEquipmentByEnglishName("Quadruple 130mm (Mle 1932)");
            
            // get all ships
            var ships = client.getAllShips();
            
            // get all equipments
            var equipments = client.getAllEquipments();
            
            // get ships from nation
            var shipsFromIronBlood = client.getAllShipsFromNation("iron blood");
            var shipsFromSakuraEmpire = client.getAllShipsFromNation("Sakura Empire");
            var shipsFromRoyalNavy = client.getAllShipsFromNation("Royal Navy");
            
            // add this using statement to the top of your current file
            // using Jan0660.AzurAPINet.Enums;
            // alternatively you can use enums
            var shipsFromIronBlood2 = client.getAllShipsFromNation(Nationality.IronBlood);
            var shipsFromSakuraEmpire2 = client.getAllShipsFromNation(Nationality.SakuraEmpire);
            var shipsFromRoyalNavy2 = client.getAllShipsFromNation(Nationality.RoyalNavy);
            
            
            
        }
        static void getAllAll(AzurAPIClient Client)
        {
            try
            {
                //var VoiceLines = Client.getAllVoiceLines();
                //var Ships = Client.getAllShips();
                //var j = Client.getShip("javelin");
                //var Memories = Client.getAllMemories();
                //var Events = Client.getAllEvents();
                var Equipment = Client.getAllEquipments();
                var Chapters = Client.getAllChapters();
                var Barrage = Client.getAllBarrage();
                // enums
                foreach (var equipment in Client.getAllEquipments())
                {
                    equipment.Value.GetCategoryEnum();
                }
            }catch(Exception e)
            {
                
            }
        }
        #region ENUM PARSING STUFF IDK
        static List<string> getAllRetrofitGrades(AzurAPIClient client)
        {
            var res = new List<string>();
            foreach(var s in client.getAllShips())
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
        static List<string> getAllNewShipConstructionTypes(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var e in client.getAllEvents())
            {
                foreach (var s in e.NewShipsConstruction)
                {
                    if (!res.Contains(s.Type))
                        res.Add(s.Type);
                }
            }
            return res;
        }
        static List<string> getAllRarities(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var ship in client.getAllShips())
            {
                if (!res.Contains(ship.Rarity))
                    res.Add(ship.Rarity);
            }
            return res;
        }
        static List<string> getAllBarrageTypes(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var eventt in client.getAllBarrage())
            {
                if (!res.Contains(eventt.Type))
                    res.Add(eventt.Type);
            }
            return res;
        }
        static List<string> getAllNewSkinRarities(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var eventt in client.getAllEvents())
            {
                foreach (var skin in eventt.NewShipsSkins)
                {
                    if (!res.Contains(skin.Rarity))
                        res.Add(skin.Rarity);
                }
            }
            return res;
        }
        static List<string> getAllNewSkinCurrencies(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            List<string> gem = new List<string>();
            List<string> ruby = new List<string>();
            foreach (var eventt in client.getAllEvents())
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

        static List<string> getAllNewSkinTypes(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var eventt in client.getAllEvents())
            {
                foreach (var skin in eventt.NewShipsSkins)
                {
                    if (!res.Contains(skin.Type))
                        res.Add(skin.Type);
                }
            }
            return res;
        }
        static List<string> getAllNationalities(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var ship in client.getAllShips())
            {
                if (!res.Contains(ship.Nationality))
                    res.Add(ship.Nationality);
            }
            return res;
        }
        static List<string> getEquipmentCategories(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var ship in client.getAllEquipments())
            {
                if (!res.Contains(ship.Value.Category))
                    res.Add(ship.Value.Category);
            }
            return res;
        }
        static List<string> getAllHullTypes(AzurAPIClient client)
        {
            List<string> res = new List<string>();
            foreach (var ship in client.getAllShips())
            {
                if (!res.Contains(ship.HullType))
                    res.Add(ship.HullType);
            }
            return res;
        }
        static List<string> getAllBarrageItemHulls(AzurAPIClient client)
        {

            List<string> res = new List<string>();
            foreach (var bar in client.getAllBarrage())
            {
                if (!res.Contains(bar.Hull))
                    res.Add(bar.Hull);
            }
            return res;
        }
        static List<string> getAllEquipmentsStatsTiers(AzurAPIClient client)
        {
            var res = new List<string>();
            foreach (var eq in client.getAllEquipments())
            {
                foreach (var tier in eq.Value.Tiers)
                {
                    if (!res.Contains(tier.Value.Tier))
                        res.Add(tier.Value.Tier);
                }
            }
            return res;
        }
        static List<string> getAllBarageRoundTypes(AzurAPIClient client)
        {
            var res = new List<string>();
            foreach (var bar in client.getAllBarrage())
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
