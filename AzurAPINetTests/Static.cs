#undef HieiTest
using Jan0660.AzurAPINet;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Workers = 12, Scope = ExecutionScope.MethodLevel)]
namespace AzurAPINetTests
{
    public static class Static
    {
#if HieiTest
        public static AzurAPIClient Client = new AzurAPIHieiClient(new AzurAPIClientOptions()
            {HieiUrl = "http://comtan:1024"});
#else
        public static AzurAPIClient Client = new AzurAPIClient(new AzurAPIClientOptions());
#endif
    }
}
