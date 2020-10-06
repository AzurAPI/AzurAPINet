using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipSkin
    {
        [JsonProperty("name")]
        public readonly string Name;
        [JsonProperty("image")]
        public readonly string Image;
        [JsonProperty("background")]
        public readonly string Background;
        [JsonProperty("chibi")]
        public readonly string Chibi;
        [JsonProperty("info")]
        public readonly ShipSkinInfo Info;
    }
}
