﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Jan0660.AzurAPINet.Converters;

namespace Jan0660.AzurAPINet.Ships
{
    //pain
    public  class Ship
    {
        [JsonProperty("wikiUrl")]
        public readonly string WikiUrl;
        [JsonProperty("id")]
        public readonly string Id;
        [JsonProperty("names")]
        public readonly ShipNames Names;
        [JsonProperty("class")]
        public readonly string Class;
        [JsonProperty("nationality")]
        public readonly string Nationality;
        [JsonProperty("hullType")]
        public readonly string HullType;
        [JsonProperty("thumbnail")]
        public readonly string Thumbnail;
        [JsonProperty("rarity")]
        public readonly string Rarity;
        [JsonProperty("stars")]
        public readonly Stars Stars;
        // retrofit
        [JsonProperty("retrofit")]
        public bool Retrofittable = false;
        [JsonProperty("retrofitId")]
        public string? RetrofitId;
        [JsonProperty("retrofitProjects")]
        public ShipRetrofitProjectList? RetrofitProjects;
        [JsonProperty("retrofitHullType")]
        public string RetrofitHullType;

        [JsonProperty("stats")]
        public readonly ShipAllStats Stats;
        [JsonProperty("slots")]
        public readonly List<ShipEquipmentSlot> Slots;
        [JsonProperty("enhanceValue")]
        [JsonConverter(typeof(EnhanceValueConverter))]
        public readonly ShipEnhanceValue EnhanceValue;
        [JsonProperty("scrapValue")]
        [JsonConverter(typeof(ScrapValueConverter))]
        public readonly ShipScrapValue ScrapValue;
        [JsonProperty("skills")]
        public readonly List<ShipSkill> Skills;
        [JsonProperty("limitBreaks")]
        public readonly List<List<string>> LimitBreaks;
        [JsonProperty("fleetTech")]
        public readonly ShipFleetTech FleetTech;
        [JsonProperty("construction")]
        [JsonConverter(typeof(ConstructionInfoConverter))]
        public readonly ShipConstructionInfo Construction;
        [JsonProperty("obtainedFrom")]
        public readonly ShipObtainedFrom ObtainedFrom;
        [JsonProperty("skins")]
        public readonly List<ShipSkin> Skins;
        [JsonProperty("misc")]
        public readonly ShipMisc Misc;
        [JsonProperty("gallery")]
        public readonly List<ShipGalleryItem> Gallery;

        /// <summary>
        /// returns the english name of the ship
        /// </summary>
        public override string ToString()
            => Names.en;
    }
}
