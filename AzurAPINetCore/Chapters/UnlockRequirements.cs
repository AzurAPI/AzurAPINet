using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class UnlockRequirements
    {
        [JsonProperty("text")]
        public string Text;
        [JsonProperty("requiredLevel")]
        public int RequiredLevel;
    }
}
