using System;
using System.Collections.Generic;
using System.Text;
using Jan0660.AzurAPINet.Converters;
using Newtonsoft.Json;
namespace Jan0660.AzurAPINet.Equipments
{
    public class EquipmentStat
    {
        [JsonProperty("type")]
        public readonly string Type;
        [JsonProperty]
        [JsonConverter(typeof(BetterFloatConverter))]
        public readonly float min;
        [JsonProperty]
        [JsonConverter(typeof(BetterFloatConverter))]
        public readonly float max;
        [JsonProperty]
        public readonly string per;
        [JsonProperty]
        public readonly string value;
        [JsonProperty]
        public readonly string unit;
        [JsonProperty]
        public readonly int firing;
        [JsonProperty]
        public readonly int shell;
        [JsonProperty]
        public readonly string formatted;
    }
}
