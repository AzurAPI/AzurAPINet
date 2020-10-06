using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class EnemyLevel
    {
        [JsonProperty("mobLevel")]
        public readonly int MobLevel;
        [JsonProperty("bossLevel")]
        public readonly int BossLevel;
        [JsonProperty("boss")]
        [JsonConverter(typeof(Jan0660.AzurAPINet.Converters.BossesConverter))]
        /// <summary>
        /// The list with all the Bosses
        /// yes even if there is only one boss you have to use this
        /// </summary>
        public readonly List<string> Bosses;
    }
}
