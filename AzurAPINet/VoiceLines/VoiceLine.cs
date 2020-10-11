using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.VoiceLines
{
    public class VoiceLine
    {
        [JsonProperty("event")]
        public readonly string Event;
        /// <summary>
        /// Chinese subtitle
        /// </summary>
        [JsonProperty]
        public readonly string zh;
        /// <summary>
        /// Audio file's url
        /// </summary>
        [JsonProperty("audio")]
        public readonly string Audio;
        /// <summary>
        /// Japanese subtitle
        /// </summary>
        [JsonProperty]
        public readonly string ja;
        /// <summary>
        /// English subtitle
        /// </summary>
        [JsonProperty]
        public readonly string en;
    }
}
