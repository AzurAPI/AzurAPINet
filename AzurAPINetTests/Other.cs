using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AzurAPINetTests.Static;
using Jan0660.AzurAPINet.Enums;
namespace AzurAPINetTests
{
    [TestClass]
    public class Other
    {
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
