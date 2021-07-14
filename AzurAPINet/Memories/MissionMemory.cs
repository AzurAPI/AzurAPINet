using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Memories
{
    public class MissionMemory
    {
        public Names Names;
        public LineMemory[] Lines;

        public override string ToString()
            => Names.en;
    }
}
