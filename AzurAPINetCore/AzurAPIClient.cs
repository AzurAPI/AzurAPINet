using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Jan0660.AzurAPINetCore
{
    public class AzurAPIClient
    {
        /// <summary>
        /// enable by setting to true
        /// caching, this will cache all ships/other things in the future, this will cause more memory(around 20mb) used but a lot faster access speeds
        /// </summary>
        public bool EnableCaching = false;
        public readonly string WorkingDirectory;
        public List<Ship> Ships { get; private set; } = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workingDirectory">AzurAPI database location</param>
        public AzurAPIClient(string workingDirectory)
        {
            WorkingDirectory = workingDirectory;
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
                if (EnableCaching)
                    this.Ships = ships;
            }
            else
                ships = this.Ships;
            return ships;
        }
        public async Task<Ship> GetShipByEnglishName(string name)
        {
            if (!EnableCaching)
            {
                try
                {
                    // parse the content
                    var content = await File.ReadAllTextAsync(WorkingDirectory + "./ships.json");
                    var json = JArray.Parse(content);

                    // error when we can't find results
                    if (json.Count == 0) throw new Exception("Unknown error occured while serialising ship list");

                    // map all children to JObject; and then their names from the JSON
                    var children = json
                        .Children<JObject>()
                        .Select(child => child.ToObject<JObject>())
                        .Select(child => child.SelectTokens("names").First());
                    var ass = children.Where(uwu =>
                    {
                        var val = uwu.Value<string>("en");
                        return val.ToLower() == name.ToLower();
                    }
                        );
                    if (ass.FirstOrDefault() == null)
                        return null;
                    return ass.FirstOrDefault().Parent.Parent.ToObject<Ship>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occured while fetching data: {ex.Message}");
                    return null;
                }
            }
            else
            {
                var ships = GetAllShips();
                return ships.Where((ship)=>ship.Names.en.ToLower() == name.ToLower()).FirstOrDefault();
            }
        }
    }
}
