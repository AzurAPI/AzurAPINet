using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipEquipmentSlot
    {
        [JsonProperty("type")]
        public readonly string Type;
        [JsonProperty("minEfficiency")]
        public readonly int MinEfficiency;
        [JsonProperty("maxEfficiency")]
        public readonly int MaxEfficiency;
    }
}
