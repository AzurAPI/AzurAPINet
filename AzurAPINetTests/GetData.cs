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
            Client.GetAllShips();
        }
        [TestMethod]
        public void GetBarrage()
        {
            Client.GetAllBarrage();
        }
        [TestMethod]
        public void GetEquipment()
        {
            Client.GetAllEquipment();
        }
        [TestMethod]
        public void GetChapters()
        {
            Client.GetAllChapters();
        }
        [TestMethod]
        public void GetVoiceLines()
        {
            Client.GetAllVoiceLines();
        }
        [TestMethod]
        public void GetEvents()
        {
            Client.GetAllEvents();
        }
        [TestMethod]
        public void GetMemories()
        {
            Client.GetAllMemories();
        }
    }
}
