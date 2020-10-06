using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Jan0660.AzurAPINet.Ships;
using System.Diagnostics.CodeAnalysis;

namespace Jan0660.AzurAPINet.Converters
{
    public class ScrapValueConverter : JsonConverter<ShipScrapValue>
    {

        public override ShipScrapValue ReadJson(JsonReader reader, Type objectType, [AllowNull] ShipScrapValue existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            if (s != null)
            {
                return new ShipScrapValue(false);
            }
            else
            {
                return serializer.Deserialize<ShipScrapValue>(reader);
            }
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] ShipScrapValue value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
