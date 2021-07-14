using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Jan0660.AzurAPINet.Ships;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINet.Converters
{
    internal class ShipObtainedFromMapConverter : JsonConverter<ShipObtainedFromMap>
    {
        public override ShipObtainedFromMap ReadJson(JsonReader reader, Type objectType, ShipObtainedFromMap existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.String)
                return new ShipObtainedFromMap() {Name = serializer.Deserialize<string>(reader)};
            return serializer.Deserialize<ShipObtainedFromMap>(reader);
        }

        public override void WriteJson(JsonWriter writer, ShipObtainedFromMap value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}