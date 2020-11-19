using Newtonsoft.Json;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipObtainedFromMap
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("note")]
        public string? Note;
        protected  internal ShipObtainedFromMap() {}
    }
}