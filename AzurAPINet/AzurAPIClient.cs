using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Jan0660.AzurAPINet.Ships;
using Jan0660.AzurAPINet.Chapters;
using System.Net;
using Jan0660.AzurAPINet.Events;
using Jan0660.AzurAPINet.Barrage;
using Jan0660.AzurAPINet.Memories;
using Jan0660.AzurAPINet.Equipments;
using Jan0660.AzurAPINet.VoiceLines;
using Newtonsoft.Json.Serialization;

namespace Jan0660.AzurAPINet
{
    /// <summary>
    /// for if the AzurAPIClient is using the database from a local download or from github
    /// </summary>
    public enum ClientType { Local, Web }
    public class AzurAPIClient
    {
        public readonly AzurAPIClientOptions Options;
        public readonly ClientType ClientType;
        public readonly string WorkingDirectory;
        public List<Ship> Ships { get; private set; } = null;
        public List<Chapter> Chapters { get; private set; } = null;
        public List<Event> Events { get; private set; } = null;
        public List<BarrageItem> Barrage { get; private set; } = null;
        public Dictionary<string, ChapterMemory> Memories { get; private set; } = null;
        public Dictionary<string, Equipment> Equipments { get; private set; } = null;
        public Dictionary<string, Dictionary<string, List<VoiceLine>>> VoiceLines { get; private set; } = null;
        /// <summary>
        /// Create new client which uses downloaded database
        /// </summary>
        /// <param name="workingDirectory">AzurAPI database location</param>
        public AzurAPIClient(string workingDirectory, AzurAPIClientOptions options)
        {
            ClientType = ClientType.Local;
            WorkingDirectory = workingDirectory;
            Options = options;
        }
        /// <summary>
        /// Create new client that uses database from web
        /// </summary>
        public AzurAPIClient(AzurAPIClientOptions options)
        {
            ClientType = ClientType.Web;
            WorkingDirectory = "https://raw.githubusercontent.com/AzurAPI/azurapi-js-setup/master/";
            Options = options;
        }

