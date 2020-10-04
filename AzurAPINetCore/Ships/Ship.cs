using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Jan0660.AzurAPINetCore.Converters;

namespace Jan0660.AzurAPINetCore.Ships
{
    //pain
    public  class Ship
    {
        [JsonProperty("wikiUrl")]
        public readonly string WikiUrl;
        [JsonProperty("id")]
        public readonly string Id;
        [JsonProperty("names")]
        public readonly ShipNames Names;
        [JsonProperty("class")]
        public readonly string Class;
        [JsonProperty("nationality")]
        public readonly string Nationality;
        [JsonProperty("hullType")]
        public readonly string HullType;
        [JsonProperty("thumbnail")]
        public readonly string Thumbnail;
        [JsonProperty("rarity")]
        public readonly string Rarity;
        [JsonProperty("stars")]
        public readonly ShipStars Stars;
        [JsonProperty("stats")]
        public readonly ShipAllStats Stats;
        [JsonProperty("slots")]
        public readonly Dictionary<string, ShipEquipmentSlot> Slots;
        [JsonProperty("enhanceValue")]
        [JsonConverter(typeof(EnhanceValueConverter))]
        public readonly ShipEnhanceValue EnhanceValue;
        [JsonProperty("scrapValue")]
        [JsonConverter(typeof(ScrapValueConverter))]
        public readonly ShipScrapValue ScrapValue;
        [JsonProperty("skills")]
        public readonly List<ShipSkill> Skills;
        [JsonProperty("limitBreaks")]
        public readonly List<List<string>> LimitBreaks;
        [JsonProperty("construction")]
        [JsonConverter(typeof(ConstructionInfoConverter))]
        public readonly ShipConstructionInfo Construction;
        [JsonProperty("obtainedFrom")]
        public readonly ShipObtainedFrom ObtainedFrom;
        [JsonProperty("skins")]
        public readonly List<ShipSkin> Skins;
        [JsonProperty("misc")]
        public readonly Dictionary<string, ShipMiscItem> Misc;
        [JsonProperty("gallery")]
        public readonly List<ShipGalleryItem> Gallery;
    }
}
