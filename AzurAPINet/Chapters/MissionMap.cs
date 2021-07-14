using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class MissionMap
    {
        public string Title;
        public string Code;
        public string Introduction;
        public UnlockRequirements UnlockRequirements;
        public ClearRewards ClearRewards;
        public Reward[] ThreeStarRewards;
        public EnemyLevel EnemyLevel;
        [JsonProperty("baseXP")]
        public BaseXP BaseXP;
        public int RequiredBattles;
        public int BossKillsToClear;
        public string[] StarConditions;
        public AirSupremacy AirSupremacy;
        public string[] MapDrops;
        public EquipmentBlueprintDrop[] EquipmentBlueprintDrops;
        [JsonConverter(typeof(ShipDropsConverter))]
        public List<ShipDrop> ShipDrops;
        public MissionNodeMap NodeMap;

        /// <summary>
        /// returns the .Title
        /// </summary>
        public override string ToString()
            => Title;
    }
}
