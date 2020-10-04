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
        public readonly bool CanScrap = true;
        [JsonProperty("coin")]
        public readonly int Coin;
        [JsonProperty("oil")]
        public readonly int Oil;
        [JsonProperty("medal")]
        public readonly int Medal;
        public ShipScrapValue() { }
        public ShipScrapValue(bool CanScrap) { this.CanScrap = CanScrap; }
    }
}
