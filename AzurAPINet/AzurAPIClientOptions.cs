using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet
{
    public class AzurAPIClientOptions
    {
        /// <summary>
        /// not enabling caching is practically performance suicide, see docs for more
        /// </summary>
        public bool EnableCaching = true;

        /// <summary>
        /// auth for Hiei server
        /// </summary>
        public string HieiPass = "1234";

        public string HieiUrl;
        
        /// <summary>
        /// default: ClientType.Web
        /// </summary>
        public ClientType ClientType = ClientType.Web;

        /// <summary>
        /// path to local clone of the db
        /// </summary>
        public string LocalPath;
    }
}