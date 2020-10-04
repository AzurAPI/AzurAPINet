using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class ClearRewards
    {
        [JsonProperty("coin")]
        public int Coin;
        [JsonProperty("cube")]
        public int Cube;
        [JsonProperty("ship")]
        public string Ship;
        [JsonProperty("oil")]
        public int Oil;
    }
}
