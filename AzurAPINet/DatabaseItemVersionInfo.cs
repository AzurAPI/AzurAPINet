using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINet
{
    public class DatabaseItemVersionInfo
    {
        [JsonProperty("version-number")]
        public int VersionNumber;
        [JsonProperty("last-data-refresh-date")]
        public long LastDataRefreshValue;
        [JsonIgnore]
        public DateTimeOffset LastDataRefreshDate => DateTimeOffset.FromUnixTimeMilliseconds(LastDataRefreshValue);
        [JsonProperty("hash")]
        public string Hash;
    }
}
