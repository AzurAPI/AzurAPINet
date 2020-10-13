using Jan0660.AzurAPINet.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Events
{
#nullable enable
#nullable disable warnings
    public class NewShipConstruction
    {
        [JsonProperty("name")]
        public readonly string Name;
        [JsonProperty("rarity")]
        public readonly string Rarity;
        [JsonProperty("type")]
        public readonly string Type;
        [JsonProperty("construction_time")]
        public readonly TimeSpan? ConstructionTime;
        [JsonProperty("construction_chance")]
        [JsonConverter(typeof(BetterFloatConverter))]
        public readonly float? ConstructionChance;
        [JsonProperty("from")]
        public readonly string? From;
    }
}
