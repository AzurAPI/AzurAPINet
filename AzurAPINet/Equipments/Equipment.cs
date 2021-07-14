using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Equipments
{
    public class Equipment
    {
        public string WikiUrl;
        public string Category;
        public Names Names;
        public EquipmentType Type;
        public string Nationality;
        public string Image;
        public EquipmentFits Fits;
        public EquipmentMisc Misc;
        public EquipmentStats[] Tiers;

        public override string ToString()
            => Names.en;
    }
}
