using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class Mission
    {
        [JsonProperty("names")]
        public Names Names;
        [JsonProperty("normal")]
        public MissionMap Normal;
        [JsonProperty("hard")]
        public MissionMap Hard;
    }
}
