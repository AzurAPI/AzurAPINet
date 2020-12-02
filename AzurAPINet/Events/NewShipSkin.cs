using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Events
{
    public class NewShipSkin
    {
        [JsonProperty("name")]
        public readonly string Name;
        [JsonProperty("rarity")]
        public readonly string Rarity;
        [JsonProperty("type")]
        public readonly string Type;
        [JsonProperty("series")]
        public readonly string Series;
        [JsonProperty("skin_name")]
        public readonly string SkinName;
        [JsonProperty("currency")]
        public readonly string Currency;
        [JsonProperty("price")]
        public readonly int Price;
        [JsonProperty("L2D")]
        public readonly bool IsLive2D;
        [JsonProperty("bgID")]
        public readonly string bgID;

        public override string ToString()
            => Name;
    }
}
