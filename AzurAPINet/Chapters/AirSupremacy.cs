using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class AirSupremacy
    {
        [JsonProperty("actual")]
        public readonly int Actual;
        [JsonProperty("airSuperiority")]
        public readonly int AirSuperiority;
        /// <summary>
        /// Not a typo: C# is retarded
        /// </summary>
        [JsonProperty("airSupremacy")]
        public readonly int AirSupremacyy;
    }
}
