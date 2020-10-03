using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Ships
{
    public class ShipGalleryItem
    {
        [JsonProperty("description")]
        public string Description;
        [JsonProperty("url")]
        public string Url;
    }
}
