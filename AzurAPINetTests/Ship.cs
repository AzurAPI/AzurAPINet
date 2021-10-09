using System;
using System.Collections.Generic;
using System.Linq;
using Jan0660.AzurAPINet.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AzurAPINetTests.Static;

namespace AzurAPINetTests
{
    [TestClass]
    public class Ship
    {
        [TestMethod("client.ship.get")]
        public void get()
        {
            foreach (var ship in Client.ship.all.get)
            {
                var sh = Client.ship.get(ship.Names.en);
                if (sh.Names.en != ship.Names.en)
                    throw new Exception("Names don't match!");
            }

            Client.ship.get(null);
        }

        [TestMethod]
        public void filterNationality()
        {
            List<string> nationalities = new List<string>();
            foreach (var ship in Client.getAllShips())
            {
                if (!nationalities.Contains(ship.Nationality))
                    nationalities.Add(ship.Nationality);
            }

            foreach (var nat in nationalities)
            {
                var ls = Client.ship.filter.Nationality(nat);
                if (!ls.Any())
                    throw new Exception();
            }
        }

        [TestMethod]
        public void filterNationalityEnum()
        {
            foreach (var val in (Nationality[]) Enum.GetValues(typeof(Nationality)))
            {
                //if(val == Nationality.None) continue;
                var ls = Client.ship.filter.Nationality(val);
                if (ls == null | ls?.Count() == 0)
                    throw new Exception();
            }
        }

        [TestMethod]
        public void filterRarity()
        {
            foreach (var ship in Client.ship.all.get)
            {
                var b = Client.ship.filter.Rarity(ship.Rarity);
                if (!b.Any())
                    throw new Exception();
            }
        }

        [TestMethod]
        public void filterRarityEnum()
        {
            foreach (var val in (ShipRarity[]) Enum.GetValues(typeof(ShipRarity)))
            {
                var b = Client.ship.filter.Rarity(val);
                if (!b.Any())
                    throw new Exception();
            }
        }

        [TestMethod]
        public void filterStars()
        {
            var stars = new[] {4, 5, 6};
            foreach (var val in stars)
            {
                var b = Client.ship.filter.Stars(val);
                if (!b.Any())
                    throw new Exception();
            }
        }

        [TestMethod]
        public void filterType()
        {
            foreach (var ship in Client.getAllShips())
            {
                Client.ship.filter.Type(ship.HullType);
            }
        }

        [TestMethod]
        public void filterTypeEnum()
        {
            foreach (var val in (ShipHullType[]) Enum.GetValues(typeof(ShipHullType)))
            {
                var b = Client.ship.filter.Type(val);
                if (!b.Any())
                    throw new Exception(val.ToString());
            }
        }
    }
}