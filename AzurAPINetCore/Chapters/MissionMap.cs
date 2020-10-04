using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class MissionMap
    {
        [JsonProperty("title")]
        public string Title;
        [JsonProperty("code")]
        public string Code;
        [JsonProperty("introduction")]
        public string Introduction;
        [JsonProperty("unlockRequirements")]
        public UnlockRequirements UnlockRequirements;
        [JsonProperty("clearRewards")]
        public ClearRewards ClearRewards;
        [JsonProperty("threeStarRewards")]
        public List<Reward> ThreeStarRewards;
        [JsonProperty("enemyLevel")]
        public EnemyLevel EnemyLevel;
        [JsonProperty("baseXP")]
        public BaseXP BaseXP;
        [JsonProperty("requiredBattles")]
        public int RequiredBattles;
        [JsonProperty("bossKillsToClear")]
        public int BossKillsToClear;
        [JsonProperty("starConditions")]
        public List<string> StarConditions;
        [JsonProperty("airSupremacy")]
        public AirSupremacy AirSupremacy;
        [JsonProperty("mapDrops")]
        public List<string> MapDrops;
        [JsonProperty("equipmentBlueprintDrops")]
        public List<EquipmentBlueprintDrop> EquipmentBlueprintDrops;
        [JsonProperty("shipDrops")]
        [JsonConverter(typeof(ShipDropsConverter))]
        public List<ShipDrop> ShipDrops;
    }
}
