using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AzurAPINetTests.Static;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzurAPINetTests
{
    [TestClass]
    public class ReloadXAsync
    {
        [TestMethod]
        public void ReloadShipsAsync()
        {
            Client.ReloadShipsAsync().Wait();
        }
        [TestMethod]
        public void ReloadChaptersAsync()
        {
            Client.ReloadChaptersAsync().Wait();
        }
        [TestMethod]
        public void ReloadEventsAsync()
        {
            Client.ReloadEventsAsync().Wait();
        }
        [TestMethod]
        public void ReloadBarrageAsync()
        {
            Client.ReloadBarrageAsync().Wait();
        }
        [TestMethod]
        public void ReloadMemoriesAsync()
        {
            Client.ReloadMemoriesAsync().Wait();
        }
        [TestMethod]
        public void ReloadEquipmentAsync()
        {
            Client.ReloadEquipmentAsync().Wait();
        }
        [TestMethod]
        public void ReloadVoiceLinesAsync()
        {
            Client.ReloadVoiceLinesAsync().Wait();
        }
    }
}
