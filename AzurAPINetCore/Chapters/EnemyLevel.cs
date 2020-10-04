using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class EnemyLevel
    {
        [JsonProperty("mobLevel")]
        public int MobLevel;
        [JsonProperty("bossLevel")]
        public int BossLevel;
        [JsonProperty("boss")]
        [JsonConverter(typeof(Jan0660.AzurAPINetCore.Converters.BossesConverter))]
        /// <summary>
        /// The list with all the Bosses
        /// yes even if there is only one boss you have to use this
        /// </summary>
        public List<string> Bosses;
    }
}
