using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipStats
    {
        [JsonProperty("health")]
        public readonly int Health;
        [JsonProperty("armor")]
        public readonly string Armor;
        [JsonProperty("reload")]
        public readonly int Reload;
        [JsonProperty("luck")]
        public readonly int Luck;
        [JsonProperty("firepower")]
        public readonly int Firepower;
        [JsonProperty("torpedo")]
        public readonly int Torpedo;
        [JsonProperty("evasion")]
        public readonly int Evasion;
        [JsonProperty("antiair")]
        public readonly int AntiAir;
        [JsonProperty("speed")]
        public readonly int Speed;
        [JsonProperty("aviation")]
        public readonly int Aviation;
        [JsonProperty("oilConsumption")]
        public readonly int OilConsumption;
        [JsonProperty("accuracy")]
        public readonly int Accuracy;
        [JsonProperty("antisubmarineWarfare")]
        public readonly int AntiSubmarineWarfare;
        /// <summary>
        /// submarine-only
        /// </summary>
        [JsonProperty("oxygen")]
        public readonly int? Oxygen;
        /// <summary>
        /// submarine-only
        /// </summary>
        [JsonProperty("ammunition")]
        public readonly int? Ammunition;
        /// <summary>
        /// submarine-only
        /// </summary>
        [JsonProperty("huntingRange")]
        public readonly List<List<string>>? HuntingRange;
        [JsonConstructor]
        protected internal ShipStats() { }
        /// <summary>
        /// Estimates ship stats for a level.
        /// NOTE THAT THIS DOESNT TAKE INTO ACCOUNT LIMIT BREAKS AND IS PROBABLY WAY OFF
        /// </summary>
        public ShipStats(ShipStats lvl0, ShipStats max, int level)
        {
            // PAIN INCOMING
            this.Health = pain(lvl0.Health, max.Health, level);
            this.Armor = lvl0.Armor;
            this.Reload = pain(lvl0.Reload, max.Reload, level);
            this.Luck = pain(lvl0.Luck, max.Luck, level);
            this.Firepower = pain(lvl0.Firepower, max.Firepower, level);
            this.Torpedo = pain(lvl0.Torpedo, max.Torpedo, level);
            this.Evasion = pain(lvl0.Evasion, max.Evasion, level);
            this.AntiAir = pain(lvl0.AntiAir, max.AntiAir, level);
            this.Speed = pain(lvl0.Speed, max.Speed, level);
            this.Aviation = pain(lvl0.Aviation, max.Aviation, level);
            this.OilConsumption = pain(lvl0.OilConsumption, max.OilConsumption, level);
            this.Accuracy = pain(lvl0.Accuracy, max.Accuracy, level);
            this.AntiSubmarineWarfare = pain(lvl0.AntiSubmarineWarfare, max.AntiSubmarineWarfare, level);
            try
            {
                this.Oxygen = pain((int)lvl0.Oxygen, (int)max.Oxygen, level);
                this.Ammunition = pain((int)lvl0.Ammunition, (int)max.Ammunition, level);
                this.HuntingRange = lvl0.HuntingRange;
            }
            catch { }
        }
        private int pain(int bas, int max, int lvl)
        {
            var res = (max - bas) * (lvl / 100d);
            res += bas;
            return (int)res;
        }
    }
}
