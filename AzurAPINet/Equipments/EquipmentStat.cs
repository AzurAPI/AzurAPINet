using System;
using System.Collections.Generic;
using System.Text;
using Jan0660.AzurAPINet.Converters;
using Newtonsoft.Json;
namespace Jan0660.AzurAPINet.Equipments
{
    public class EquipmentStat
    {
        public string Type;
        public string min;
        public string max;
        public string per;
        public string value;
        public string unit;
        public int firing;
        public int shell;
        public string formatted;
    }
}
