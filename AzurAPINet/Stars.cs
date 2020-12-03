using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class Stars
    {
        /// <summary>
        /// why is this not named "Stars"?
        /// because Microsoft.
        /// </summary>
        [JsonProperty("stars")]
        public readonly string StarsString;
        [JsonProperty("value")]
        public readonly int Count;
        
        public override string ToString()
            => StarsString;
    }
}
