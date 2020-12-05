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
using RestSharp;
// very cool
// ReSharper disable InconsistentNaming
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
        Web,
        /// <summary>
        /// experimental support
        /// </summary>
        Hiei
    }
    public class AzurAPIClient
    {
        public const string Url = "https://raw.githubusercontent.com/AzurAPI/azurapi-js-setup/master/";
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
        private WebClient _webClient = new WebClient();

        private RestClient _restClient;
        // lol im lazy
        private bool IsHiei => ClientType == ClientType.Hiei;
        /// <summary>
        /// version info of loaded data / when client was created
        /// </summary>
        public DatabaseVersionInfo VersionInfo { get; private set; }

        public AzurAPIClient(ClientType clientType, AzurAPIClientOptions options = null)
        {
            options ??= new AzurAPIClientOptions();
            if (clientType == ClientType.Local && options.LocalPath == null)
                throw new Exception("options.LocalPath must be specified when using ClientType.Local");
            if (clientType == ClientType.Hiei)
            {
                _restClient = new RestClient(options.HieiUrl);
                _restClient.AddDefaultHeader("authorization", options.HieiPass);
            }

            this.ClientType = clientType;
            this.Options = options;
            VersionInfo = getVersionInfo();
        }
        /// <summary>
        /// Create new client which uses downloaded database
        /// </summary>
        /// <param name="workingDirectory">AzurAPI database location</param>
        public AzurAPIClient(string workingDirectory, AzurAPIClientOptions options)
        {
            ClientType = ClientType.Local;
            WorkingDirectory = workingDirectory;
            Options = options;
            VersionInfo = getVersionInfo();
        }
        /// <summary>
        /// Create new client that uses database from web
        /// </summary>
        public AzurAPIClient(AzurAPIClientOptions options)
        {
            ClientType = ClientType.Web;
            WorkingDirectory = Url;
            Options = options;
            VersionInfo = getVersionInfo();
        }

        public List<Ship> getAllShips()
        {
            List<Ship> ships;
            if (this._ships == null)
            {
                ships = JsonConvert.DeserializeObject<List<Ship>>(getTextFile("ships.json"),
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
        #region getShip, getShipBy<EnglishName,Code,Id,...>
        // TODO: all languages for hiei
        /// <summary>
        /// Searches for a ship using it's english name, code, id, japanese and chinese name, in this order, only uses english name and id for hiei
        /// </summary>
        /// <param name="query">The name of the ship you're searching for</param>
        /// <returns>the ship</returns>
        public Ship getShip(string query)
        {
            if (IsHiei)
            {
                var byEn = HieiQuery<Ship[]>("/ship/search", query);
                return byEn.Length == 0 ? HieiQuery<Ship>("/ship/id", query) : byEn[0];
            }
            return getShipByEnglishName(query)
                ?? getShipByCode(query)
                ?? getShipById(query)
                ?? getShipByJapaneseName(query)
                ?? getShipByChineseName(query)
                ?? getShipByKoreanName(query);
        }

        /// <summary>
        /// yes.
        /// </summary>
        /// <param name="waifu"></param>
        /// <returns>the waifu</returns>
        public Ship getWaifu(string waifu) => getShip(waifu);
        public Ship getShipByEnglishName(string name)
            => IsHiei ? HieiQuery<Ship>("/ship/search", name)
        : getAllShips().FirstOrDefault((ship) => ship.Names.en?.ToLower() == name?.ToLower());
        public Ship getShipByCode(string code)
        => getAllShips().FirstOrDefault((ship) => ship.Names.code.ToLower() == code?.ToLower());

        public Ship getShipById(string id)
        {
            if (IsHiei)
                return HieiQuery<Ship>("/ship/id", id);
            else
                return getAllShips().FirstOrDefault((ship) => ship.Id.ToLower() == id?.ToLower());
        }

        public Ship getShipByJapaneseName(string name)
        => getAllShips().FirstOrDefault((ship) => ship.Names.jp?.ToLower() == name?.ToLower());
        public Ship getShipByChineseName(string name)
            => getAllShips().FirstOrDefault((ship) => ship.Names.cn?.ToLower() == name?.ToLower());
        public Ship getShipByKoreanName(string name)
        => getAllShips().FirstOrDefault((ship) => ship.Names.kr?.ToLower() == name?.ToLower());
        #endregion
        #region getShipsByHullType, getShipsByRarity, getShipsByClass

        public IEnumerable<Ship> getShipsByHullType(string hullType)
            => IsHiei ? HieiQuery<IEnumerable<Ship>>("/ship/hullType", hullType.UnEnum()) : getAllShips().Where(
                s => s.HullType.ToLowerTrimmed() == hullType.ToLowerTrimmed()
            );

        public IEnumerable<Ship> getShipsByHullType(ShipHullType hullType)
            => getShipsByHullType(hullType.ToString());

        public IEnumerable<Ship> getShipsByRarity(string rarity)
            => IsHiei ? HieiQuery<IEnumerable<Ship>>("/ship/rarity", rarity.UnEnum()) : getAllShips().Where(
                s => s.Rarity.ToLowerTrimmed() == rarity.ToLowerTrimmed()
            );

        public IEnumerable<Ship> getShipsByRarity(ShipRarity rarity)
            => getShipsByRarity(rarity.ToString());

        public IEnumerable<Ship> getShipsByClass(string className)
            => getAllShips().Where(
                s => s.Class.ToLowerTrimmed() == className.ToLowerTrimmed()
                );
        #endregion
        public DatabaseVersionInfo getVersionInfo()
        {
            return JsonConvert.DeserializeObject<DatabaseVersionInfo>(getTextFile("version-info.json"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>If a new version of the AzurAPI database is available</returns>
        public async Task<bool> DatabaseUpdateAvailableAsync()
        {
            return (await _webClient.DownloadStringTaskAsync(
                "https://raw.githubusercontent.com/AzurAPI/azurapi-js-setup/master/version-info.json")
                != await getTextFileAsync("version-info.json"));
        }
        public Dictionary<string, Chapter> getAllChapters()
        {
            Dictionary<string, Chapter> dict;
            if (_chapters == null)
            {
                dict = JsonConvert.DeserializeObject<Dictionary<string, Chapter>>(getTextFile("chapters.json"));
                if (Options.EnableCaching)
                    _chapters = dict;
            }
            else
                dict = _chapters;
            return dict;
        }
        public List<Event> getAllEvents()
        {
            List<Event> list;
            if (_events == null)
            {
                list = JsonConvert.DeserializeObject<List<Event>>(getTextFile("events.json"));
                if (Options.EnableCaching)
                    _events = list;
            }
            else
                list = _events;
            return list;
        }
        public List<BarrageItem> getAllBarrage()
        {
            List<BarrageItem> list;
            if (_barrage == null)
            {
                list = JsonConvert.DeserializeObject<List<BarrageItem>>(getTextFile("barrage.json"));
                if (Options.EnableCaching)
                    _barrage = list;
            }
            else
                list = _barrage;
            return list;
        }
        public List<BarrageItem> getBarrageForShip(string name)
        {
            var sh = getShip(name);
            if(sh != null)
                name = sh.Names?.en;
            return getAllBarrage().Where((b) => b.Ships.Count((s) => s.ToLower() == name?.ToLower()) != 0).ToList();
        }
        public Dictionary<string, ChapterMemory> getAllMemories()
        {
            Dictionary<string, ChapterMemory> list;
            if (_memories == null)
            {
                list = JsonConvert.DeserializeObject<Dictionary<string, ChapterMemory>>(getTextFile("memories.internal.json"));
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
        public ChapterMemory getChapterMemory(string query)
        {
            query = query?.ToLower();
            var memories = getAllMemories().Where((m) =>
            m.Value.Names.en.ToLower() == query |
            m.Value.Names.cn.ToLower() == query |
            m.Value.Names.jp.ToLower() == query |
            m.Value.Names.kr?.ToLower() == query
            );
            return memories.FirstOrDefault().Value;
        }
        public Dictionary<string, Equipment> getAllEquipments()
        {
            Dictionary<string, Equipment> list;
            if (_equipments == null)
            {
                list = JsonConvert.DeserializeObject<Dictionary<string, Equipment>>(getTextFile("equipments.json"));
                if (Options.EnableCaching)
                    _equipments = list;
            }
            else
                list = _equipments;
            return list;
        }
        public Dictionary<string, Dictionary<string, List<VoiceLine>>> getAllVoiceLines()
        {
            Dictionary<string, Dictionary<string, List<VoiceLine>>> list;
            if (_voiceLines == null)
            {
                list = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<VoiceLine>>>>(getTextFile("voice_lines.json"));
                if (Options.EnableCaching)
                    _voiceLines = list;
            }
            else
                list = _voiceLines;
            return list;
        }
        #region get file
        /// <summary>
        /// gets the content of a file from the AzurAPI database
        /// </summary>
        /// <param name="file"></param>
        /// <returns>the bytes of the file</returns>
        public byte[] getFileBytes(string file)
        {
            if (ClientType == ClientType.Web)
            {
                return File.ReadAllBytes(WorkingDirectory + file);
            }
            // ClientType.Local
            else
                return _webClient.DownloadData(Url + file);
        }
        /// <summary>
        /// gets the content of a text file from the AzurAPI database
        /// </summary>
        /// <param name="file"></param>
        /// <returns>the text</returns>
        public string getTextFile(string file)
        {
            if (ClientType == ClientType.Local)
            {
                return File.ReadAllText(WorkingDirectory + file);
            }
            // ClientType.Web or Hiei
            else
                return _webClient.DownloadString(Url + file);
        }
        /// <summary>
        /// Only async when getting files from the web, File.ReadAllTextAsync was introduced in .net standard 2.1 aaa
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Task<string> getTextFileAsync(string file)
        {
            if (ClientType == ClientType.Local)
            {
#if NETSTANDARD2_1
                return File.ReadAllTextAsync(WorkingDirectory + file);
#else
                return Task.FromResult(File.ReadAllText(WorkingDirectory + file));
#endif
            }
            // ClientType.Web or Hiei
            else
                return _webClient.DownloadStringTaskAsync(Url + file);
        }
        #endregion
        #region ReloadXAsync
        public async Task ReloadShipsAsync()
        {
            if (_ships != null && VersionInfo.Ships.VersionNumber > getVersionInfo().Ships.VersionNumber)
                return;
            var ships = JsonConvert.DeserializeObject<List<Ship>>(await getTextFileAsync("ships.json"),
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }
);
            this._ships = ships;
        }
        public async Task ReloadChaptersAsync()
        {
            if (_ships != null && VersionInfo.Ships.VersionNumber < getVersionInfo().Ships.VersionNumber)
                return;
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Chapter>>(await getTextFileAsync("chapters.json"));
            _chapters = dict;
        }
        public async Task ReloadEventsAsync()
        {
            if (_ships != null && VersionInfo.Ships.VersionNumber < getVersionInfo().Ships.VersionNumber)
                return;
            var list = JsonConvert.DeserializeObject<List<Event>>(await getTextFileAsync("events.json"));
            _events = list;
        }
        public async Task ReloadBarrageAsync()
        {
            if (_ships != null && VersionInfo.Ships.VersionNumber < getVersionInfo().Ships.VersionNumber)
                return;
            var list = JsonConvert.DeserializeObject<List<BarrageItem>>(await getTextFileAsync("barrage.json"));
            _barrage = list;
        }
        public async Task ReloadMemoriesAsync()
        {
            if (_ships != null && VersionInfo.Ships.VersionNumber < getVersionInfo().Ships.VersionNumber)
                return;
            var dict = JsonConvert.DeserializeObject<Dictionary<string, ChapterMemory>>(await getTextFileAsync("memories.internal.json"));
            _memories = dict;
        }
        public async Task ReloadEquipmentsAsync()
        {
            if (_ships != null && VersionInfo.Equipments.VersionNumber < getVersionInfo().Equipments.VersionNumber)
                return;
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Equipment>>(await getTextFileAsync("equipments.json"));
            _equipments = dict;
        }
        public async Task ReloadVoiceLinesAsync()
        {
            if (_ships != null && VersionInfo.Ships.VersionNumber < getVersionInfo().Ships.VersionNumber)
                return;
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<VoiceLine>>>>(await getTextFileAsync("voice_lines.json"));
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
        public Equipment getEquipmentByEnglishName(string name)
            => IsHiei ? HieiQuery<Equipment[]>("/equip/search", name).FirstOrDefault() :
                getAllEquipments().FirstOrDefault(e=> e.Key.ToLower() == name?.ToLower()).Value
               ?? getAllEquipments().FirstOrDefault(e => e.Value.Names.en?.ToLower() == name?.ToLower()).Value;
        public Equipment getEquipmentByChineseName(string name)
            => getAllEquipments().FirstOrDefault(e => e.Value.Names.cn?.ToLower() == name?.ToLower()).Value;
        public Equipment getEquipmentByJapaneseName(string name)
            => getAllEquipments().FirstOrDefault(e => e.Value.Names.jp?.ToLower() == name?.ToLower()).Value;
        public Equipment getEquipmentByKoreanName(string name)
            => getAllEquipments().FirstOrDefault(e => e.Value.Names.kr?.ToLower() == name?.ToLower()).Value;
        public Equipment getEquipment(string name)
            => getEquipmentByEnglishName(name) ??
                getEquipmentByChineseName(name) ??
                getEquipmentByJapaneseName(name) ??
                getEquipmentByKoreanName(name);

        public IEnumerable<KeyValuePair<string, Equipment>> getEquipmentByNationality(string nationality)
            => getAllEquipments().Where(
                eq => eq.Value.Nationality.ToLowerTrimmed() == nationality.ToLowerTrimmed()
            );

        public IEnumerable<KeyValuePair<string, Equipment>> getEquipmentByNationality(Nationality nationality)
            => getEquipmentByNationality(nationality.ToString());

        public IEnumerable<KeyValuePair<string, Equipment>> getEquipmentByCategory(string category)
            => getAllEquipments().Where(
                eq => eq.Value.Category.ToLowerTrimmed() == category.ToLowerTrimmed()
            );

        public IEnumerable<KeyValuePair<string, Equipment>> getEquipmentByCategory(EquipmentCategory category)
            => getEquipmentByCategory(category.ToString());
        #endregion
        #region getAllShipsFromFaction & aliases
        public List<Ship> getAllShipsFromFaction(string faction)
            => getAllShips().Where(s => s.Nationality?.ToLowerTrimmed() == faction?.ToLowerTrimmed()).ToList();
        public List<Ship> getAllShipsFromNation(string nation)
            => getAllShipsFromFaction(nation);
        public List<Ship> getAllShipsFromNationality(string nationality)
            => getAllShipsFromFaction(nationality);
        public List<Ship> getAllShipsFromFaction(Nationality nationality)
            => getAllShipsFromFaction(nationality.ToString());
        public List<Ship> getAllShipsFromNationality(Nationality nationality)
            => getAllShipsFromFaction(nationality.ToString());
        public List<Ship> getAllShipsFromNation(Nationality nationality)
            => getAllShipsFromFaction(nationality.ToString());
        #endregion
        #region getAllShipsByLANGUAGE
        public List<Ship> getAllShipsByEnglishName()
            => getAllShips().Where(s => s.Names.en != null).ToList();
        public List<Ship> getAllShipsByJapaneseName()
            => getAllShips().Where(s => s.Names.jp != null).ToList();
        public List<Ship> getAllShipsByChineseName()
            => getAllShips().Where(s => s.Names.cn != null).ToList();
        public List<Ship> getAllShipsByKoreanName()
            => getAllShips().Where(s => s.Names.kr != null).ToList();
        public List<Ship> getAllShipsByOfficialName()
            => getAllShips().Where(s => s.Names.code != null).ToList();
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
/*
        private string HieiQuery(string url, string query)
        {
            var request = new RestRequest("/ship/id");
            request.AddQueryParameter("q", query);
            return _restClient.Get(request).Content;
        }
*/
        private T HieiQuery<T>(string url, string query)
        {
            var request = new RestRequest(url);
            request.AddQueryParameter("q", query);
            var content =  _restClient.Get(request).Content;
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
