using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using Jan0660.AzurAPINet.Ships;
using Jan0660.AzurAPINet.Chapters;
using System.Net;
using Jan0660.AzurAPINet.Events;
using Jan0660.AzurAPINet.Barrage;
using Jan0660.AzurAPINet.Memories;
using Jan0660.AzurAPINet.Equipments;
using Jan0660.AzurAPINet.VoiceLines;
using System.Net.Http;
using Jan0660.AzurAPINet.Client;
using Jan0660.AzurAPINet.Enums;
// very cool
// ReSharper disable InconsistentNaming
// ReSharper disable AssignNullToNotNullAttribute
namespace Jan0660.AzurAPINet
{
    /// <summary>
    /// the source for data
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// using database from filesystem
        /// </summary>
        Local,
        /// <summary>
        /// using database from github
        /// </summary>
        Web,
        /// <summary>
        /// Use Hiei for functions that it supports and GitHub for other
        /// </summary>
        HieiAndWeb,
        /// <summary>
        /// Use Hiei for functions that it supports and local for other
        /// </summary>
        HieiAndLocal
    }
    public class AzurAPIClient
    {
        public const string Url = "https://raw.githubusercontent.com/AzurAPI/azurapi-js-setup/master/";
        public readonly AzurAPIClientOptions Options;
        public readonly ClientType ClientType;
        public AzurAPIClientShip ship;
        public AzurAPIClientEquipment equipment;
        private Ship[] _ships = null;
        private Chapter[] _chapters = null;
        private Event[] _events = null;
        private BarrageItem[] _barrage = null;
        private Dictionary<string, ChapterMemory> _memories = null;
        private Equipment[] _equipments = null;
        private Dictionary<string, Dictionary<string, VoiceLine[]>> _voiceLines = null;

        private HttpClient _httpClient;
        // lol im lazy
        private bool IsHiei => ClientType == ClientType.HieiAndWeb || ClientType == ClientType.HieiAndLocal;
        private bool IsLocal => ClientType == ClientType.Local || ClientType == ClientType.HieiAndLocal;
        private bool IsWeb => ClientType == ClientType.HieiAndWeb || ClientType == ClientType.Web;
        /// <summary>
        /// version info of loaded data / when client was created
        /// </summary>
        public DatabaseVersionInfo VersionInfo { get; private set; }

        public AzurAPIClient(ClientType clientType, AzurAPIClientOptions options = null)
        {
            options ??= new AzurAPIClientOptions();
            this.ClientType = clientType;
            if (IsLocal && options.LocalPath == null)
                throw new Exception("options.LocalPath must be specified when using Local client");
            if (IsHiei)
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri(options.HieiUrl);
                _httpClient.DefaultRequestHeaders.Add("authorization", options.HieiPass);
            }

            this.ship = new AzurAPIClientShip(this);
            this.equipment = new AzurAPIClientEquipment(this);
            this.Options = options;
            VersionInfo = getVersionInfo();
        }
        /// <summary>
        /// Create new client which uses downloaded database
        /// </summary>
        /// <param name="workingDirectory">AzurAPI database location</param>
        public AzurAPIClient(string workingDirectory, AzurAPIClientOptions options)
        : this (ClientType.Local, new AzurAPIClientOptions()
        {
            LocalPath = workingDirectory
        })
        {
            options.LocalPath = workingDirectory;
            this.Options = options;
        }
        /// <summary>
        /// Create new client that uses database from web
        /// </summary>
        public AzurAPIClient(AzurAPIClientOptions options = null)
        : this(ClientType.Web, options ??= new AzurAPIClientOptions())
        { }

        public Ship[] getAllShips()
        {
            Ship[] ships;
            if (this._ships == null)
            {
                ships = JsonConvert.DeserializeObject<Ship[]>(getTextFile("ships.json"),
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
                return byEn == null | byEn?.Length == 0 ? HieiQuery<Ship>("/ship/id", query) : byEn[0];
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
            => IsHiei ? HieiQuery<Ship[]>("/ship/search", name).FirstOrDefault()
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
            => IsHiei ? HieiQuery<IEnumerable<Ship>>("/ship/shipClass", className) : getAllShips().Where(
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
            var webClient = new WebClient();
            return (await webClient.DownloadStringTaskAsync(
                "https://raw.githubusercontent.com/AzurAPI/azurapi-js-setup/master/version-info.json")
                != await getTextFileAsync("version-info.json"));
        }
        public Chapter[] getAllChapters()
        {
            Chapter[] dict;
            if (_chapters == null)
            {
                dict = JsonConvert.DeserializeObject<Chapter[]>(getTextFile("chapters.json"));
                if (Options.EnableCaching)
                    _chapters = dict;
            }
            else
                dict = _chapters;
            return dict;
        }
        public Event[] getAllEvents()
        {
            Event[] list;
            if (_events == null)
            {
                list = JsonConvert.DeserializeObject<Event[]>(getTextFile("events.json"));
                if (Options.EnableCaching)
                    _events = list;
            }
            else
                list = _events;
            return list;
        }
        public BarrageItem[] getAllBarrage()
        {
            BarrageItem[] list;
            if (_barrage == null)
            {
                list = JsonConvert.DeserializeObject<BarrageItem[]>(getTextFile("barrage.json"));
                if (Options.EnableCaching)
                    _barrage = list;
            }
            else
                list = _barrage;
            return list;
        }
        public IEnumerable<BarrageItem> getBarrageForShip(string name)
        {
            var sh = getShip(name);
            if (sh != null)
                name = sh.Names?.en;
            return getAllBarrage().Where((b) => b.Ships.Count((s) => s.ToLower() == name?.ToLower()) != 0);
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
        public Equipment[] getAllEquipments()
        {
            Equipment[] list;
            if (_equipments == null)
            {
                list = JsonConvert.DeserializeObject<Equipment[]>(getTextFile("equipments.json"));
                if (Options.EnableCaching)
                    _equipments = list;
            }
            else
                list = _equipments;
            return list;
        }
        public Dictionary<string, Dictionary<string, VoiceLine[]>> getAllVoiceLines()
        {
            Dictionary<string, Dictionary<string, VoiceLine[]>> list;
            if (_voiceLines == null)
            {
                list = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, VoiceLine[]>>>(getTextFile("voice_lines.json"));
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
            var webClient = new WebClient();
            if (IsWeb)
            {
                return webClient.DownloadData(Url + file);
            }
            // Local
            else
                return File.ReadAllBytes(Path.Combine(Options.LocalPath, file));
        }
        /// <summary>
        /// gets the content of a text file from the AzurAPI database
        /// </summary>
        /// <param name="file"></param>
        /// <returns>the text</returns>
        public string getTextFile(string file)
        {
            var webClient = new WebClient();
            if (IsWeb)
            {
                return webClient.DownloadString(Url + file);
            }
            // Local
            else
                return File.ReadAllText(Path.Combine(Options.LocalPath, file));
        }
        /// <summary>
        /// Only async when getting files from the web, File.ReadAllTextAsync was introduced in .net standard 2.1 aaa
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Task<string> getTextFileAsync(string file)
        {
            var webClient = new WebClient();
            if (IsWeb)
            {
                return webClient.DownloadStringTaskAsync(Url + file);
            }
            // Local
            else
#if NETSTANDARD2_1
                return File.ReadAllTextAsync(Path.Combine(Options.LocalPath, file));
#else
            return Task.FromResult(File.ReadAllText(Path.Combine(Options.LocalPath, file)));
#endif
        }
        #endregion
        #region ReloadXAsync
        public async Task ReloadShipsAsync()
        {
            if (_ships != null && VersionInfo.Ships.VersionNumber > getVersionInfo().Ships.VersionNumber)
                return;
            var ships = JsonConvert.DeserializeObject<Ship[]>(await getTextFileAsync("ships.json"),
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
            var dict = JsonConvert.DeserializeObject<Chapter[]>(await getTextFileAsync("chapters.json"));
            _chapters = dict;
        }
        public async Task ReloadEventsAsync()
        {
            if (_ships != null && VersionInfo.Ships.VersionNumber < getVersionInfo().Ships.VersionNumber)
                return;
            var list = JsonConvert.DeserializeObject<Event[]>(await getTextFileAsync("events.json"));
            _events = list;
        }
        public async Task ReloadBarrageAsync()
        {
            if (_ships != null && VersionInfo.Ships.VersionNumber < getVersionInfo().Ships.VersionNumber)
                return;
            var list = JsonConvert.DeserializeObject<BarrageItem[]>(await getTextFileAsync("barrage.json"));
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
            var dict = JsonConvert.DeserializeObject<Equipment[]>(await getTextFileAsync("equipments.json"));
            _equipments = dict;
        }
        public async Task ReloadVoiceLinesAsync()
        {
            if (_ships != null && VersionInfo.Ships.VersionNumber < getVersionInfo().Ships.VersionNumber)
                return;
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, VoiceLine[]>>>(await getTextFileAsync("voice_lines.json"));
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
            => IsHiei ? HieiQuery<Equipment[]>("/equip/search", name)?.FirstOrDefault() :
               getAllEquipments().FirstOrDefault(e => e.Names.en?.ToLower() == name?.ToLower());
        public Equipment getEquipmentByChineseName(string name)
            => getAllEquipments().FirstOrDefault(e => e.Names.cn?.ToLower() == name?.ToLower());
        public Equipment getEquipmentByJapaneseName(string name)
            => getAllEquipments().FirstOrDefault(e => e.Names.jp?.ToLower() == name?.ToLower());
        public Equipment getEquipmentByKoreanName(string name)
            => getAllEquipments().FirstOrDefault(e => e.Names.kr?.ToLower() == name?.ToLower());
        public Equipment getEquipment(string name)
            => getEquipmentByEnglishName(name) ??
                getEquipmentByChineseName(name) ??
                getEquipmentByJapaneseName(name) ??
                getEquipmentByKoreanName(name);

        public IEnumerable<Equipment> getEquipmentByNationality(string nationality)
            => IsHiei ? HieiQuery<IEnumerable<Equipment>>("/equip/nationality", nationality.UnEnum()) :
                getAllEquipments().Where(
                eq => eq.Nationality.ToLowerTrimmed() == nationality.ToLowerTrimmed()
            );

        public IEnumerable<Equipment> getEquipmentByNationality(Nationality nationality)
            => getEquipmentByNationality(nationality.ToString());

        public IEnumerable<Equipment> getEquipmentByCategory(string category)
            => IsHiei ? HieiQuery<IEnumerable<Equipment>>("/equip/category", category.UnEnum()) :
                getAllEquipments().Where(
                eq => eq.Category.ToLowerTrimmed() == category.ToLowerTrimmed()
            );

        public IEnumerable<Equipment> getEquipmentByCategory(EquipmentCategory category)
            => getEquipmentByCategory(category.ToString());
        #endregion
        #region getAllShipsFromFaction & aliases
        public IEnumerable<Ship> getAllShipsFromFaction(string faction)
            => IsHiei ? HieiQuery<Ship[]>("/ship/nationality", faction.UnEnum())
                : getAllShips().Where(s => s.Nationality?.ToLowerTrimmed() == faction?.ToLowerTrimmed());
        public IEnumerable<Ship> getAllShipsFromNation(string nation)
            => getAllShipsFromFaction(nation);
        public IEnumerable<Ship> getAllShipsFromNationality(string nationality)
            => getAllShipsFromFaction(nationality);
        public IEnumerable<Ship> getAllShipsFromFaction(Nationality nationality)
            => getAllShipsFromFaction(nationality.ToString());
        public IEnumerable<Ship> getAllShipsFromNationality(Nationality nationality)
            => getAllShipsFromFaction(nationality.ToString());
        public IEnumerable<Ship> getAllShipsFromNation(Nationality nationality)
            => getAllShipsFromFaction(nationality.ToString());
        #endregion
        #region getAllShipsByLANGUAGE
        public IEnumerable<Ship> getAllShipsByEnglishName()
            => getAllShips().Where(s => s.Names.en != null);
        public IEnumerable<Ship> getAllShipsByJapaneseName()
            => getAllShips().Where(s => s.Names.jp != null);
        public IEnumerable<Ship> getAllShipsByChineseName()
            => getAllShips().Where(s => s.Names.cn != null);
        public IEnumerable<Ship> getAllShipsByKoreanName()
            => getAllShips().Where(s => s.Names.kr != null);
        public IEnumerable<Ship> getAllShipsByOfficialName()
            => getAllShips().Where(s => s.Names.code != null);
        #endregion

        public Task ReloadCachedAsync()
        {
            var tasks = new List<Task>();
            if (_ships != null)
                tasks.Add(ReloadShipsAsync());
            if (_chapters != null)
                tasks.Add(ReloadChaptersAsync());
            if (_events != null)
                tasks.Add(ReloadEventsAsync());
            if (_barrage != null)
                tasks.Add(ReloadBarrageAsync());
            if (_memories != null)
                tasks.Add(ReloadMemoriesAsync());
            if (_equipments != null)
                tasks.Add(ReloadEquipmentsAsync());
            if (_voiceLines != null)
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
        public Task HieiUpdate()
        {
            return _httpClient.PostAsync("/update", new StringContent(""));
        }
        private T HieiQuery<T>(string url, string query)
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("q", query ?? "");
            //var request = new RestRequest(url);
            //request.AddQueryParameter("q", query);
            var h = url + "?" + queryString;
            var content = _httpClient.GetAsync(h).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(content,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }
                );
        }
    }
}
