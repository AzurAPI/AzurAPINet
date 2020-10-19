using Jan0660.AzurAPINet.Events;
using Jan0660.AzurAPINet.Ships;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Enums
{
    public enum Rarity { Normal,Rare,Elite,SuperRare}
    public enum ShipRarity { Normal, Rare, Elite, SuperRare, Decisive, Priority, UltraRare }
    public enum NewSkinCurrency { Gem, Ruby }
    /// <summary>
    /// GetXXEnum extension methods
    /// </summary>
    public static class EnumExtensions
    {
        public static ShipRarity GetRarityEnum(this Ship ship)
        {
            return ship.Rarity switch
            {
                "Normal" => ShipRarity.Normal,
                "Rare" => ShipRarity.Rare,
                "Elite" => ShipRarity.Elite,
                "Super Rare" => ShipRarity.SuperRare,
                "Decisive" => ShipRarity.Decisive,
                "Priority" => ShipRarity.Priority,
                "Ultra Rare" => ShipRarity.UltraRare
            };
        }
        public static NewSkinCurrency GetCurrencyEnum(this NewShipSkin skin)
        {
            return skin.Currency switch
            {
                "Gem" => NewSkinCurrency.Gem,
                "Ruby" => NewSkinCurrency.Ruby
            };
        }
    }
}
