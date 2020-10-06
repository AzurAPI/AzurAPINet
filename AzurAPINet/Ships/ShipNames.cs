using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipNames
    {
        [JsonProperty]
        public readonly string en;
        /// <summary>
        /// example: "IJN Takao"
        /// </summary>
        [JsonProperty]
        public readonly string code;
        [JsonProperty]
        public readonly string cn;
        [JsonProperty]
        public readonly string jp;
        [JsonProperty]
        public readonly string kr;
    }
}
