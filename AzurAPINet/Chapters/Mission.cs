using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class Mission
    {
        [JsonProperty("names")]
        public readonly Names Names;
        [JsonProperty("normal")]
        public readonly MissionMap Normal;
        [JsonProperty("hard")]
        public readonly MissionMap Hard;
    }
}
