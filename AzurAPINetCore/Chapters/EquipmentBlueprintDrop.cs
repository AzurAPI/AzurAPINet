using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class EquipmentBlueprintDrop
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("tier")]
        public string Tier;
    }
}
