using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore
{
    public class ShipEquipmentSlot
    {
        [JsonProperty("type")]
        public string Type;
        [JsonProperty("minEfficiency")]
        public int MinEfficiency;
        [JsonProperty("maxEfficiency")]
        public int MaxEfficiency;
    }
}
