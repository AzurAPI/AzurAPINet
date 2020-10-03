using Jan0660.AzurAPINetCore.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Ships
{
    //[JsonConverter(typeof(ScrapValueConverter))]
    public class ShipScrapValue
    {
        [JsonIgnore]
        public bool CanScrap = true;
        [JsonProperty("coin")]
        public int Coin;
        [JsonProperty("oil")]
        public int Oil;
        [JsonProperty("medal")]
        public int Medal;
    }
}
