using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Jan0660.AzurAPINet.Converters
{
    /// <summary>
    /// Parses a float even with '%' at the end of the string
    /// </summary>
    internal class BetterFloatConverter : JsonConverter<float>
    {
        public override float ReadJson(JsonReader reader, Type objectType, float existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            string str = reader.Value!.ToString();
            str = str.Replace("%", "");
            /* it took me half a hour to realize that when you set localization to czech on Windows
             * or just set units to use what czech use
             * float.Parse("1.44") will die because we dont use . we use ,
             * half a hour...
             * god, please erase this country
            */
            return float.Parse(str, CultureInfo.InvariantCulture);
        }

        public override void WriteJson(JsonWriter writer, float value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}