using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore
{
    public class ShipAllStats
    {
        [JsonProperty("baseStats")]
        public ShipStats BaseStats;
        [JsonProperty("level100")]
        public ShipStats Level100;
        [JsonProperty("level120")]
        public ShipStats Level120;
    }
}
