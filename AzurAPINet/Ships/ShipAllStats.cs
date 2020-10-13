using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipAllStats
    {
        [JsonProperty("baseStats")]
        public readonly ShipStats BaseStats;
        [JsonProperty("level100")]
        public readonly ShipStats Level100;
        [JsonProperty("level120")]
        public readonly ShipStats Level120;
        [JsonProperty("level100Retrofit")]
        public readonly ShipStats Level100Retrofit;
        [JsonProperty("level120Retrofit")]
        public readonly ShipStats Level120Retrofit;
    }
}
