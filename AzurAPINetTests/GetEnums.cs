using Jan0660.AzurAPINet;
using Jan0660.AzurAPINet.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static AzurAPINetTests.Static;

namespace AzurAPINetTests
{
    [TestClass]
    public class getEnums
    {
        [TestMethod]
        public void getShipRarityEnum()
        {
            foreach (var s in Client.getAllShips())
            {
                s.GetRarityEnum();
            }
        }
        [TestMethod]
        public void getNewShipSkinCurrencyEnum()
        {
            foreach (var e in Client.getAllEvents())
            {
                foreach (var s in e.NewShipsSkins)
                {
                    s.GetCurrencyEnum();
                }
            }
        }
        [TestMethod]
        public void getBarrageTypeEnum()
        {
            foreach (var b in Client.getAllBarrage())
            {
                b.GetTypeEnum();
            }
        }
        [TestMethod]
        public void getShipHullTypeEnum()
        {
            foreach (var s in Client.getAllShips())
            {
                s.GetHullTypeEnum();
            }
        }
        [TestMethod]
        public void getEquipmentCategoryEnum()
        {
            foreach (var e in Client.getAllEquipments())
            {
                e.Value.GetCategoryEnum();
            }
        }
        [TestMethod]
        public void getShipNationalityEnum()
        {
            foreach (var s in Client.getAllShips())
            {
                s.GetNationalityEnum();
            }
        }
        [TestMethod]
        public void getEquipmentNationality()
        {
            foreach (var e in Client.getAllEquipments())
            {
                e.Value.GetNationalityEnum();
            }
        }
        [TestMethod]
        public void getNewShipConstructionRarity()
        {
            foreach (var e in Client.getAllEvents())
            {
                foreach (var s in e.NewShipsConstruction)
                {
                    s.GetRarityEnum();
                }
            }
        }
        [TestMethod]
        public void getNewShipConstructionType()
        {
            foreach (var e in Client.getAllEvents())
            {
                foreach (var s in e.NewShipsConstruction)
                {
                    s.GetTypeEnum();
                }
            }
        }
        [TestMethod]
        public void getNewShipSkinRarity()
        {
            foreach (var e in Client.getAllEvents())
            {
                foreach (var s in e.NewShipsSkins)
                {
                    s.GetRarityEnum();
                }
            }
        }
        [TestMethod]
        public void getEquipmentStatsRarity()
        {
            foreach (var e in Client.getAllEquipments())
            {
                foreach (var t in e.Value.Tiers)
                {
                    t.Value.GetRarityEnum();
                }
            }
        }
        [TestMethod]
        public void getNewShipSkinType()
        {
            foreach (var e in Client.getAllEvents())
            {
                foreach (var s in e.NewShipsSkins)
                {
                    s.GetTypeEnum();
                }
            }
        }
        [TestMethod]
        public void getEquipmentStatsTier()
        {
            foreach (var e in Client.getAllEquipments())
            {
                foreach (var t in e.Value.Tiers)
                {
                    t.Value.GetTierEnum();
                }
            }
        }
        [TestMethod]
        public void getBarrageRoundType()
        {
            foreach (var barrage in Client.getAllBarrage())
            {
                foreach (var round in barrage.Rounds)
                {
                    round.GetTypeEnum();
                }
            }
        }
        [TestMethod]
        public void getBarrageItemHullType()
        {
            foreach (var barrage in Client.getAllBarrage())
            {
                barrage.GetHullTypeEnum();
            }
        }
        [TestMethod]
        public void getGradeEnum()
        {
            foreach(var ship in Client.getAllShips())
            {
                if (ship.Retrofittable)
                {
                    foreach(var proj in ship.RetrofitProjects.ToList())
                    {
                        proj.GetGradeEnum();
                    }
                }
            }
        }
        [TestMethod]
        public void GetRetrofitHullType()
        {
            foreach(var ship in Client.getAllShips())
            {
                if (ship.Retrofittable)
                {
                    ship.GetRetrofitHullTypeEnum();
                }
            }
        }
    }
}
