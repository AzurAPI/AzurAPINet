using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore
{
    public class DatabaseVersionInfo
    {
        [JsonProperty("ships")]
        public DatabaseItemVersionInfo Ships;
        [JsonProperty("equipments")]
        public DatabaseItemVersionInfo Equipments;
    }
}
