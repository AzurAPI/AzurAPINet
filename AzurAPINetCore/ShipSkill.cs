using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINetCore
{
    public class ShipSkill
    {
        [JsonProperty("icon")]
        public string Icon;
        [JsonProperty("names")]
        public SkillNames Names;
        [JsonProperty("description")]
        public string Description;
        [JsonProperty("color")]
        public string Color;
    }
}
