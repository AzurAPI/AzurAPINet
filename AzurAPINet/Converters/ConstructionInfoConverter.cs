using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Newtonsoft.Json.Linq;
using Jan0660.AzurAPINet.Ships;
namespace Jan0660.AzurAPINet.Converters
{
    internal class ConstructionInfoConverter : JsonConverter<ShipConstructionInfo>
    {
        public override ShipConstructionInfo ReadJson(JsonReader reader, Type objectType, [AllowNull] ShipConstructionInfo existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            dynamic dyn = jObject;
            TimeSpan timeSpan;
            bool constructable = TimeSpan.TryParseExact((string)dyn.constructionTime, @"hh\:mm\:ss", null, out timeSpan);
            string json = dyn.availableIn.ToString();
            return new ShipConstructionInfo
            {
                Constructable=constructable,
                ConstructionTime = timeSpan,
                AvailableIn = JsonConvert.DeserializeObject<ShipConstructionAvailableIn>(json)
            };
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] ShipConstructionInfo value, JsonSerializer serializer)
        {
            throw new Exception("no");
        }
    }
}
