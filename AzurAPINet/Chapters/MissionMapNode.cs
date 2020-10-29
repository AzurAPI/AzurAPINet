using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class MissionMapNode
    {
        [JsonProperty]
        public readonly int x;
        [JsonProperty]
        public readonly int y;
        [JsonProperty]
        public readonly string node;
    }
}
