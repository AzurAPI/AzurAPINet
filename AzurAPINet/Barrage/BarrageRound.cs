using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINet.Barrage
{
    public class BarrageRound
    {
        [JsonProperty("type")]
        public readonly string Type;
        [JsonProperty("dmgL")]
        public readonly float DamageLow;
        [JsonProperty("dmgM")]
        public readonly float DamageMedium;
        [JsonProperty("dmgH")]
        public readonly float DamageHigh;
        [JsonProperty("note")]
        public readonly string Note;
    }
}
