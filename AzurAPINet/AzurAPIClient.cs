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
using System.Diagnostics.Contracts;

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
        /// <summary>
        /// the url/directory to get files from
        /// </summary>
        public string WorkingDirectory;
        public List<Ship> Ships { get; private set; } = null;
        public Dictionary<string, Chapter> Chapters { get; private set; } = null;
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
        /// <param name="query">The name of the ship you're searching for</param>
        /// <returns>the ship</returns>
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
        /// <summary>
        /// yes.
        /// </summary>
        /// <param name="waifu"></param>
        /// <returns>the waifu</returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns>If a new version of the AzurAPI database is available</returns>
        public async Task<bool> DatabaseUpdateAvailableAsync()
        {
            WebClient webClient = new WebClient();
            return (await webClient.DownloadStringTaskAsync(
                "https://raw.githubusercontent.com/AzurAPI/azurapi-js-setup/master/version-info.json")
                != GetTextFile("version-info.json"));
        }
        public Dictionary<string, Chapter> GetAllChapters()
        {
            var dict = new Dictionary<string, Chapter>();
            if (Chapters == null)
            {
                dict = JsonConvert.DeserializeObject<Dictionary<string, Chapter>>(GetTextFile("chapters.json"));
                if (Options.EnableCaching)
                    Chapters = dict;
            }
            else
                dict = Chapters;
            return dict;
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
            if (Memories == null)
            {
                list = JsonConvert.DeserializeObject<Dictionary<string, ChapterMemory>>(GetTextFile("memories.internal.json"));
                if (Options.EnableCaching)
                    Memories = list;
            }
            else
                list = Memories;
            return list;
        }
        /// <summary>
        /// get's a chapter by it's english,chinese or japanese name
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ChapterMemory GetChapterMemoryByName(string query)
        {
            query = query.ToLower();
            var memories = GetAllMemories().Where((m) =>
            m.Value.Names.en.ToLower() == query |
            m.Value.Names.cn.ToLower() == query |
            m.Value.Names.jp.ToLower() == query |
            m.Value.Names.kr?.ToLower() == query
            );
            return memories.FirstOrDefault().Value;
        }
        public Dictionary<string, Equipment> GetAllEquipment()
        {
            Dictionary<string, Equipment> list;
            if (Equipments == null)
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
            if (VoiceLines == null)
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
        /// <summary>
        /// Only async when getting files from the web, File.ReadAllTextAsync was introduced in .net standard 2.1 aaa
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Task<string> GetTextFileAsync(string file)
        {
            if (ClientType == ClientType.Web)
            {
                WebClient webClient = new WebClient();
                return webClient.DownloadStringTaskAsync(WorkingDirectory + file);
            }
            // ClientType.Local
            else
                return Task.FromResult(File.ReadAllText(WorkingDirectory + file));
        }
        #region ReloadXAsync
        public async Task ReloadShipsAsync()
        {
            var ships = JsonConvert.DeserializeObject<List<Ship>>(await GetTextFileAsync("ships.json"),
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }
);
            this.Ships = ships;
        }
        public async Task ReloadChaptersAsync()
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Chapter>>(await GetTextFileAsync("chapters.json"));
            Chapters = dict;
        }
        public async Task ReloadEventsAsync()
        {
            var list = JsonConvert.DeserializeObject<List<Event>>(await GetTextFileAsync("events.json"));
            Events = list;
        }
        public async Task ReloadBarrageAsync()
        {
            var list = JsonConvert.DeserializeObject<List<BarrageItem>>(await GetTextFileAsync("barrage.json"));
            Barrage = list;
        }
        public async Task ReloadMemoriesAsync()
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, ChapterMemory>>(await GetTextFileAsync("memories.internal.json"));
            Memories = dict;
        }
        public async Task ReloadEquipmentAsync()
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Equipment>>(await GetTextFileAsync("equipments.json"));
            Equipments = dict;
        }
        public async Task ReloadVoiceLinesAsync()
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<VoiceLine>>>>(await GetTextFileAsync("voice_lines.json"));
            VoiceLines = dict;
        }
        public Task ReloadEverythingAsync()
        {
            var tasks = new List<Task>() { ReloadShipsAsync(), ReloadChaptersAsync(), ReloadEventsAsync(), ReloadBarrageAsync(), ReloadMemoriesAsync(),
            ReloadEquipmentAsync(),
            ReloadVoiceLinesAsync()};
            return Task.WhenAll(tasks);
        }
        #endregion
    }
}
