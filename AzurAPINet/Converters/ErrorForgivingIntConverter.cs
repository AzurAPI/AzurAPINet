using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINet.Converters
{
    internal class ErrorForgivingInt32Converter : JsonConverter<int>
    {
        public override int ReadJson(JsonReader reader, Type objectType, int existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            try
            {
                return int.Parse(reader.Value!.ToString());
            }
            catch
            {
                return default;
            }
        }

        public override void WriteJson(JsonWriter writer, int value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}