using Jan0660.AzurAPINet.Barrage;
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
    public enum BarrageType { Ship, Class, Skill}
    public enum ShipHullType { Destroyer, Monitor, LightCruiser, HeavyCruiser, AircraftCarrier, RepairShip, Battleship, Submarine, Battlecruiser, LargeCruiser, LightAircraftCarrier, SubmarineCarrier, MunitionShip };
    public enum EquipmentCategory {
        DestroyerGuns,
        LightCruiserGuns,
        HeavyCruiserGuns,
        BattleshipGuns,
        ShipTorpedoes,
        SubmarineTorpedoes,
        FighterPlanes,
        DiveBomberPlanes,
        TorpedoBomberPlanes,
        Seaplanes,
        AntiAirGuns,
        AuxiliaryEquipment,
        AntiSubmarineEquipment
    }
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
        public static BarrageType GetBarrageTypeEnum(this BarrageItem barrage)
        {
            return barrage.Type switch
            {
                "ship" => BarrageType.Ship,
                "class" => BarrageType.Class,
                "skill" => BarrageType.Skill
            };
        }
        public static ShipHullType GetHullTypeEnum(this Ship ship)
        {
            return ship.HullType switch
            {
                "Destroyer" => ShipHullType.Destroyer,
                "Monitor" => ShipHullType.Monitor,
                "Light Cruiser" => ShipHullType.LightCruiser,
                "Heavy Cruiser" => ShipHullType.HeavyCruiser,
                "Aircraft Carrier" => ShipHullType.AircraftCarrier,
                "Repair Ship" => ShipHullType.RepairShip,
                "Battleship" => ShipHullType.Battleship,
                "Submarine" => ShipHullType.Submarine,
                "Battlecruiser" => ShipHullType.Battlecruiser,
                "Large Cruiser" => ShipHullType.LargeCruiser,
                "Light Aircraft Carrier" => ShipHullType.LightAircraftCarrier,
                "Submarine Carrier" => ShipHullType.SubmarineCarrier,
                "Munition Ship" => ShipHullType.MunitionShip
            };
        }
        public static EquipmentCategory GetCategoryEnum(this Jan0660.AzurAPINet.Equipments.Equipment equipment)
        {
            return equipment.Category switch
            {
                "Destroyer Guns" => EquipmentCategory.DestroyerGuns,
                "Light Cruiser Guns" => EquipmentCategory.LightCruiserGuns,
                "Heavy Cruiser Guns" => EquipmentCategory.HeavyCruiserGuns,
                "Battleship Guns" => EquipmentCategory.BattleshipGuns,
                "Ship Torpedoes" => EquipmentCategory.ShipTorpedoes,
                "Submarine Torpedoes" => EquipmentCategory.SubmarineTorpedoes,
                "Fighter Planes" => EquipmentCategory.FighterPlanes,
                "Dive Bomber Planes" => EquipmentCategory.DiveBomberPlanes,
                "Torpedo Bomber Planes" => EquipmentCategory.TorpedoBomberPlanes,
                "Seaplanes" => EquipmentCategory.Seaplanes,
                "Anti-Air Guns" => EquipmentCategory.AntiAirGuns,
                "Auxiliary Equipment" => EquipmentCategory.AuxiliaryEquipment,
                "Anti-Submarine Equipment" => EquipmentCategory.AntiSubmarineEquipment
            };
        }
    }
}
