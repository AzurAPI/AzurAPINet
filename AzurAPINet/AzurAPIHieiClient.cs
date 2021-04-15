using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Jan0660.AzurAPINet.Enums;
using Jan0660.AzurAPINet.Equipments;
using Jan0660.AzurAPINet.Ships;
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
            => HieiQuery<Ship[]>("/ship/search", name).FirstOrDefault();

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
            => HieiQuery<Equipment[]>("/equip/search", name).FirstOrDefault();

        /// <inheritdoc/>
        public override IEnumerable<Equipment> getEquipmentByCategory(string category)
            => HieiQuery<IEnumerable<Equipment>>("/equip/category", category.UnEnum());

        /// <inheritdoc/>
        public override IEnumerable<Equipment> getEquipmentByNationality(string nationality)
            => HieiQuery<IEnumerable<Equipment>>("/equip/nationality", nationality.UnEnum());

        /// <inheritdoc/>
        public override IEnumerable<Ship> getAllShipsFromFaction(string faction)
            => HieiQuery<Ship[]>("/ship/nationality", faction.UnEnum());

        public Ship[] ShipSearch(string query)
            => HieiQuery<Ship[]>("/ship/search", query);

        public Equipment[] EquipmentSearch(string query)
            => HieiQuery<Equipment[]>("/equip/search", query);

        public Task HieiUpdateAsync()
        {
            return _httpClient.PostAsync("/update", new StringContent(""));
        }

        private T HieiQuery<T>(string url, string query)
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("q", query ?? "");
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