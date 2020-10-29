using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipTechCollection
    {
        [JsonProperty("applicable")]
        public readonly string[] applicable = new string[0];
        [JsonProperty("stat")]
        public readonly string stat;
        [JsonProperty("bonus")]
        public readonly string bonus;
    }
}
