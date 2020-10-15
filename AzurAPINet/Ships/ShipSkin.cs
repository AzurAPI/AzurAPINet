using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Ships
{
#nullable enable
#nullable disable warnings
    public class ShipSkin
    {
        [JsonProperty("name")]
        public readonly string Name;
        [JsonProperty("image")]
        public readonly string Image;
        /// <summary>
        /// in case of chinese censorship of waifus
        /// </summary>
        [JsonProperty("imageCN")]
        public readonly string? ImageCN;
        [JsonProperty("background")]
        public readonly string Background;
        [JsonProperty("chibi")]
        public readonly string Chibi;
        [JsonProperty("info")]
        public readonly ShipSkinInfo Info;
        public List<string> GetSkinUrlsList()
        {
            List<string> list = new List<string> { Image,  Chibi, Background };
            if(ImageCN!=null)
            list.Add(ImageCN);
            return list;
        }
    }
}
