using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Jan0660.AzurAPINet.Ships;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINet.Converters
{
    public class ShipObtainedFromMapConverter : JsonConverter<ShipObtainedFromMap>
    {
        // todo: there's probably a better way to do this.
        public override ShipObtainedFromMap ReadJson(JsonReader reader, Type objectType, [AllowNull] ShipObtainedFromMap existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            try
            {
                return serializer.Deserialize<ShipObtainedFromMap>(reader);
            }
            catch
            {
                return new ShipObtainedFromMap() {Name = serializer.Deserialize<string>(reader)};
            }
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] ShipObtainedFromMap value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }
}