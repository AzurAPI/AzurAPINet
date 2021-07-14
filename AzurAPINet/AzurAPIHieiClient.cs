using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Jan0660.AzurAPINet.Barrage;
using Jan0660.AzurAPINet.Chapters;
using Jan0660.AzurAPINet.Enums;
using Jan0660.AzurAPINet.Equipments;
using Jan0660.AzurAPINet.Events;
using Jan0660.AzurAPINet.Ships;
using Jan0660.AzurAPINet.VoiceLines;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINet
{
    public class AzurAPIHieiClient : AzurAPIClient
    {
        public AzurAPIHieiClient(AzurAPIClientOptions options, ClientType clientType = ClientType.HieiAndWeb) : base(
            clientType, options)
        {
        }

        /// <summary>
        /// Search using english name or id
        /// </summary>
        /// <param name="query">english name or id</param>
        /// <returns></returns>
        public override Ship getShip(string query)
        {
            var byEn = HieiQuery<Ship[]>("/ship/search", query);
            return byEn == null | byEn?.Length == 0 ? HieiQuery<Ship>("/ship/id", query) : byEn[0];
        }

        /// <inheritdoc/>
        public override Ship getShipByEnglishName(string name)
            => ShipSearch(name).FirstOrDefault();

        /// <inheritdoc/>
        public override Ship getShipById(string id)
            => HieiQuery<Ship>("/ship/id", id);

        /// <inheritdoc/>
        public override IEnumerable<Ship> getShipsByHullType(string hullType)
            => HieiQuery<IEnumerable<Ship>>("/ship/hullType", hullType.UnEnum());

        /// <inheritdoc/>
        public override IEnumerable<Ship> getShipsByClass(string className)
            => HieiQuery<IEnumerable<Ship>>("/ship/shipClass", className);

        /// <inheritdoc/>
        public override IEnumerable<Ship> getShipsByRarity(string rarity)
            => HieiQuery<IEnumerable<Ship>>("/ship/rarity", rarity.UnEnum());

        /// <inheritdoc/>
        public override Equipment getEquipmentByEnglishName(string name)
            => HieiQuery<Equipment[]>("/equip/search", name)?.FirstOrDefault();

        /// <inheritdoc/>
        public override IEnumerable<Equipment> getEquipmentByCategory(string category)
            => HieiQuery<IEnumerable<Equipment>>("/equip/category", category.UnEnum());

        /// <inheritdoc/>
        public override IEnumerable<Equipment> getEquipmentByNationality(string nationality)
            => HieiQuery<IEnumerable<Equipment>>("/equip/nationality", nationality.UnEnum());

        /// <inheritdoc/>
        public override IEnumerable<Ship> getAllShipsFromFaction(string faction)
            => HieiQuery<Ship[]>("/ship/nationality", faction.UnEnum());

        /// <inheritdoc/>
        public override Dictionary<string, VoiceLine[]> getVoiceLinesById(string id)
            => HieiQuery<Dictionary<string, Dictionary<string, VoiceLine[]>>>("/voice/id", "200")["200"];

        public override Chapter getChapterById(string id)
            => id.Length > 1 ? null : HieiQuery<Chapter>("/chapter/code", id);

        public Ship[] ShipSearch(string query)
            => HieiQuery<Ship[]>("/ship/search", query);

        public Equipment[] EquipmentSearch(string query)
            => HieiQuery<Equipment[]>("/equip/search", query);

        public Event[] EventSearch(string query)
            => HieiQuery<Event[]>("/event/search", query);

        /// <summary>
        /// Search barrage by barrage name
        /// </summary>
        public BarrageItem[] BarrageSearchByName(string name)
            => HieiQuery<BarrageItem[]>("/barrage/searchBarrageByName", name);

        /// <summary>
        /// Search barrage by barrage ship name
        /// </summary>
        public BarrageItem[] BarrageSearchByShipName(string name)
            => HieiQuery<BarrageItem[]>("/barrage/searchBarrageByShip", name);

        public Ship GetRandomShip()
            => HieiQuery<Ship>("/ship/random");

        public Equipment GetRandomEquipment()
            => HieiQuery<Equipment>("/equip/random");

        public Task HieiUpdateAsync()
        {
            return _httpClient.PostAsync("/update", new StringContent(""));
        }

        public T HieiQuery<T>(string url, string query = null)
        {
            if (query != null)
            {
                NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
                queryString.Add("q", query);
                url += "?" + queryString;
            }
            else
                url += "?q";

            var req = _httpClient.GetAsync(url).Result;
            if (req.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Hiei returned 404 not found. Check if your Hiei server is up to date.");
            }
            var content = req.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(content,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }
            );
        }
    }
}