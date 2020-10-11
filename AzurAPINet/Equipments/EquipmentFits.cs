using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Equipments
{
    public class EquipmentFits
    {
        [JsonProperty("destroyer")]
        public readonly string Destroyer;
        [JsonProperty("lightCruiser")]
        public readonly string LightCruiser;
        [JsonProperty("heavyCruiser")]
        public readonly string HeavyCruiser;
        [JsonProperty("monitor")]
        public readonly string Monitor;
        [JsonProperty("largeCruiser")]
        public readonly string LargeCruiser;
        [JsonProperty("battleship")]
        public readonly string Battleship;
        [JsonProperty("battlecruiser")]
        public readonly string BattleCruiser;
        [JsonProperty("aviationBattleship")]
        public readonly string AviationBattleship;
        [JsonProperty("aircraftCarrier")]
        public readonly string AircraftCarrier;
        [JsonProperty("lightCarrier")]
        public readonly string LightCarrier;
        [JsonProperty("repairShip")]
        public readonly string RepairShip;
        [JsonProperty("submarine")]
        public readonly string Submarine;
        [JsonProperty("submarineCarrier")]
        public readonly string SubmarineCarrier;
    }
}
