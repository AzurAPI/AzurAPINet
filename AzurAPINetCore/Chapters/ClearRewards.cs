using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class ClearRewards
    {
        [JsonProperty("coin")]
        public readonly int Coin;
        [JsonProperty("cube")]
        public readonly int Cube;
        [JsonProperty("ship")]
        public readonly string Ship;
        [JsonProperty("oil")]
        public readonly int Oil;
    }
}
