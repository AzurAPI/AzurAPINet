using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class BaseXP
    {
        [JsonProperty("smallFleet")]
        public readonly int SmallFleet;
        [JsonProperty("mediumFleet")]
        public readonly int MediumFleet;
        [JsonProperty("largeFleet")]
        public readonly int LargeFleet;
        [JsonProperty("bossFleet")]
        public readonly int BossFleet;
    }
}
