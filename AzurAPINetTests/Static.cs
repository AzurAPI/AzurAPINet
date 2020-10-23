using Jan0660.AzurAPINet;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzurAPINetTests
{
    public static class Static
    {
        public static AzurAPIClient Client = new AzurAPIClient(new AzurAPIClientOptions());
    }
}
