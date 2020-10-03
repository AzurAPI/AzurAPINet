using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore
{
    public class ShipScrapValue
    {
        [JsonIgnore]
        public bool CanScrap;
        [JsonProperty("coin")]
        public int Coin;
        [JsonProperty("oil")]
        public int Oil;
        [JsonProperty("medal")]
        public int Medal;
    }
}
