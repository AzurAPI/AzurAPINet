using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipConstructionAvailableIn
    {
        [JsonProperty]
        public readonly RegionBoolean light;
        [JsonProperty]
        public readonly RegionBoolean heavy;
        [JsonProperty]
        public readonly RegionBoolean aviation;
        [JsonProperty]
        public readonly string limited;
        [JsonProperty]
        public readonly string exchange;
    }
}
