using Jan0660.AzurAPINet.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
#nullable enable
#nullable disable warnings
    public class ShipSkinInfo
    {
        /// <summary>
        /// english skin name, present in non-default skins
        /// </summary>
        [JsonProperty]
        public readonly string? enClient;
        /// <summary>
        /// japanese english skin name, present in non-default skins
        /// </summary>
        [JsonProperty]
        public readonly string? jpClient;
        /// <summary>
        /// chinese skin name, present in non-default skins
        /// </summary>
        [JsonProperty]
        public readonly string? cnClient;
        [JsonProperty("obtainedFrom")]
        public readonly string ObtainedFrom;
        [JsonProperty("cost")]
        public readonly int? Cost;
        [JsonProperty("live2dModel")]
        public readonly bool Live2DModel;
    }
}
