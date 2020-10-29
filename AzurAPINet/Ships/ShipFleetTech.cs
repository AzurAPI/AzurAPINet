using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
    public class ShipFleetTech
    {
        [JsonProperty("statsBonus")]
        public readonly ShipTechStats StatsBonus;
        [JsonProperty("techPoints")]
        public readonly ShipTechPoints TechPoints;
    }
}
