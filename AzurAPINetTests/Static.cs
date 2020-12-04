#define HieiTest
using Jan0660.AzurAPINet;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzurAPINetTests
{
    public static class Static
    {
#if  HieiTest
        public static AzurAPIClient Client = new AzurAPIClient(ClientType.Hiei);
#else
        public static AzurAPIClient Client = new AzurAPIClient(new AzurAPIClientOptions());
#endif
    }
}
