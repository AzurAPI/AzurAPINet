using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Memories
{
    public class ChapterMemory
    {
        [JsonProperty("names")]
        public readonly Names Names;
        [JsonProperty("thumbnail")]
        public readonly string Thumbnail;
        [JsonProperty("wikiUrl")]
        public readonly string WikiUrl;
        [JsonProperty("chapters")]
        public readonly MissionMemory[] Missions;

        public override string ToString()
            => Names.en;
    }
}
