using Newtonsoft.Json;
using System;

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
        public readonly int AntiSubmarineWarfare = 0;
    }
}
