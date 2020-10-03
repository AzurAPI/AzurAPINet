using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore
{
    public class ShipEnhanceValue
    {
        [JsonIgnore]
        public bool CanEnhance;
        [JsonProperty("firepower")]
        public int Firepower;
        [JsonProperty("torpedo")]
        public int Torpedo;
        [JsonProperty("aviation")]
        public int Aviation;
        [JsonProperty("reload")]
        public int Reload;
    }
}
