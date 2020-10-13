using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
#nullable enable
#nullable disable warnings
    public class ShipAllStats
    {
        [JsonProperty("baseStats")]
        public readonly ShipStats BaseStats;
        [JsonProperty("level100")]
        public readonly ShipStats Level100;
        [JsonProperty("level120")]
        public readonly ShipStats Level120;
        [JsonProperty("level100Retrofit")]
        public readonly ShipStats? Level100Retrofit;
        [JsonProperty("level120Retrofit")]
        public readonly ShipStats? Level120Retrofit;
        /// <summary>
        /// Gets all the available ShipStats to a list
        /// </summary>
        /// <returns></returns>
        public List<ShipStats> ToList()
        {
            var list = new List<ShipStats>() { BaseStats, Level100, Level120 };
            if(Level100Retrofit != null)
            {
                list.Add(Level100Retrofit);
                list.Add(Level120Retrofit);
            }
            return list;
        }
    }
}
