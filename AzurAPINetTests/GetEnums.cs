using Jan0660.AzurAPINet;
using Jan0660.AzurAPINet.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzurAPINetTests
{
    [TestClass]
    public class GetEnums
    {
        public static AzurAPIClient client = new AzurAPIClient(new AzurAPIClientOptions());
        [TestMethod]
        public void GetShipRarityEnum()
        {
            foreach(var s in client.GetAllShips())
            {
                s.GetRarityEnum();
            }
        }
        [TestMethod]
        public void GetNewShipSkinCurrencyEnum()
        {
            foreach (var e in client.GetAllEvents())
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
            foreach (var b in client.GetAllBarrage())
            {
                b.GetBarrageTypeEnum();
            }
        }
        [TestMethod]
        public void GetShipHullTypeEnum()
        {
            foreach (var s in client.GetAllShips())
            {
                s.GetHullTypeEnum();
            }
        }
        [TestMethod]
        public void GetEquipmentCategoryEnum()
        {
            foreach (var e in client.GetAllEquipment())
            {
                e.Value.GetCategoryEnum();
            }
        }
        [TestMethod]
        public void GetShipNationalityEnum()
        {
            foreach (var s in client.GetAllShips())
            {
                s.GetNationalityEnum();
            }
        }
    }
}
