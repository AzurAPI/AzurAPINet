using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class ShipDrop
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("note")]
        public string Note;
    }
}
