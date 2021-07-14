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
        public string Name;
        public string Rarity;
        public string Type;
        [JsonProperty("construction_time")]
        public TimeSpan? ConstructionTime;
        [JsonProperty("construction_chance")]
        [JsonConverter(typeof(BetterFloatConverter))]
        public float? ConstructionChance;
        public string? From;

        public override string ToString()
            => Name;
    }
}
