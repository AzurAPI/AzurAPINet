using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class Chapter
    {
        [JsonProperty("1")]
        public readonly Mission Mission1;
        [JsonProperty("2")]
        public readonly Mission Mission2;
        [JsonProperty("3")]
        public readonly Mission Mission3;
        [JsonProperty("4")]
        public readonly Mission Mission4;
        /// <summary>
        /// all the missions in a list
        /// </summary>
        [JsonIgnore]
        public Mission[] Missions => new[]{ Mission1, Mission2, Mission3, Mission4 };

        [JsonProperty("names")]
        public readonly Names Names;

        /// <summary>
        /// returns the english name of the chapter
        /// </summary>
        public override string ToString()
            => Names.en;
    }
}
