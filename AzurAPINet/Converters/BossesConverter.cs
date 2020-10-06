using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINet.Converters
{
    public class BossesConverter : JsonConverter<List<string>>
    {
        // todo: there's probably a better way to do this.
        public override List<string> ReadJson(JsonReader reader, Type objectType, [AllowNull] List<string> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            /*
            try
            {
                var a = serializer.Deserialize<List<string>>(reader);
                return a;
            }
            catch
            {
                return new List<string>() { serializer.Deserialize<string>(reader) };
            }
            */
            if (reader.TokenType == JsonToken.String)
            {
                return new List<string>() { serializer.Deserialize<string>(reader) };
            }
            else
            {
                var a = serializer.Deserialize<List<string>>(reader);
                return a;
            }
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] List<string> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }
}
