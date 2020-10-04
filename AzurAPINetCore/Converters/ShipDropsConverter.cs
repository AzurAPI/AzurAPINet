using Jan0660.AzurAPINetCore.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Jan0660.AzurAPINetCore.Chapters
{
    public class ShipDropsConverter : JsonConverter<List<ShipDrop>>
    {
        // todo: theres probably a smarter way to do this
        public override List<ShipDrop> ReadJson(JsonReader reader, Type objectType, [AllowNull] List<ShipDrop> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            List<ShipDrop> output = new List<ShipDrop>();
            var arr = serializer.Deserialize<JArray>(reader);
            foreach (var item in arr)
            {
                //var str = item.ToString();
                if (item.Type!=JTokenType.String)
                {
                    var ass = item.ToObject<ShipDrop>();
                    //output.Add((JsonConvert.DeserializeObject<ShipDrop>(str)));
                    output.Add(ass);
                }
                else
                {
                    output.Add(new ShipDrop(item.Value<string>()));
                }
            }
            return output;
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] List<ShipDrop> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
