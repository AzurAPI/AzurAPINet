using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jan0660.AzurAPINet;
using static AzurAPINetTests.Static;
namespace AzurAPINetTests
{
    [TestClass]
    public class getData
    {
        [TestMethod]
        public void getShips()
        {
            var ships = Client.getAllShips() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void getBarrage()
        {
            var barrage = Client.getAllBarrage() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void getEquipments()
        {
            var equipment = Client.getAllEquipments() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void getChapters()
        {
            var chapters = Client.getAllChapters() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void getVoiceLines()
        {
            var voiceLines = Client.getAllVoiceLines() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void getEvents()
        {
            var events = Client.getAllEvents() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void getMemories()
        {
            var memories = Client.getAllMemories() ?? throw new System.Exception("returned null");
        }
    }
}
