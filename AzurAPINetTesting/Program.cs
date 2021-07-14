using System;
using Jan0660.AzurAPINet;
using System.Threading.Tasks;
using System.Linq;
using Jan0660.AzurAPINet.Equipments;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Jan0660.AzurAPINet.Ships;
using Jan0660.AzurAPINet.Enums;
using Jan0660.AzurAPINet.VoiceLines;

namespace AzurAPINetCoreTests
{
    class Program
    {
        // ignore this trainwreck
        static async Task Main(string[] args)
        {
            //await Task.Delay(10000);
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            WikiDemo().Wait();
            Console.WriteLine("Test start");
            var client = new AzurAPIHieiClient(new()
            {
                HieiUrl = "http://localhost:1024",
                HieiPass = "password"
            });
            await V2Doc(client);
            AzurAPIClient Client = new AzurAPIClient(ClientType.Web);
            var rngSh = client.GetRandomShip();
            var rngEquip = client.GetRandomEquipment();
            var voice = client.getVoiceLinesById("200");
            var h = client.HieiQuery<Dictionary<string, Dictionary<string, VoiceLine[]>>>("/voice/id", "200")["200"];
            var eventSearch = client.EventSearch("sus");
            var barrageNameSearch = client.BarrageSearchByName("sn");
            var barrageShipNameSearch = client.BarrageSearchByShipName("Takao");
            var chapter = client.getChapterById("2");
            Client.getAllShips();
            //var bruh = Client.getAllShipsFromFaction("Iron Blood");
            var pain = Client.getAllShips();
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

        private static async Task V2Doc(AzurAPIHieiClient client)
        {
            // Ship
            client.ship.get("Akashi");
            client.ship.name("Akashi");
            client.ship.name("Akashi", "english");
            client.ship.id("200");
            // Sorting ships
            _ = client.ship.all.get;
            client.ship.all.id();
            client.ship.all.Name("english");
            // Filter ships
            client.ship.filter.Nationality(Nationality.IrisLibre);
            client.ship.filter.Nationality("Iris Libre");
            client.ship.filter.Faction(Nationality.IronBlood);
            client.ship.filter.Rarity(ShipRarity.Elite);
            client.ship.filter.Stars(3);
            client.ship.filter.Type("BB");
            client.ship.filter.Class("Takao");
            // Equipment
            client.equipment.name("Akashi");
            client.equipment.name("Akashi", "english");
            // Sorting equipment
            _ = client.equipment.all;
            // ????
        }

        static async Task WikiDemo()
        {
            var hieiClient = new AzurAPIHieiClient(new()
            {
                HieiUrl = "http://localhost:1024",
                HieiPass = "password"
            });
            var client = hieiClient;

            // asynchronously reload everything
            await client.ReloadEverythingAsync();
            // + specific methods like ReloadEquipmentsAsync, ReloadShipsAsync...

            // update Hiei server
            await hieiClient.HieiUpdateAsync();
            
            var ships = client.ship.all; // all ships
            
            var ship_1 = client.ship.get("takao"); // Get ship by ID or name in any language
            var ship_2 = client.ship.name("takao"); // Get ship by name in any language
            // get ship by name in specific language
            // one of "en", "jp", "cn" or "kr"
            var ship_3 = client.ship.name("takao", "en");
            
            var ship_4 = client.ship.id("200");
            
            var eq_1 = client.equipment.name("Single 120mm Main Gun");

            // get equipment by name in specific language
            // one of "en", "jp", "cn" or "kr"
            var eq_2 = client.equipment.name("Single 120mm Main Gun", "en");
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
                    equipment.GetCategoryEnum();
                }
            }
            catch (Exception e)
            {
            }
        }

        #region ENUM PARSING STUFF IDK

        static List<string> getAllRetrofitGrades(AzurAPIClient client)
        {
            var res = new List<string>();
            foreach (var s in client.getAllShips())
            {
                if (s.Retrofittable)
                {
                    foreach (var p in s.RetrofitProjects.ToList())
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
                if (!res.Contains(ship.Category))
                    res.Add(ship.Category);
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

        static List<byte> getAllEquipmentsStatsTiers(AzurAPIClient client)
        {
            var res = new List<byte>();
            foreach (var eq in client.getAllEquipments())
            {
                foreach (var tier in eq.Tiers)
                {
                    if (!res.Contains(tier.Tier))
                        res.Add(tier.Tier);
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

// pls push