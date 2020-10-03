using Newtonsoft.Json;
using System;
namespace Jan0660.AzurAPINetCore.Ships
{
    public class ShipStats
    {
        [JsonProperty("health")]
        public int Health;
        [JsonProperty("armor")]
        public string Armor;
        [JsonProperty("reload")]
        public int Reload;
        [JsonProperty("luck")]
        public int Luck;
        [JsonProperty("firepower")]
        public int Firepower;
        [JsonProperty("torpedo")]
        public int Torpedo;
        [JsonProperty("evasion")]
        public int Evasion;
        [JsonProperty("antiair")]
        public int AntiAir;
        [JsonProperty("speed")]
        public int Speed;
        [JsonProperty("aviation")]
        public int Aviation;
        [JsonProperty("oilConsumption")]
        public int OilConsumption;
        [JsonProperty("accuracy")]
        public int Accuracy;
        [JsonProperty("antisubmarineWarfare")]
        public int AntiSubmarineWarfare = 0;
    }
}
