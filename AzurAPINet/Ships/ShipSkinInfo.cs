using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipSkinInfo
    {
        [JsonProperty("obtainedFrom")]
        public readonly string ObtainedFrom;
        [JsonProperty("live2dModel")]
        public readonly bool Live2DModel;
    }
}
