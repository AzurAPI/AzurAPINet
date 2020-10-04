using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Newtonsoft.Json.Linq;
using Jan0660.AzurAPINetCore.Ships;
namespace Jan0660.AzurAPINetCore.Converters
{
    public class ConstructionInfoConverter : JsonConverter<ShipConstructionInfo>
    {
        /*
        public bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            TimeSpan timeSpan;
            TimeSpan.TryParseExact((string)reader.Value, @"hh\:mm\:ss",null, out timeSpan);
            if (timeSpan == null)
            {
                return new ShipConstructionInfo() { ConstructionTime=timeSpan };
            }
            else
            {
                return new ShipConstructionInfo() { ConstructionTime = timeSpan };
            }
        }
        */
        public override ShipConstructionInfo ReadJson(JsonReader reader, Type objectType, [AllowNull] ShipConstructionInfo existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            ShipConstructionInfo output = new ShipConstructionInfo() { Constructable=false};
            JObject jObject = JObject.Load(reader);
            dynamic dyn = jObject;
            TimeSpan timeSpan;
            bool constructable = TimeSpan.TryParseExact((string)dyn.constructionTime, @"hh\:mm\:ss", null, out timeSpan);
            output.Constructable = constructable;
            output.ConstructionTime = timeSpan;
            string json = dyn.availableIn.ToString();
            try
            {
                output.AvailableIn = JsonConvert.DeserializeObject<ShipConstructionAvailableIn>(json);
            }
            catch(Exception exc)
            {

            }
            return output;
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] ShipConstructionInfo value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
