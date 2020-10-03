using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Jan0660.AzurAPINetCore.Converters;

namespace Jan0660.AzurAPINetCore.Ships
{
    //pain
    public class Ship
    {
        [JsonProperty("wikiUrl")]
        public string WikiUrl;
        [JsonProperty("id")]
        public string Id;
        [JsonProperty("names")]
        public ShipNames Names;
        [JsonProperty("class")]
        public string Class;
        [JsonProperty("nationality")]
        public string Nationality;
        [JsonProperty("hullType")]
        public string HullType;
        [JsonProperty("thumbnail")]
        public string Thumbnail;
        [JsonProperty("rarity")]
        public string Rarity;
        [JsonProperty("stars")]
        public ShipStars Stars;
        [JsonProperty("stats")]
        public ShipAllStats Stats;
        [JsonProperty("slots")]
        public Dictionary<string, ShipEquipmentSlot> Slots;
        [JsonProperty("enhanceValue")]
        [JsonConverter(typeof(EnhanceValueConverter))]
        public ShipEnhanceValue EnhanceValue;
        [JsonProperty("scrapValue")]
        [JsonConverter(typeof(ScrapValueConverter))]
        public ShipScrapValue ScrapValue;
        [JsonProperty("skills")]
        public List<ShipSkill> Skills;
        [JsonProperty("limitBreaks")]
        public List<List<string>> LimitBreaks;
        [JsonProperty("construction")]
        [JsonConverter(typeof(ConstructionInfoConverter))]
        public ShipConstructionInfo Construction;
        [JsonProperty("obtainedFrom")]
        public ShipObtainedFrom ObtainedFrom;
        [JsonProperty("skins")]
        public List<ShipSkin> Skins;
        [JsonProperty("misc")]
        public Dictionary<string, ShipMiscItem> Misc;
        [JsonProperty("gallery")]
        public List<ShipGalleryItem> Gallery;
    }
}
