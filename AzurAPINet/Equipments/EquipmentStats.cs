using Jan0660.AzurAPINet.Converters;
using Jan0660.AzurAPINet.Ships;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Equipments
{
    /// <summary>
    /// equipment stats for a specific tier of an equipment
    /// </summary>
    public class EquipmentStats
    {
        public byte Tier;
        public string Rarity;
        public Stars Stars;
        [JsonProperty("stats", ItemConverterType = typeof(EquipmentStatConverter))]
        public Dictionary<string, EquipmentStat[]> Stats;
    }
}
