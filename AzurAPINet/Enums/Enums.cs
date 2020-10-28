using Jan0660.AzurAPINet.Barrage;
using Jan0660.AzurAPINet.Equipments;
using Jan0660.AzurAPINet.Events;
using Jan0660.AzurAPINet.Ships;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Jan0660.AzurAPINet.Enums
{
    public enum Rarity { Normal, Rare, Elite, SuperRare, UltraRare }
    public enum ShipRarity { Normal, Rare, Elite, SuperRare, Decisive, Priority, UltraRare }
    public enum NewSkinCurrency { Gem, Ruby }
    public enum BarrageType { Ship, Class, Skill }
    public enum ShipHullType { Destroyer, Monitor, LightCruiser, HeavyCruiser, AircraftCarrier, RepairShip, Battleship, Submarine, Battlecruiser, LargeCruiser, LightAircraftCarrier, SubmarineCarrier, MunitionShip };
    public enum EquipmentCategory
    {
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
    public enum ShipType
    {
        BB,
        CA,
        DD,
        CV,
        BC,
        CL,
        SS,
        CVL,
        SSV
    }
    public enum Nationality
    {
        Bilibili,
        RoyalNavy,
        SakuraEmpire,
        IronBlood,
        EagleUnion,
        VichyaDominion,
        DragonEmpery,
        KizunaAI,
        NorthernParliament,
        Neptunia,
        IrisLibre,
        SardegnaEmpire,
        Utawarerumono,
        Hololive,
        Universal,
        NorthUnion,
        EasternRadiance
    }
    public enum EquipmentTier
    {
        T0,
        T1,
        T2,
        T3
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
        public static ShipType GetTypeEnum(this NewShipConstruction ship)
        => StringToShipType(ship.Type);
        public static ShipType GetTypeEnum(this NewShipSkin skin)
        => StringToShipType(skin.Type);
        public static ShipType StringToShipType(string str)
        {
            return str switch
            {
                "BB" => ShipType.BB,
                "CA" => ShipType.CA,
                "DD" => ShipType.DD,
                "CV" => ShipType.CV,
                "BC" => ShipType.BC,
                "CL" => ShipType.CL,
                "SS" => ShipType.SS,
                "CVL" => ShipType.CVL,
                "SSV" => ShipType.SSV
            };
        }
        public static Rarity GetRarityEnum(this NewShipSkin ship)
            => StringToRarity(ship.Rarity);
        public static Rarity GetRarityEnum(this EquipmentStats equipment)
            => StringToRarity(equipment.Rarity);
        public static Rarity GetRarityEnum(this NewShipConstruction ship)
            => StringToRarity(ship.Rarity);
        public static Rarity StringToRarity(string str)
        {
            return str switch
            {
                "Normal" => Rarity.Normal,
                "Rare" => Rarity.Rare,
                "Elite" => Rarity.Elite,
                "Super Rare" => Rarity.SuperRare,
                "Ultra Rare" => Rarity.UltraRare
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
        public static EquipmentCategory GetCategoryEnum(this Equipment equipment)
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
        public static Nationality GetNationalityEnum(this Equipment equipment)
        => StringToNationality(equipment.Nationality);
        public static Nationality GetNationalityEnum(this Ship ship)
        => StringToNationality(ship.Nationality);

        public static Nationality StringToNationality(string str)
        {
            return str switch
            {
                "Bilibili" => Nationality.Bilibili,
                "Royal Navy" => Nationality.RoyalNavy,
                "Sakura Empire" => Nationality.SakuraEmpire,
                "Iron Blood" => Nationality.IronBlood,
                "Ironblood" => Nationality.IronBlood,
                "Eagle Union" => Nationality.EagleUnion,
                "Vichya Dominion" => Nationality.VichyaDominion,
                "Dragon Empery" => Nationality.DragonEmpery,
                "KizunaAI" => Nationality.KizunaAI,
                "Northern Parliament" => Nationality.NorthernParliament,
                "Neptunia" => Nationality.Neptunia,
                "Iris Libre" => Nationality.IrisLibre,
                "Sardegna Empire" => Nationality.SardegnaEmpire,
                "Utawarerumono" => Nationality.Utawarerumono,
                "Hololive" => Nationality.Hololive,
                "Universal" => Nationality.Universal,
                "North Union" => Nationality.NorthUnion,
                "Eastern Radiance" => Nationality.EasternRadiance
            };
        }
        public static EquipmentTier GetTierEnum(this EquipmentStats equipment)
        {
            return equipment.Tier switch
            {
                "T0" => EquipmentTier.T0,
                "T1" => EquipmentTier.T1,
                "T2" => EquipmentTier.T2,
                "T3" => EquipmentTier.T3
            };
        }
    }
}
