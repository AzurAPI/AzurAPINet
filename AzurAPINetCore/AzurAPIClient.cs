﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Jan0660.AzurAPINetCore.Ships;
namespace Jan0660.AzurAPINetCore
{
    public class AzurAPIClient
    {
        public readonly AzurAPIClientOptions Options;
        public readonly string WorkingDirectory;
        public List<Ship> Ships { get; private set; } = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workingDirectory">AzurAPI database location</param>
        public AzurAPIClient(string workingDirectory, AzurAPIClientOptions options)
        {
            WorkingDirectory = workingDirectory;
            Options = options;
        }

        public List<Ship> GetAllShips()
        {
            List<Ship> ships;
            if (this.Ships == null)
            {
                ships = JsonConvert.DeserializeObject<List<Ship>>(File.ReadAllText(WorkingDirectory + "ships.json"),
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }
);
                if (Options.EnableCaching)
                    this.Ships = ships;
            }
            else
                ships = this.Ships;
            return ships;
        }
        #region GetShip, GetShipBy<EnglishName,Code,Id,...>
        /// <summary>
        /// Searches for a ship using it's english name, code, id, japanese and chinese name, in this orde
        /// </summary>
        /// <param name="query"></param>
        /// <returns>the goddamn ship</returns>
        public Ship GetShip(string query)
        {
            var ship = GetShipByEnglishName(query);
            if (ship != null)
                return ship;
            ship = GetShipByCode(query);
            if (ship != null)
                return ship;
            ship = GetShipById(query);
            if (ship != null)
                return ship;
            ship = GetShipByJapaneseName(query);
            if (ship != null)
                return ship;
            ship = GetShipByChineseName(query);
            if (ship != null)
                return ship;
            return null;
        }
        public Ship GetShipByEnglishName(string name)
        {
            var ships = GetAllShips();
            return ships.Where((ship) => ship.Names.en.ToLower() == name.ToLower()).FirstOrDefault();
        }
        public Ship GetShipByCode(string code)
        {
            var ships = GetAllShips();
            return ships.Where((ship) => ship.Names.code.ToLower() == code.ToLower()).FirstOrDefault();
        }
        public Ship GetShipById(string id)
        {
            var ships = GetAllShips();
            return ships.Where((ship) => ship.Id.ToLower() == id.ToLower()).FirstOrDefault();
        }
        public Ship GetShipByJapaneseName(string name)
        {
            var ships = GetAllShips();
            return ships.Where((ship) => ship.Names.jp.ToLower() == name.ToLower()).FirstOrDefault();
        }
        public Ship GetShipByChineseName(string name)
        {
            var ships = GetAllShips();
            return ships.Where((ship) => ship.Names.cn.ToLower() == name.ToLower()).FirstOrDefault();
        }
        #endregion
    }
}
