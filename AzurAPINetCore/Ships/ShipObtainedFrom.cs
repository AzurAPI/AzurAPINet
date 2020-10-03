using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Ships
{
    public class ShipObtainedFrom
    {
        [JsonProperty("obtainedFrom")]
        public string ObtainedFrom;
        [JsonProperty("maps")]
        public List<string> Maps;
    }
}
