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
    public class GetEnums
    {
        [TestMethod]
        public void GetShipRarityEnum()
        {
            foreach (var s in Client.GetAllShips())
            {
                s.GetRarityEnum();
            }
        }
        [TestMethod]
        public void GetNewShipSkinCurrencyEnum()
        {
            foreach (var e in Client.GetAllEvents())
            {
                foreach (var s in e.NewShipsSkins)
                {
                    s.GetCurrencyEnum();
                }
            }
        }
        [TestMethod]
        public void GetBarrageTypeEnum()
        {
            foreach (var b in Client.GetAllBarrage())
            {
                b.GetTypeEnum();
            }
        }
        [TestMethod]
        public void GetShipHullTypeEnum()
        {
            foreach (var s in Client.GetAllShips())
            {
                s.GetHullTypeEnum();
            }
        }
        [TestMethod]
        public void GetEquipmentCategoryEnum()
        {
            foreach (var e in Client.GetAllEquipment())
            {
                e.Value.GetCategoryEnum();
            }
        }
        [TestMethod]
        public void GetShipNationalityEnum()
        {
            foreach (var s in Client.GetAllShips())
            {
                s.GetNationalityEnum();
            }
        }
        [TestMethod]
        public void GetEquipmentNationality()
        {
            foreach (var e in Client.GetAllEquipment())
            {
                e.Value.GetNationalityEnum();
            }
        }
        [TestMethod]
        public void GetNewShipConstructionRarity()
        {
            foreach (var e in Client.GetAllEvents())
            {
                foreach (var s in e.NewShipsConstruction)
                {
                    s.GetRarityEnum();
                }
            }
        }
        [TestMethod]
        public void GetNewShipConstructionType()
        {
            foreach (var e in Client.GetAllEvents())
            {
                foreach (var s in e.NewShipsConstruction)
                {
                    s.GetTypeEnum();
                }
            }
        }
        [TestMethod]
        public void GetNewShipSkinRarity()
        {
            foreach (var e in Client.GetAllEvents())
            {
                foreach (var s in e.NewShipsSkins)
                {
                    s.GetRarityEnum();
                }
            }
        }
        [TestMethod]
        public void GetEquipmentStatsRarity()
        {
            foreach (var e in Client.GetAllEquipment())
            {
                foreach (var t in e.Value.Tiers)
                {
                    t.Value.GetRarityEnum();
                }
            }
        }
        [TestMethod]
        public void GetNewShipSkinType()
        {
            foreach (var e in Client.GetAllEvents())
            {
                foreach (var s in e.NewShipsSkins)
                {
                    s.GetTypeEnum();
                }
            }
        }
        [TestMethod]
        public void GetEquipmentStatsTier()
        {
            foreach (var e in Client.GetAllEquipment())
            {
                foreach (var t in e.Value.Tiers)
                {
                    t.Value.GetTierEnum();
                }
            }
        }
        [TestMethod]
        public void GetBarrageRoundType()
        {
            foreach (var barrage in Client.GetAllBarrage())
            {
                foreach (var round in barrage.Rounds)
                {
                    round.GetTypeEnum();
                }
            }
        }
        [TestMethod]
        public void GetBarrageItemHullType()
        {
            foreach (var barrage in Client.GetAllBarrage())
            {
                barrage.GetHullTypeEnum();
            }
        }
    }
}
