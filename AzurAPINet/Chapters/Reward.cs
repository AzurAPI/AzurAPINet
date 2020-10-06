using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class Reward
    {
        [JsonProperty("count")]
        public readonly int Count;
        [JsonProperty("item")]
        public readonly string Item;
    }
}
