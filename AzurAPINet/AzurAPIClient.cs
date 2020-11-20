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
using Jan0660.AzurAPINet.Enums;
namespace Jan0660.AzurAPINet
{
    /// <summary>
    /// for if the AzurAPIClient is using the database from a local download or from github
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// using database from filesystem
        /// </summary>
        Local,
        /// <summary>
        /// using database from github.com
        /// </summary>
        Web
    }
    public class AzurAPIClient
    {
        public readonly AzurAPIClientOptions Options;
        public readonly ClientType ClientType;
        /// <summary>
        /// the url/directory to get files from
        /// </summary>
        public string WorkingDirectory;
        private List<Ship> _ships = null;
        private Dictionary<string, Chapter> _chapters = null;
        private List<Event> _events = null;
        private List<BarrageItem> _barrage = null;
        private Dictionary<string, ChapterMemory> _memories = null;
        private Dictionary<string, Equipment> _equipments = null;
        private Dictionary<string, Dictionary<string, List<VoiceLine>>> _voiceLines = null;
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
            if (this._ships == null)
            {
                ships = JsonConvert.DeserializeObject<List<Ship>>(GetTextFile("ships.json"),
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }
);
                if (Options.EnableCaching)
                    this._ships = ships;
            }
            else
                ships = this._ships;
            return ships;
        }
        #region GetShip, GetShipBy<EnglishName,Code,Id,...>

        /// <summary>
        /// Searches for a ship using it's english name, code, id, japanese and chinese name, in this order
        /// </summary>
        /// <param name="query">The name of the ship you're searching for</param>
        /// <returns>the ship</returns>
        public Ship GetShip(string query)
            => GetShipByEnglishName(query)
               ?? GetShipByCode(query)
               ?? GetShipById(query)
               ?? GetShipByJapaneseName(query)
               ?? GetShipByChineseName(query)
               ?? GetShipByKoreanName(query);
        /// <summary>
        /// yes.
        /// </summary>
        /// <param name="waifu"></param>
        /// <returns>the waifu</returns>
        public Ship GetWaifu(string waifu) => GetShip(waifu);
        public Ship GetShipByEnglishName(string name)
            => GetAllShips().FirstOrDefault((ship) => ship.Names.en?.ToLower() == name?.ToLower());
        public Ship GetShipByCode(string code)
        => GetAllShips().FirstOrDefault((ship) => ship.Names.code.ToLower() == code?.ToLower());
        public Ship GetShipById(string id)
        => GetAllShips().FirstOrDefault((ship) => ship.Id.ToLower() == id?.ToLower());
        public Ship GetShipByJapaneseName(string name)
        => GetAllShips().FirstOrDefault((ship) => ship.Names.jp?.ToLower() == name?.ToLower());
        public Ship GetShipByChineseName(string name)
            => GetAllShips().FirstOrDefault((ship) => ship.Names.cn?.ToLower() == name?.ToLower());
        public Ship GetShipByKoreanName(string name)
        => GetAllShips().FirstOrDefault((ship) => ship.Names.kr?.ToLower() == name?.ToLower());
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
                != await GetTextFileAsync("version-info.json"));
        }
        public Dictionary<string, Chapter> GetAllChapters()
        {
            Dictionary<string, Chapter> dict;
            if (_chapters == null)
            {
                dict = JsonConvert.DeserializeObject<Dictionary<string, Chapter>>(GetTextFile("chapters.json"));
                if (Options.EnableCaching)
                    _chapters = dict;
            }
            else
                dict = _chapters;
            return dict;
        }
        public List<Event> GetAllEvents()
        {
            List<Event> list;
            if (_events == null)
            {
                list = JsonConvert.DeserializeObject<List<Event>>(GetTextFile("events.json"));
                if (Options.EnableCaching)
                    _events = list;
            }
            else
                list = _events;
            return list;
        }
        public List<BarrageItem> GetAllBarrage()
        {
            List<BarrageItem> list;
            if (_barrage == null)
            {
                list = JsonConvert.DeserializeObject<List<BarrageItem>>(GetTextFile("barrage.json"));
                if (Options.EnableCaching)
                    _barrage = list;
            }
            else
                list = _barrage;
            return list;
        }
        public List<BarrageItem> GetBarrageForShip(string name)
        {
            var sh = GetShip(name);
            if(sh != null)
                name = sh.Names.en;
            return GetAllBarrage().Where((b) => b.Ships.Count((s) => s.ToLower() == name?.ToLower()) != 0).ToList();
        }
        public Dictionary<string, ChapterMemory> GetAllMemories()
        {
            Dictionary<string, ChapterMemory> list;
            if (_memories == null)
            {
                list = JsonConvert.DeserializeObject<Dictionary<string, ChapterMemory>>(GetTextFile("memories.internal.json"));
                if (Options.EnableCaching)
                    _memories = list;
            }
            else
                list = _memories;
            return list;
        }
        /// <summary>
        /// get's a chapter by it's english,chinese, japanese or korean name
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ChapterMemory GetChapterMemory(string query)
        {
            query = query?.ToLower();
            var memories = GetAllMemories().Where((m) =>
            m.Value.Names.en.ToLower() == query |
            m.Value.Names.cn.ToLower() == query |
            m.Value.Names.jp.ToLower() == query |
            m.Value.Names.kr?.ToLower() == query
            );
            return memories.FirstOrDefault().Value;
        }
        public Dictionary<string, Equipment> GetAllEquipments()
        {
            Dictionary<string, Equipment> list;
            if (_equipments == null)
            {
                list = JsonConvert.DeserializeObject<Dictionary<string, Equipment>>(GetTextFile("equipments.json"));
                if (Options.EnableCaching)
                    _equipments = list;
            }
            else
                list = _equipments;
            return list;
        }
        public Dictionary<string, Dictionary<string, List<VoiceLine>>> GetAllVoiceLines()
        {
            Dictionary<string, Dictionary<string, List<VoiceLine>>> list;
            if (_voiceLines == null)
            {
                list = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<VoiceLine>>>>(GetTextFile("voice_lines.json"));
                if (Options.EnableCaching)
                    _voiceLines = list;
            }
            else
                list = _voiceLines;
            return list;
        }
        #region get file
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
            #if NETSTANDARD2_1
                return File.ReadAllTextAsync(WorkingDirectory + file);
            #else
                return Task.FromResult(File.ReadAllText(WorkingDirectory + file));
            #endif
        }
        #endregion
        #region ReloadXAsync
        public async Task ReloadShipsAsync()
        {
            var ships = JsonConvert.DeserializeObject<List<Ship>>(await GetTextFileAsync("ships.json"),
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }
);
            this._ships = ships;
        }
        public async Task ReloadChaptersAsync()
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Chapter>>(await GetTextFileAsync("chapters.json"));
            _chapters = dict;
        }
        public async Task ReloadEventsAsync()
        {
            var list = JsonConvert.DeserializeObject<List<Event>>(await GetTextFileAsync("events.json"));
            _events = list;
        }
        public async Task ReloadBarrageAsync()
        {
            var list = JsonConvert.DeserializeObject<List<BarrageItem>>(await GetTextFileAsync("barrage.json"));
            _barrage = list;
        }
        public async Task ReloadMemoriesAsync()
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, ChapterMemory>>(await GetTextFileAsync("memories.internal.json"));
            _memories = dict;
        }
        public async Task ReloadEquipmentsAsync()
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Equipment>>(await GetTextFileAsync("equipments.json"));
            _equipments = dict;
        }
        public async Task ReloadVoiceLinesAsync()
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<VoiceLine>>>>(await GetTextFileAsync("voice_lines.json"));
            _voiceLines = dict;
        }
        public Task ReloadEverythingAsync()
        {
            var tasks = new List<Task>() { ReloadShipsAsync(), ReloadChaptersAsync(), ReloadEventsAsync(), ReloadBarrageAsync(), ReloadMemoriesAsync(),
            ReloadEquipmentsAsync(),
            ReloadVoiceLinesAsync()};
            return Task.WhenAll(tasks);
        }
        #endregion
        #region get equipment
        public Equipment GetEquipmentByEnglishName(string name)
            => GetAllEquipments().FirstOrDefault(e=> e.Key.ToLower() == name?.ToLower()).Value
               ?? GetAllEquipments().FirstOrDefault(e => e.Value.Names.en?.ToLower() == name?.ToLower()).Value;
        public Equipment GetEquipmentByChineseName(string name)
            => GetAllEquipments().FirstOrDefault(e => e.Value.Names.cn?.ToLower() == name?.ToLower()).Value;
        public Equipment GetEquipmentByJapaneseName(string name)
            => GetAllEquipments().FirstOrDefault(e => e.Value.Names.jp?.ToLower() == name?.ToLower()).Value;
        public Equipment GetEquipmentByKoreanName(string name)
            => GetAllEquipments().FirstOrDefault(e => e.Value.Names.kr?.ToLower() == name?.ToLower()).Value;
        public Equipment GetEquipment(string name)
            => GetEquipmentByEnglishName(name) ??
                GetEquipmentByChineseName(name) ??
                GetEquipmentByJapaneseName(name) ??
                GetEquipmentByKoreanName(name);
        #endregion
        #region GetAllShipsFromFaction & aliases
        public List<Ship> GetAllShipsFromFaction(string faction)
            => GetAllShips().Where(s => s.Nationality?.ToLowerTrimmed() == faction?.ToLowerTrimmed()).ToList();
        public List<Ship> GetAllShipsFromNation(string nation)
            => GetAllShipsFromFaction(nation);
        public List<Ship> GetAllShipsFromNationality(string nationality)
            => GetAllShipsFromFaction(nationality);
        public List<Ship> GetAllShipsFromFaction(Nationality nationality)
            => GetAllShipsFromFaction(nationality.ToString());
        public List<Ship> GetAllShipsFromNationality(Nationality nationality)
            => GetAllShipsFromFaction(nationality.ToString());
        public List<Ship> GetAllShipsFromNation(Nationality nationality)
            => GetAllShipsFromFaction(nationality.ToString());
        #endregion
        #region GetAllShipsByLANGUAGE
        public List<Ship> GetAllShipsByEnglishName()
            => GetAllShips().Where(s => s.Names.en != null).ToList();
        public List<Ship> GetAllShipsByJapaneseName()
            => GetAllShips().Where(s => s.Names.jp != null).ToList();
        public List<Ship> GetAllShipsByChineseName()
            => GetAllShips().Where(s => s.Names.cn != null).ToList();
        public List<Ship> GetAllShipsByKoreanName()
            => GetAllShips().Where(s => s.Names.kr != null).ToList();
        public List<Ship> GetAllShipsByOfficialName()
            => GetAllShips().Where(s => s.Names.code != null).ToList();
        #endregion

        public Task ReloadCachedAsync()
        {
            var tasks = new List<Task>();
            if(_ships != null)
                tasks.Add(ReloadShipsAsync());
            if(_chapters != null)
                tasks.Add(ReloadChaptersAsync());
            if(_events != null)
                tasks.Add(ReloadEventsAsync());
            if(_barrage != null)
                tasks.Add(ReloadBarrageAsync());
            if(_memories != null)
                tasks.Add(ReloadMemoriesAsync());
            if(_equipments != null)
                tasks.Add(ReloadEquipmentsAsync());
            if(_voiceLines != null)
                tasks.Add(ReloadVoiceLinesAsync());
            return Task.WhenAll(tasks);
        }
    }
}
