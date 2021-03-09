using Jan0660.AzurAPINet.Equipments;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Jan0660.AzurAPINet.Converters
{
    public class EquipmentStatConverter : JsonConverter<EquipmentStat>
    {
        public override EquipmentStat ReadJson(JsonReader reader, Type objectType, [AllowNull] EquipmentStat existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.StartObject)
                return serializer.Deserialize<EquipmentStat>(reader);
            // JsonToken.StartArray
            return serializer.Deserialize<List<EquipmentStat>>(reader)!.First();
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] EquipmentStat value, JsonSerializer serializer)
        {
            throw new Exception("no");
        }
    }
}
