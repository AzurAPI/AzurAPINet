using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Barrage
{
    public class BarrageItem
    {
        [JsonProperty("id")]
        public readonly string Id;
        [JsonProperty("type")]
        public readonly string Type;
        [JsonProperty("icon")]
        public readonly string Icon;
        [JsonProperty("name")]
        public readonly string Name;
        [JsonProperty("image")]
        public readonly string Image;
        [JsonProperty("ships")]
        public readonly List<string> Ships;
        [JsonProperty("hull")]
        public readonly string Hull;
        [JsonProperty("rounds")]
        public readonly List<BarrageRound> Rounds;

        public override string ToString()
            => Name;
    }
}
