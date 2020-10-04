using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class AirSupremacy
    {
        [JsonProperty("actual")]
        public int Actual;
        [JsonProperty("airSuperiority")]
        public int AirSuperiority;
        /// <summary>
        /// Not a typo: C# is retarded
        /// </summary>
        [JsonProperty("airSupremacy")]
        public int AirSupremacyy;
    }
}
