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
        public override ShipConstructionInfo ReadJson(JsonReader reader, Type objectType,
            ShipConstructionInfo existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var info = serializer.Deserialize<ConstructionInfo>(reader);
            TimeSpan timeSpan;
            bool constructable =
                TimeSpan.TryParseExact(info.constructionTime, @"hh\:mm\:ss", null, out timeSpan);
            return new ShipConstructionInfo
            {
                Constructable = constructable,
                ConstructionTime = timeSpan,
                AvailableIn = info.availableIn
            };
        }

        public override void WriteJson(JsonWriter writer, ShipConstructionInfo value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        private struct ConstructionInfo
        {
            public string constructionTime;
            public ShipConstructionAvailableIn availableIn;
        }
    }
}