using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet
{
    /// <summary>
    /// Cotains the English/Japanese/Chinese names for an item
    /// </summary>
    public class Names
    {
        [JsonProperty]
        public readonly string en;
        [JsonProperty]
        public readonly string cn;
        [JsonProperty]
        public readonly string jp;
    }
}
