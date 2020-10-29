using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINet.Ships
{
#nullable enable
#nullable disable warnings
    public class ShipTechStats
    {
        [JsonProperty("collection")]
        public readonly ShipTechCollection? Collection;
        [JsonProperty("maxLevel")]
        public readonly ShipTechCollection? MaxLevel;
    }
}
