using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class BaseXP
    {
        [JsonProperty("smallFleet")]
        public int SmallFleet;
        [JsonProperty("mediumFleet")]
        public int MediumFleet;
        [JsonProperty("largeFleet")]
        public int LargeFleet;
        [JsonProperty("bossFleet")]
        public int BossFleet;
    }
}
