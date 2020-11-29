using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Jan0660.AzurAPINet.Converters
{
    /// <summary>
    /// Parses a float even with '%' or 's' at the end of the string
    /// </summary>
    public class BetterFloatConverter : JsonConverter<float>
    {
        // pain
        const string Numbers = "1234567890";
        // todo: theres probably a smarter way to do this
        public override float ReadJson(JsonReader reader, Type objectType, [AllowNull] float existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string str = reader.Value.ToString();
            str = str.Replace("s", "").Replace("%", "");
            try
            {
                /* it took me half a hour to realize that when you set localization to czech
                 * or just set units to use what czech use
                 * float.Parse("1.44") will die because we dont use . we use ,
                 * half a hour...
                 * god, please erase this country
                */
                return float.Parse(str, CultureInfo.InvariantCulture);
                if (Numbers.Contains(str.Last()))
                    return float.Parse(str);
                else
                    return float.Parse(str.Remove(str.Length - 1));
            }catch(Exception e)
            {
                return 0.0f;
            }
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] float value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
