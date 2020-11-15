using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipEquipmentSlots
    {
        [JsonProperty("1")]
        public ShipEquipmentSlot First;
        [JsonProperty("2")]
        public ShipEquipmentSlot Second;
        [JsonProperty("3")]
        public ShipEquipmentSlot Third;
        public List<ShipEquipmentSlot> ToList()
        => new List<ShipEquipmentSlot>(){First, Second, Third};
    }
}
