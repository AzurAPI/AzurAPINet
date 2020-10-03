using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore
{
    public class ShipSkinInfo
    {
        [JsonProperty("obtainedFrom")]
        public string ObtainedFrom;
        [JsonProperty("live2dModel")]
        public bool Live2DModel;
    }
}
