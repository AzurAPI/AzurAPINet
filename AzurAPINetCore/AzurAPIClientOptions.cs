using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINetCore
{
    public class AzurAPIClientOptions
    {
        /// <summary>
        /// not enabling caching is practically performance suicide, see docs for more
        /// </summary>
        public bool EnableCaching = true;
    }
}
