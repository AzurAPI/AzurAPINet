using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Ships
{
    // todo: make this stuff readonly
    public class ShipConstructionInfo
    {
        [JsonIgnore]
        public bool Constructable;
        [JsonProperty("constructionTime")]
        public TimeSpan ConstructionTime;
        [JsonProperty("availableIn")]
        public ShipConstructionAvailableIn AvailableIn;
    }
}
