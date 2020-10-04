using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Jan0660.AzurAPINetCore.Ships;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.CodeAnalysis;

namespace Jan0660.AzurAPINetCore
{
    public class EnhanceValueConverter : JsonConverter<ShipEnhanceValue>
    {
        public override ShipEnhanceValue ReadJson(JsonReader reader, Type objectType, [AllowNull] ShipEnhanceValue existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            if (s != null)
            {
                return new ShipEnhanceValue(false);
            }
            else
            {
                return serializer.Deserialize<ShipEnhanceValue>(reader);
            }
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] ShipEnhanceValue value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
