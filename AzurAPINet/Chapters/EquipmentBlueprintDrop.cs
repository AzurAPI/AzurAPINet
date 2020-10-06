using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class EquipmentBlueprintDrop
    {
        [JsonProperty("name")]
        public readonly string Name;
        [JsonProperty("tier")]
        public readonly string Tier;
    }
}
