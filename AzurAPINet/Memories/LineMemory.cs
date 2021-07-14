using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Memories
{
    public class LineMemory
    {
        public Names Names;
        [JsonProperty("bannerSrc")]
        public string BannerSource;
        public string Background;
        public Names Content;

        public override string ToString()
            => Names.en;
    }
}
