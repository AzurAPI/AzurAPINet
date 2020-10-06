using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipMiscItem
    {
        [JsonProperty("name")]
        public readonly string Name;
        [JsonProperty("url")]
        public readonly string Url;
    }
}
