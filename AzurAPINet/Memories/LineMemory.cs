using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Memories
{
    public class LineMemory
    {
        [JsonProperty("names")]
        public readonly Names Names;
        [JsonProperty("bannerSrc")]
        public readonly string BannerSource;
        [JsonProperty("background")]
        public readonly string Background;
        [JsonProperty("content")]
        public readonly Names Content;
    }
}
