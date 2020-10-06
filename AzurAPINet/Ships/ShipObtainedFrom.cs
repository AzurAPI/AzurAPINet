using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipObtainedFrom
    {
        [JsonProperty("obtainedFrom")]
        public readonly string ObtainedFrom;
        [JsonProperty("maps")]
        public readonly List<string> Maps;
    }
}
