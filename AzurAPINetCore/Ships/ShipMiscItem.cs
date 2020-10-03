using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Ships
{
    public class ShipMiscItem
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("url")]
        public string Url;
    }
}
