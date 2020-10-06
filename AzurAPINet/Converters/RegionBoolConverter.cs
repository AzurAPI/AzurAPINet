using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Jan0660.AzurAPINet.Converters
{
    public class RegionBoolConverter : JsonConverter<RegionBoolean>
    {
        public override RegionBoolean ReadJson(JsonReader reader, Type objectType, [AllowNull] RegionBoolean existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RegionBoolean(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] RegionBoolean value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
