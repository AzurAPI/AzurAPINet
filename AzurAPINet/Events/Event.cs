using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINet.Events
{
    public class Event
    {
        /// <summary>
        /// The name of the event in english
        /// </summary>
        [JsonProperty("name")]
        public readonly string Name;
        [JsonProperty("new_ships_construction")]
        public readonly List<NewShipConstruction> NewShipsConstruction;
        [JsonProperty("new_ships_skins")]
        public readonly List<NewShipSkin> NewShipsSkins;
    }
}
