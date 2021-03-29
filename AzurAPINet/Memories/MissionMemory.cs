using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Memories
{
    public class MissionMemory
    {
        [JsonProperty("names")]
        public readonly Names Names;
        [JsonProperty("lines")]
        public readonly LineMemory[] Lines;

        public override string ToString()
            => Names.en;
    }
}
