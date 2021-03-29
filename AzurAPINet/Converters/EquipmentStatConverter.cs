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
    internal class EquipmentStatConverter : JsonConverter<EquipmentStat[]>
    {
        public override EquipmentStat[] ReadJson(JsonReader reader, Type objectType,
            [AllowNull] EquipmentStat[] existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // have i ever told you about how much i want to murder people that do the fucking
            // "IS THIS AN ARRAY? IS THIS AN OBJECT? DONT KNOW. FUCK YOU."
            if (reader.TokenType == JsonToken.StartObject)
                return new[] {serializer.Deserialize<EquipmentStat>(reader)};
            // JsonToken.StartArray
            return serializer.Deserialize<EquipmentStat[]>(reader);
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] EquipmentStat[] value, JsonSerializer serializer)
        {
            throw new Exception("no");
        }
    }
}