using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jan0660.AzurAPINet;
using static AzurAPINetTests.Static;
namespace AzurAPINetTests
{
    [TestClass]
    public class GetData
    {
        [TestMethod]
        public void GetShips()
        {
            var ships = Client.GetAllShips() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void GetBarrage()
        {
            var barrage = Client.GetAllBarrage() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void GetEquipment()
        {
            var equipment = Client.GetAllEquipment() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void GetChapters()
        {
            var chapters = Client.GetAllChapters() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void GetVoiceLines()
        {
            var voiceLines = Client.GetAllVoiceLines() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void GetEvents()
        {
            var events = Client.GetAllEvents() ?? throw new System.Exception("returned null");
        }
        [TestMethod]
        public void GetMemories()
        {
            var memories = Client.GetAllMemories() ?? throw new System.Exception("returned null");
        }
    }
}
