using Jan0660.AzurAPINet.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static AzurAPINetTests.Static;

namespace AzurAPINetTests
{
    [TestClass]
    public class EnumConversions
    {
        [TestMethod]
        public void ShipRarityToGeneralRarity()
        {
            foreach(var val in (ShipRarity[])Enum.GetValues(typeof(ShipRarity)))
            {
                val.ToGeneralRarity();
            }
        }
    }
}
