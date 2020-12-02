using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Equipments
{
    public class EquipmentType
    {
        [JsonProperty("focus")]
        public readonly string Focus;
        [JsonProperty("name")]
        public readonly string Name;

        public override string ToString()
            => Name;
    }
}
