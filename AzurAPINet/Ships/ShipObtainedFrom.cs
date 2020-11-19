using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Jan0660.AzurAPINet.Converters;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipObtainedFrom
    {
        [JsonProperty("obtainedFrom")]
        public readonly string ObtainedFrom;
        [JsonProperty("fromMaps", ItemConverterType = typeof(ShipObtainedFromMapConverter))]
        public readonly List<ShipObtainedFromMap> Maps;
    }
}
