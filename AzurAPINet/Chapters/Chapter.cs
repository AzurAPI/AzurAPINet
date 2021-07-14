using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class Chapter
    {
        [JsonProperty("1")]
        public Mission Mission1;
        [JsonProperty("2")]
        public Mission Mission2;
        [JsonProperty("3")]
        public Mission Mission3;
        [JsonProperty("4")]
        public Mission Mission4;
        /// <summary>
        /// All the missions in an array.
        /// </summary>
        [JsonIgnore]
        public Mission[] Missions => new[]{ Mission1, Mission2, Mission3, Mission4 };

        public Names Names;

        public string Id;

        /// <summary>
        /// returns the english name of the chapter
        /// </summary>
        public override string ToString()
            => Names.en;
    }
}
