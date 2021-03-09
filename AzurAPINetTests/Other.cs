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
        public void getAllShipsFromFaction()
        {
            List<string> nationalities = new List<string>();
            foreach(var ship in Client.getAllShips())
            {
                if(!nationalities.Contains(ship.Nationality))
                    nationalities.Add(ship.Nationality);
            }

            foreach (var nat in nationalities)
            {
                var ls = Client.getAllShipsFromFaction(nat);
                if (ls.Count == 0)
                    throw new Exception();
            }
        }
        [TestMethod]
        public void getAllShipsFromFactionByEnum()
        {
            foreach(var val in (Nationality[])Enum.GetValues(typeof(Nationality)))
            {
                if(val == Nationality.None) continue;
                var ls = Client.getAllShipsFromFaction(val);
                if (ls == null | ls?.Count == 0)
                    throw new Exception();
            }
        }
        [TestMethod]
        public void getAllShipsByEnglishName()
        {
            Client.getAllShipsByEnglishName();
        }
        [TestMethod]
        public void getAllShipsByJapaneseName()
        {
            Client.getAllShipsByJapaneseName();
        }
        [TestMethod]
        public void getAllShipsByChineseName()
        {
            Client.getAllShipsByChineseName();
        }
        [TestMethod]
        public void getAllShipsByKoreanName()
        {
            Client.getAllShipsByKoreanName();
        }
        [TestMethod]
        public void getAllShipsByOfficialName()
        {
            Client.getAllShipsByOfficialName();
        }
    }
}
