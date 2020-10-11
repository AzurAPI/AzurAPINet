using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Equipments
{
    public class EquipmentMisc
    {
        [JsonProperty("obtainedFrom")]
        public readonly string ObtainedFrom;
        [JsonProperty("notes")]
        public readonly string Notes;
        [JsonProperty("animation")]
        public readonly string Animation;
    }
}
