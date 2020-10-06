using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class UnlockRequirements
    {
        [JsonProperty("text")]
        public readonly string Text;
        [JsonProperty("requiredLevel")]
        public readonly int RequiredLevel;
    }
}
