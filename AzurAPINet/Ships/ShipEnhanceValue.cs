using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    //[JsonConverter(typeof(EnhanceValueConverter))]
    public class ShipEnhanceValue
    {
        [JsonIgnore]
        public readonly bool CanEnhance = true;
        [JsonProperty("firepower")]
        public readonly int Firepower;
        [JsonProperty("torpedo")]
        public readonly int Torpedo;
        [JsonProperty("aviation")]
        public readonly int Aviation;
        [JsonProperty("reload")]
        public readonly int Reload;
        public ShipEnhanceValue()
        {

        }
        public ShipEnhanceValue(bool CanEnhance)
        {
            this.CanEnhance = CanEnhance;
        }
    }
}
