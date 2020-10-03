using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore
{
    public class ShipSkin
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("image")]
        public string Image;
        [JsonProperty("background")]
        public string Background;
        [JsonProperty("chibi")]
        public string Chibi;
        [JsonProperty("info")]
        public ShipSkinInfo Info;
    }
}
