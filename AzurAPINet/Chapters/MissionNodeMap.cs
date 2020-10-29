using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class MissionNodeMap
    {
        [JsonProperty("preview")]
        public readonly string Preview;
        [JsonProperty("width")]
        public readonly int Width;
        [JsonProperty("height")]
        public readonly int Height;
        [JsonProperty("map")]
        public readonly string[,] Map;
        [JsonProperty("nodes")]
        public readonly MissionMapNode[] Nodes;
    }
}
