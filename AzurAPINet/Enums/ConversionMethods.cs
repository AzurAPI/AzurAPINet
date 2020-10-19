using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Enums
{
    public static class ConversionMethods
    {
        // { Normal, Rare, Elite, SuperRare, Decisive, Priority, UltraRare }
        public static Rarity ToGeneralRarity(this ShipRarity rar)
        => rar switch
        {
            ShipRarity.Normal => Rarity.Normal,
            ShipRarity.Rare => Rarity.Rare,
            ShipRarity.Elite => Rarity.Elite,
            ShipRarity.SuperRare => Rarity.SuperRare,
            ShipRarity.Decisive => Rarity.SuperRare,
            ShipRarity.Priority => Rarity.SuperRare,
            ShipRarity.UltraRare => Rarity.SuperRare
        };
    }
}
