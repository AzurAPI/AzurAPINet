using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class MissionMap
    {
        [JsonProperty("title")]
        public readonly string Title;
        [JsonProperty("code")]
        public readonly string Code;
        [JsonProperty("introduction")]
        public readonly string Introduction;
        [JsonProperty("unlockRequirements")]
        public readonly UnlockRequirements UnlockRequirements;
        [JsonProperty("clearRewards")]
        public readonly ClearRewards ClearRewards;
        [JsonProperty("threeStarRewards")]
        public readonly Reward[] ThreeStarRewards;
        [JsonProperty("enemyLevel")]
        public readonly EnemyLevel EnemyLevel;
        [JsonProperty("baseXP")]
        public readonly BaseXP BaseXP;
        [JsonProperty("requiredBattles")]
        public readonly int RequiredBattles;
        [JsonProperty("bossKillsToClear")]
        public readonly int BossKillsToClear;
        [JsonProperty("starConditions")]
        public readonly string[] StarConditions;
        [JsonProperty("airSupremacy")]
        public readonly AirSupremacy AirSupremacy;
        [JsonProperty("mapDrops")]
        public readonly string[] MapDrops;
        [JsonProperty("equipmentBlueprintDrops")]
        public readonly EquipmentBlueprintDrop[] EquipmentBlueprintDrops;
        [JsonProperty("shipDrops")]
        [JsonConverter(typeof(ShipDropsConverter))]
        public readonly List<ShipDrop> ShipDrops;
        [JsonProperty("nodeMap")]
        public readonly MissionNodeMap NodeMap;

        /// <summary>
        /// returns the .Title
        /// </summary>
        public override string ToString()
            => Title;
    }
}
