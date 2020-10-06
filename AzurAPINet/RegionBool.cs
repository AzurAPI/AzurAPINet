using Jan0660.AzurAPINet.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Jan0660.AzurAPINet
{
    public enum RegionBool { False, JapaneseAndChineseOnly, True, Other }
    public enum Region { English, Japanese, Chinese }
    [JsonConverter(typeof(RegionBoolConverter))]
    public class RegionBoolean
    {
        public string StringValue;
        public RegionBool RegionBool;
        public Region Region;
        public bool Bool
        {
            get
            {
                switch (RegionBool)
                {
                    case RegionBool.False:
                        return false;
                    case RegionBool.True:
                        return true;
                    case RegionBool.JapaneseAndChineseOnly when Region != Region.English:
                        return true;
                    case RegionBool.JapaneseAndChineseOnly when Region == Region.English:
                        return false;
                    case RegionBool.Other:
                        return false;
                    default:
                        return false;
                }
            }
        }
        public RegionBoolean(string str, Region region = Region.English)
        {
            StringValue = str;
            Region = region;
            switch (str.ToLower())
            {
                case "true":
                    RegionBool = RegionBool.True;
                    break;
                case "false":
                    RegionBool = RegionBool.False;
                    break;
                case "cn/jp only":
                    RegionBool = RegionBool.JapaneseAndChineseOnly;
                    break;
                default:
                    RegionBool = RegionBool.Other;
                    break;
            }
        }
    }
}
