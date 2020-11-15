using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipMisc
    {
        [JsonProperty("artist")]
        public ShipMiscItem Artist;
        [JsonProperty("web")]
        public ShipMiscItem Web;
        [JsonProperty("pixiv")]
        public ShipMiscItem Pixiv;
        [JsonProperty("twitter")]
        public ShipMiscItem Twitter;
        [JsonProperty("voice")]
        public ShipMiscItem Voice;
    }
}
