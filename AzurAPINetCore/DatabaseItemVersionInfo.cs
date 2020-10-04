﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jan0660.AzurAPINetCore
{
    public class DatabaseItemVersionInfo
    {
        [JsonProperty("version-number")]
        public int VersionNumber;
        [JsonProperty("last-data-refresh-date")]
        public ulong LastDataRefreshDate;
        [JsonProperty("hash")]
        public string Hash;
    }
}
