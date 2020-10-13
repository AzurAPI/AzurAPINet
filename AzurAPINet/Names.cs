using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet
{
#nullable enable
#nullable disable warnings
    /// <summary>
    /// Cotains the English/Japanese/Chinese/Korean names for an item
    /// </summary>
    public class Names
    {
        /// <summary>
        /// English
        /// </summary>
        [JsonProperty]
        public readonly string en;
        /// <summary>
        /// Chinese
        /// </summary>
        [JsonProperty]
        public readonly string cn;
        /// <summary>
        /// Japanese
        /// </summary>
        [JsonProperty]
        public readonly string jp;
        /// <summary>
        /// Korean, may be null in most cases
        /// </summary>
        [JsonProperty]
        public readonly string? kr;
    }
}
