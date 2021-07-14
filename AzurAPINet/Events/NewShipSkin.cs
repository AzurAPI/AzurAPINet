using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Events
{
    public class NewShipSkin
    {
        public string Name;
        public string Rarity;
        public string Type;
        public string Series;
        [JsonProperty("skin_name")]
        public string SkinName;
        public string Currency;
        public int Price;
        [JsonProperty("L2D")]
        public bool IsLive2D;
        [JsonProperty("bgID")]
        public string bgID;

        public override string ToString()
            => Name;
    }
}
