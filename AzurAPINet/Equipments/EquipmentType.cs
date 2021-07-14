using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Equipments
{
    public class EquipmentType
    {
        public string Focus;
        public string Name;

        public override string ToString()
            => Name;
    }
}
