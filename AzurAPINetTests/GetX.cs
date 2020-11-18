using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AzurAPINetTests.Static;

namespace AzurAPINetTests
{
    [TestClass]
    public class GetX
    {
        // check if methods dont throw exceptions on valid/null inputs
        [TestMethod]
        public void GetEquipmentByXName()
        {
            foreach (var eq in Client.GetAllEquipments())
            {
                Client.GetEquipment(eq.Value.Names.kr);
            }
            Client.GetEquipment(null);
        }
        [TestMethod]
        public void GetShip()
        {
            foreach (var ship in Client.GetAllShips())
            {
                Client.GetShip(ship.Names.kr);
            }
            Client.GetShip(null);
        }
        [TestMethod]
        public void GetChapterMemory()
        {
            foreach (var mem in Client.GetAllMemories())
            {
                Client.GetChapterMemory(mem.Value.Names.kr);
            }
            Client.GetChapterMemory(null);
        }
        [TestMethod]
        public void GetBarrageForShip()
        {
            foreach (var ship in Client.GetAllShips())
            {
                var b  = Client.GetBarrageForShip(ship.Names.en);
            }
            Client.GetBarrageForShip(null);
        }
    }
}