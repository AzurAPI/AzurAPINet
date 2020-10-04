using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class Reward
    {
        [JsonProperty("count")]
        public int Count;
        [JsonProperty("item")]
        public string Item;
    }
}
