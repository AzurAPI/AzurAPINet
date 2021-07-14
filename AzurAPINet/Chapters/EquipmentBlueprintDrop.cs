using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class EquipmentBlueprintDrop
    {
        public string Name;
        public string Tier;

        public override string ToString()
            => Name;
    }
}
