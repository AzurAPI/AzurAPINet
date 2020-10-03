using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Ships
{
    public class ShipStars
    {
        [JsonProperty("stars")]
        public string Stars;
        [JsonProperty("value")]
        public int Count;
    }
}
