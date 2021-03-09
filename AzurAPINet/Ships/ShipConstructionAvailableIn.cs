using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipConstructionAvailableIn
    {
        [JsonProperty]
        public readonly string light;
        [JsonProperty]
        public readonly string heavy;
        [JsonProperty]
        public readonly string aviation;
        [JsonProperty]
        public readonly string limited;
        [JsonProperty]
        public readonly string exchange;
    }
}
