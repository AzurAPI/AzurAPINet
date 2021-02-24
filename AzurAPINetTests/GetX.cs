using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AzurAPINetTests.Static;

namespace AzurAPINetTests
{
    [TestClass]
    public class GetX
    {
        // check if methods dont throw exceptions on valid/null inputs
        [TestMethod]
        public void getEquipmentByXName()
        {
            foreach (var eq in Client.getAllEquipments())
            {
                Client.getEquipment(eq.Names.kr);
            }
            Client.getEquipment(null);
        }
        [TestMethod]
        public void getShip()
        {
            foreach (var ship in Client.getAllShips())
            {
                Client.getShip(ship.Names.kr);
            }
            Client.getShip(null);
        }
        [TestMethod]
        public void getChapterMemory()
        {
            foreach (var mem in Client.getAllMemories())
            {
                Client.getChapterMemory(mem.Value.Names.kr);
            }
            Client.getChapterMemory(null);
        }
        [TestMethod]
        public void getBarrageForShip()
        {
            foreach (var ship in Client.getAllShips())
            {
                var b  = Client.getBarrageForShip(ship.Names.en);
            }
            Client.getBarrageForShip(null);
        }
    }
}