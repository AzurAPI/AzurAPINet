using Jan0660.AzurAPINet.Equipments;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Linq;

namespace Jan0660.AzurAPINet.Converters
{
    // todo: there might be a way to speed this up
    public class EquipmentStatConverter : JsonConverter<EquipmentStat>
    {
        public override EquipmentStat ReadJson(JsonReader reader, Type objectType, [AllowNull] EquipmentStat existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            try
            {
                return serializer.Deserialize<EquipmentStat>(reader);
            }
            catch
            {
                return serializer.Deserialize<List<EquipmentStat>>(reader).First();
            }
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] EquipmentStat value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
