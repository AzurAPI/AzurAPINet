using System;
using System.Collections.Generic;
using System.Linq;
using Jan0660.AzurAPINet.Enums;
using Jan0660.AzurAPINet.Ships;

namespace Jan0660.AzurAPINet.Client
{
    public class AzurAPIClientShip
    {
        private AzurAPIClient _client;
        public AzurAPIClientShipFilter filter;
        public AzurAPIClientShipAll all;

        internal AzurAPIClientShip(AzurAPIClient client)
        {
            _client = client;
            all = new AzurAPIClientShipAll(this._client);
            filter = new AzurAPIClientShipFilter(this._client);
        }

        /// <summary>
        /// gets a ship by its en, jp, cn, kr, official name or id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Ship get(string name) => _client.getShip(name);

        /// <summary>
        /// gets a ship by its english, japanese, korean or chinese name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Ship name(string name)
            => _client.getShipByEnglishName(name)
               ?? _client.getShipByChineseName(name)
               ?? _client.getShipByJapaneseName(name)
               ?? _client.getShipByKoreanName(name);

        /// <summary>
        /// gets a ship by its english, japanese or chinese name only
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language">one of "english", "japanese" ,"korean", "chinese"</param>
        /// <returns></returns>
        public Ship name(string name, string language)
            => language.ToLower() switch
            {
                "english" => _client.getShipByEnglishName(name),
                "japanese" => _client.getShipByJapaneseName(name),
                "chinese" => _client.getShipByChineseName(name),
                "korean" => _client.getShipByKoreanName(name),
                _ => throw new Exception("Invalid language.")
            };

        /// <summary>
        /// gets a ship by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Ship id(string id) => _client.getShipById(id);
    }

    public class AzurAPIClientShipAll
    {
        private AzurAPIClient _client;

        public Ship[] get => _client.getAllShips();

        internal AzurAPIClientShipAll(AzurAPIClient client)
        {
            this._client = client;
        }

        public IEnumerable<Ship> id()
            => _client.getAllShips().Where(ship => ship.Id != null);

        /// <summary>
        /// gets ships where their name for the specified language is not null
        /// </summary>
        /// <param name="language">one of "english", "japanese" ,"korean", "chinese"</param>
        /// <returns></returns>
        public IEnumerable<Ship> Name(string language)
            => language.ToLower() switch
            {
                "english" => _client.getAllShips().Where(ship => ship.Names.en != null),
                "japanese" => _client.getAllShips().Where(ship => ship.Names.jp != null),
                "chinese" => _client.getAllShips().Where(ship => ship.Names.cn != null),
                "korean" => _client.getAllShips().Where(ship => ship.Names.kr != null),
                _ => throw new Exception("Invalid language")
            };
    }

    public class AzurAPIClientShipFilter
    {
        private AzurAPIClient _client;

        internal AzurAPIClientShipFilter(AzurAPIClient client)
        {
            this._client = client;
        }

        public IEnumerable<Ship> Nationality(string nationality)
            => _client.getAllShipsFromNation(nationality);

        public IEnumerable<Ship> Nationality(Nationality nationality)
            => _client.getAllShipsFromNation(nationality);

        public IEnumerable<Ship> Faction(string faction)
            => _client.getAllShipsFromNation(faction);

        public IEnumerable<Ship> Faction(Nationality faction)
            => _client.getAllShipsFromNation(faction);

        public IEnumerable<Ship> Rarity(string rarity)
            => _client.getShipsByRarity(rarity);

        public IEnumerable<Ship> Rarity(ShipRarity rarity)
            => _client.getShipsByRarity(rarity);

        public IEnumerable<Ship> Stars(int starCount)
            => _client.getAllShips().Where(ship => ship.Stars.Count == starCount);

        public IEnumerable<Ship> Type(string type)
            => _client.getAllShips().Where(ship => ship.HullType == type);

        public IEnumerable<Ship> Type(ShipHullType hullType)
            => _client.getAllShips().Where(ship =>
                ship.GetHullTypeEnum() == hullType | ship.GetRetrofitHullTypeEnum() == hullType);

        public IEnumerable<Ship> Class(string className)
            => _client.getShipsByClass(className);
    }
}