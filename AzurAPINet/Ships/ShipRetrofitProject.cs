using Newtonsoft.Json;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipRetrofitProject
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("grade")]
        public string? Grade;
        [JsonProperty("attributes")]
        public string[] Attributes;
        [JsonProperty("materials")]
        public string[] Materials;
        [JsonProperty("coins")]
        public int Coins;
        [JsonProperty("level")]
        public int Level;
        [JsonProperty("levelBreakLevel")]
        public int LevelBreakLevel;
        [JsonProperty("levelBreakStars")]
        public string LevelBreakStars;
        [JsonProperty("recurrence")]
        public int Recurrence;
        [JsonProperty("require")]
        public string[] Require;
    }
}