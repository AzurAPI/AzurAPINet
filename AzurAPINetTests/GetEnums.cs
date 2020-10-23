using Jan0660.AzurAPINet;
using Jan0660.AzurAPINet.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            foreach(var s in Client.GetAllShips())
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
                b.GetBarrageTypeEnum();
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
    }
}
