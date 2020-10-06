using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class ShipDrop
    {
        [JsonProperty("name")]
        public readonly string Name;
        [JsonProperty("note")]
        public readonly string Note;
        public ShipDrop() { }
        public ShipDrop(string Name) { this.Name = Name; }
    }
}
