using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipTechPoints
    {
        [JsonProperty("collection")]
        public int Collection;
        [JsonProperty("maxLimitBreak")]
        public int MaxLimitBreak;
        [JsonProperty("maxLevel")]
        public int MaxLevel;
        [JsonProperty("total")]
        public int Total;
    }
}
