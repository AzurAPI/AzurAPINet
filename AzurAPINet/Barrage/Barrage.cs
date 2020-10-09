using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Barrage
{
    public class Barrage
    {
        [JsonProperty("id")]
        public readonly string Id;
        [JsonProperty("type")]
        public readonly string Type;
    }
}
