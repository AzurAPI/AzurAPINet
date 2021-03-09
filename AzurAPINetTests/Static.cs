#define HieiTest
using Jan0660.AzurAPINet;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzurAPINetTests
{
    public static class Static
    {
#if HieiTest
        public static AzurAPIClient Client = new AzurAPIClient(ClientType.HieiAndWeb, new AzurAPIClientOptions()
            {HieiUrl = "http://localhost:1024"});
#else
        public static AzurAPIClient Client = new AzurAPIClient(new AzurAPIClientOptions());
#endif
    }
}
