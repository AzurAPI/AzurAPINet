using Jan0660.AzurAPINet.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    internal class ShipDropsConverter : JsonConverter<List<ShipDrop>>
    {
        public override List<ShipDrop> ReadJson(JsonReader reader, Type objectType, List<ShipDrop> existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            List<ShipDrop> output = new List<ShipDrop>();
            var arr = serializer.Deserialize<JArray>(reader);
            foreach (var item in arr)
            {
                if (item.Type != JTokenType.String)
                {
                    var ass = item.ToObject<ShipDrop>();
                    output.Add(ass);
                }
                else
                {
                    output.Add(new ShipDrop() { Name = item.Value<string>() });
                }
            }

            return output;
        }

        public override void WriteJson(JsonWriter writer, List<ShipDrop> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}