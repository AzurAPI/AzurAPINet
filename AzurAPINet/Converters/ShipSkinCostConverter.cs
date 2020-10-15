using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Jan0660.AzurAPINet.Converters
{
    public class ShipSkinCostConverter : JsonConverter<int>
    {
        public override int ReadJson(JsonReader reader, Type objectType, [AllowNull] int existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return int.Parse((reader.Value as string).Split(' ')[0]);
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] int value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
