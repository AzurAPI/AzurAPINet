using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Memories
{
    public class ChapterMemory
    {
        public Names Names;
        public string Thumbnail;
        public string WikiUrl;
        [JsonProperty("chapters")]
        public MissionMemory[] Missions;

        public override string ToString()
            => Names.en;
    }
}
