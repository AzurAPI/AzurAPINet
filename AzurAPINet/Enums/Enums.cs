﻿using Jan0660.AzurAPINet.Barrage;
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
    public enum HullType
    {
        BB,
        CA,
        DD,
        CV,
        CB,
        BC,
        BM,
        CL,
        SS,
        CVL,
        SSV,
        BBV
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
    public enum BarrageRoundType
    {
        Normal,
        HE,
        AP,
        Torpedo,
        SAP,
        /// <summary>
        /// Torpedo (CV)
        /// </summary>
        TorpedoCV,
        /// <summary>
        /// Bomb (CV)
        /// </summary>
        BombCV,
        ASW,
        Sanshikidan,
        /// <summary>
        /// Laser?
        /// </summary>
        Laser
    }
    public enum RetrofitGrade
    {
        /// <summary>
        /// null
        /// </summary>
        None,
        I,
        II,
        III
    }
    /// <summary>
    /// GetXXEnum extension methods
    /// </summary>
    public static class EnumExtensions
    {
        #region Ship
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
        public static Nationality GetNationalityEnum(this Ship ship)
        => StringToNationality(ship.Nationality);
        #endregion
        #region NewShipSkin
        public static NewSkinCurrency GetCurrencyEnum(this NewShipSkin skin)
        {
            return skin.Currency switch
            {
                "Gem" => NewSkinCurrency.Gem,
                "Ruby" => NewSkinCurrency.Ruby
            };
        }
        public static HullType GetTypeEnum(this NewShipSkin skin)
        => StringToHullType(skin.Type);
        public static Rarity GetRarityEnum(this NewShipSkin ship)
            => StringToRarity(ship.Rarity);
        #endregion
        #region Equipment
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
        #endregion
        #region EquipmentStats
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
        public static Rarity GetRarityEnum(this EquipmentStats equipment)
            => StringToRarity(equipment.Rarity);
        #endregion
        #region NewShipConstruction
        public static HullType GetTypeEnum(this NewShipConstruction ship)
        => StringToHullType(ship.Type);
        public static Rarity GetRarityEnum(this NewShipConstruction ship)
            => StringToRarity(ship.Rarity);
        #endregion
        #region BarrageItem
        public static BarrageType GetTypeEnum(this BarrageItem barrage)
        {
            return barrage.Type switch
            {
                "ship" => BarrageType.Ship,
                "class" => BarrageType.Class,
                "skill" => BarrageType.Skill
            };
        }
        public static HullType GetHullTypeEnum(this BarrageItem barrage)
            => StringToHullType(barrage.Hull);
        #endregion
        #region BarrageRound
        public static BarrageRoundType GetTypeEnum(this BarrageRound round)
        {
            return round.Type switch
            {
                "Normal" => BarrageRoundType.Normal,
                "HE" => BarrageRoundType.HE,
                "AP" => BarrageRoundType.AP,
                "Torpedo" => BarrageRoundType.Torpedo,
                "SAP" => BarrageRoundType.SAP,
                "Torpedo (CV)" => BarrageRoundType.TorpedoCV,
                "Bomb (CV)" => BarrageRoundType.BombCV,
                "ASW" => BarrageRoundType.ASW,
                "Sanshikidan" => BarrageRoundType.Sanshikidan,
                "Laser?" => BarrageRoundType.Laser
            };
        }
        #endregion
        #region ShipRetrofitProject
        public static RetrofitGrade GetGradeEnum(this ShipRetrofitProject proj)
        {
            return proj.Grade switch
            {
                null => RetrofitGrade.None,
                "I" => RetrofitGrade.I,
                "II" => RetrofitGrade.II,
                "III" => RetrofitGrade.III
            };
        }
        #endregion
        public static HullType StringToHullType(string str)
        {
            return str switch
            {
                "BB" => HullType.BB,
                "CA" => HullType.CA,
                "DD" => HullType.DD,
                "CV" => HullType.CV,
                "CB" => HullType.CB,
                "BC" => HullType.BC,
                "BM" => HullType.BM,
                "CL" => HullType.CL,
                "SS" => HullType.SS,
                "CVL" => HullType.CVL,
                "SSV" => HullType.SSV,
                "BBV" => HullType.BBV
            };
        }
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
    }
}
