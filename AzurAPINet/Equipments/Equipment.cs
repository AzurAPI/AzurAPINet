using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Equipments
{
    public class Equipment
    {
        [JsonProperty("wikiUrl")]
        public readonly string WikiUrl;
        [JsonProperty("category")]
        public readonly string Category;
        [JsonProperty("names")]
        public readonly Names Names;
        [JsonProperty("type")]
        public readonly EquipmentType Type;
        [JsonProperty("nationality")]
        public readonly string Nationality;
        [JsonProperty("image")]
        public readonly string Image;
        [JsonProperty("fits")]
        public readonly EquipmentFits Fits;
        [JsonProperty("misc")]
        public readonly EquipmentMisc Misc;
        [JsonProperty("tiers")]
        public readonly Dictionary<string, EquipmentStats> Tiers;

        public override string ToString()
            => Names.en;
    }
}
