using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jan0660.AzurAPINet;
namespace AzurAPINetTests
{
    [TestClass]
    public class GetData
    {
        [TestMethod]
        public void GetShips()
        {
            AzurAPIClient client = new AzurAPIClient(new AzurAPIClientOptions());
            client.GetAllShips();
        }
        [TestMethod]
        public void GetBarrage()
        {
            AzurAPIClient client = new AzurAPIClient(new AzurAPIClientOptions());
            client.GetAllBarrage();
        }
        [TestMethod]
        public void GetEquipment()
        {
            AzurAPIClient client = new AzurAPIClient(new AzurAPIClientOptions());
            client.GetAllEquipment();
        }
        [TestMethod]
        public void GetChapters()
        {
            AzurAPIClient client = new AzurAPIClient(new AzurAPIClientOptions());
            client.GetAllChapters();
        }
        [TestMethod]
        public void GetVoiceLines()
        {
            AzurAPIClient client = new AzurAPIClient(new AzurAPIClientOptions());
            client.GetAllVoiceLines();
        }
        [TestMethod]
        public void GetEvents()
        {
            AzurAPIClient client = new AzurAPIClient(new AzurAPIClientOptions());
            client.GetAllEvents();
        }
    }
}
