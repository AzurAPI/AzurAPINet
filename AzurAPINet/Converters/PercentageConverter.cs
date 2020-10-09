using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Jan0660.AzurAPINet.Converters
{
    public class PercentageConverter : JsonConverter<float>
    {
        public override float ReadJson(JsonReader reader, Type objectType, [AllowNull] float existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string str = reader.Value.ToString();
            return float.Parse(str.Remove(str.Length - 1));
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] float value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