        public List<Ship> GetAllShips()
        {
            List<Ship> ships;
            if (this.Ships == null)
            {
                ships = JsonConvert.DeserializeObject<List<Ship>>(GetTextFile("ships.json"),
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }
);
                if (Options.EnableCaching)
                    this.Ships = ships;
            }
            else
                ships = this.Ships;
            return ships;
        }
        #region GetShip, GetShipBy<EnglishName,Code,Id,...>
        /// <summary>
        /// Searches for a ship using it's english name, code, id, japanese and chinese name, in this order
        /// </summary>
        /// <param name="query"></param>
        /// <returns>the goddamn ship</returns>
        public Ship GetShip(string query)
        {
            var ship = GetShipByEnglishName(query);
            if (ship != null)
                return ship;
            ship = GetShipByCode(query);
            if (ship != null)
                return ship;
            ship = GetShipById(query);
            if (ship != null)
                return ship;
            ship = GetShipByJapaneseName(query);
            if (ship != null)
                return ship;
            ship = GetShipByChineseName(query);
            if (ship != null)
                return ship;
            return null;
        }
        public Ship GetWaifu(string waifu) => GetShip(waifu);
        public Ship GetShipByEnglishName(string name)
        {
            var ships = GetAllShips();
            return ships.Where((ship) => ship.Names.en.ToLower() == name.ToLower()).FirstOrDefault();
        }
        public Ship GetShipByCode(string code)
        {
            var ships = GetAllShips();
            return ships.Where((ship) => ship.Names.code.ToLower() == code.ToLower()).FirstOrDefault();
        }
        public Ship GetShipById(string id)
        {
            var ships = GetAllShips();
            return ships.Where((ship) => ship.Id.ToLower() == id.ToLower()).FirstOrDefault();
        }
        public Ship GetShipByJapaneseName(string name)
        {
            var ships = GetAllShips();
            return ships.Where((ship) => ship.Names.jp?.ToLower() == name.ToLower()).FirstOrDefault();
        }
        public Ship GetShipByChineseName(string name)
        {
            var ships = GetAllShips();
            return ships.Where((ship) => ship.Names.cn?.ToLower() == name.ToLower()).FirstOrDefault();
        }
        public Ship GetShipByKoreanName(string name)
        {
            var ships = GetAllShips();
            return ships.Where((ship) => ship.Names.kr?.ToLower() == name.ToLower()).FirstOrDefault();
        }
        #endregion
        public DatabaseVersionInfo GetDatabaseVersionInfo()
        {
            return JsonConvert.DeserializeObject<DatabaseVersionInfo>(GetTextFile("version-info.json"));
        }
        public List<Chapter> GetAllChapters()
        {
            var list = new List<Chapter>();
            if (Chapters == null)
            {
                var dict = JsonConvert.DeserializeObject<Dictionary<string, Chapter>>(GetTextFile("chapters.json"));
                foreach (var pair in dict)
                {
                    list.Add(pair.Value);
                }
                if (Options.EnableCaching)
                    Chapters = list;
            }
            else
                list = Chapters;
            return list;
        }
        public List<Event> GetAllEvents()
        {
            List<Event> list;
            if (Events == null)
            {
                list = JsonConvert.DeserializeObject<List<Event>>(GetTextFile("events.json"));
                if (Options.EnableCaching)
                    Events = list;
            }
            else
                list = Events;
            return list;
        }
        public List<BarrageItem> GetAllBarrage()
        {
            List<BarrageItem> list;
            if (Barrage == null)
            {
                list = JsonConvert.DeserializeObject<List<BarrageItem>>(GetTextFile("barrage.json"));
                if (Options.EnableCaching)
                    Barrage = list;
            }
            else
                list = Barrage;
            return list;
        }
        public List<BarrageItem> GetBarrageForShip(string name)
        {
            return GetAllBarrage().Where((b) => b.Ships.Where((s) => s.ToLower() == name.ToLower()).Count() != 0).ToList();
        }
        public Dictionary<string, ChapterMemory> GetAllMemories()
        {
            Dictionary<string, ChapterMemory> list;
            if (Events == null)
            {
                list = JsonConvert.DeserializeObject<Dictionary<string, ChapterMemory>>(GetTextFile("memories.internal.json"));
                if (Options.EnableCaching)
                    Memories = list;
            }
            else
                list = Memories;
            return list;
        }
        public Dictionary<string, Equipment> GetAllEquipment()
        {
            Dictionary<string, Equipment> list;
            if (Events == null)
            {
                list = JsonConvert.DeserializeObject<Dictionary<string, Equipment>>(GetTextFile("equipments.json"));
                if (Options.EnableCaching)
                    Equipments = list;
            }
            else
                list = Equipments;
            return list;
        }
        public Dictionary<string, Dictionary<string, List<VoiceLine>>> GetAllVoiceLines()
        {
            Dictionary<string, Dictionary<string, List<VoiceLine>>> list;
            if (Events == null)
            {
                list = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<VoiceLine>>>>(GetTextFile("voice_lines.json"));
                if (Options.EnableCaching)
                    VoiceLines = list;
            }
            else
                list = VoiceLines;
            return list;
        }
        /// <summary>
        /// Gets the content of a file from the AzurAPI database
        /// </summary>
        /// <param name="file"></param>
        /// <returns>the bytes of the file</returns>
        public byte[] GetFileBytes(string file)
        {
            if (ClientType == ClientType.Web)
            {
                WebClient webClient = new WebClient();
                return webClient.DownloadData(WorkingDirectory + file);
            }
            // ClientType.Local
            else
                return File.ReadAllBytes(WorkingDirectory + file);
        }
        /// <summary>
        /// Gets the content of a text file from the AzurAPI database
        /// </summary>
        /// <param name="file"></param>
        /// <returns>the text</returns>
        public string GetTextFile(string file)
        {
            if (ClientType == ClientType.Web)
            {
                WebClient webClient = new WebClient();
                return webClient.DownloadString(WorkingDirectory + file);
            }
            // ClientType.Local
            else
                return File.ReadAllText(WorkingDirectory + file);
        }
    }
}
