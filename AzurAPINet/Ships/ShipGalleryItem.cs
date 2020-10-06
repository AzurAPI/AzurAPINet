using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipGalleryItem
    {
        [JsonProperty("description")]
        public readonly string Description;
        [JsonProperty("url")]
        public readonly string Url;
    }
}
