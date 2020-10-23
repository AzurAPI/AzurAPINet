﻿using System;
using Jan0660.AzurAPINet;
using System.Threading.Tasks;
using System.Linq;
using Jan0660.AzurAPINet.Equipments;
using System.Collections.Generic;
using Jan0660.AzurAPINet.Ships;
using Jan0660.AzurAPINet.Enums;

namespace AzurAPINetCoreTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await Task.Delay(10000);
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Test start");
            AzurAPIClient client = new AzurAPIClient(
                new AzurAPIClientOptions());
            var Client = client;
            //var mem = client.GetChapterMemoryByName("prologue");
            //var yee = DateTimeOffset.FromUnixTimeMilliseconds((long)client.GetDatabaseVersionInfo().Ships.LastDataRefreshDate);
            //GetAllAll(client);
            // var ship = client.GetShip("javelin");
            //var s = new ShipStats(ship.Stats.BaseStats, ship.Stats.Level100, 50);
            //var urls = ship.Skins.First().GetSkinUrlsList();
            var ch = client.GetAllChapters();
            var nats = GetAllNationalities(client);
            var hulls = GetAllHullTypes(client);
            var skinRars = GetAllNewSkinRarities(client);
            var skinTypes = GetAllNewSkinTypes(client);
            var currencies = GetAllNewSkinCurrencies(client);
            var bars = GetAllBarrageTypes(client);
            var eqcs = GetEquipmentCategories(client);
            foreach (var ship in client.GetAllShips())
            {
                var e = ship.GetRarityEnum();
                var h = ship.GetHullTypeEnum();
            }
            foreach (var ev in client.GetAllEvents())
            {
                foreach (var skin in ev.NewShipsSkins)
                {
                    skin.GetCurrencyEnum();
                }
            }
            foreach (var eq in nats)
            {
                Console.WriteLine($"{eq.Replace(" ", "").Replace("-", "")}, ");
            }
            foreach (var eq in nats)
            {
                Console.WriteLine($"\"{eq}\"=>Nationality.{eq.Replace(" ", "").Replace("-", "")}, ");
            }
            //var rarities = GetAllRarities(client);
            Console.WriteLine($"Test took {stopwatch.ElapsedMilliseconds} milliseconds");
        }
        static void GetAllAll(AzurAPIClient Client)
        {
            var VoiceLines = Client.GetAllVoiceLines();
            var Ships = Client.GetAllShips();
            var Memories = Client.GetAllMemories();
            var Events = Client.GetAllEvents();
            var Equipment = Client.GetAllEquipment();
            var Chapters = Client.GetAllChapters();
            var Barrage = Client.GetAllBarrage();
            // enums
            foreach(var equipment in Client.GetAllEquipment())
            {
                equipment.Value.GetCategoryEnum();
            }
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
            foreach (var ship in client.GetAllEquipment())
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

    }
}