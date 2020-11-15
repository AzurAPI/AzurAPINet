using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static AzurAPINetTests.Static;
using Jan0660.AzurAPINet.Enums;
namespace AzurAPINetTests
{
    [TestClass]
    public class Other
    {
        [TestMethod]
        public void GetAllShipsFromFaction()
        {
            foreach(var ship in Client.GetAllShips())
            {
                Client.GetAllShipsFromFaction(ship.Nationality);
            }
        }
        [TestMethod]
        public void GetAllShipsFromFactionByEnum()
        {
            foreach(var ship in Client.GetAllShips())
            {
                Client.GetAllShipsFromNationality(ship.GetNationalityEnum());
            }
        }
        [TestMethod]
        public void GetAllShipsByEnglishName()
        {
            Client.GetAllShipsByEnglishName();
        }
        [TestMethod]
        public void GetAllShipsByJapaneseName()
        {
            Client.GetAllShipsByJapaneseName();
        }
        [TestMethod]
        public void GetAllShipsByChineseName()
        {
            Client.GetAllShipsByChineseName();
        }
        [TestMethod]
        public void GetAllShipsByKoreanName()
        {
            Client.GetAllShipsByKoreanName();
        }
        [TestMethod]
        public void GetAllShipsByOfficialName()
        {
            Client.GetAllShipsByOfficialName();
        }
    }
}
