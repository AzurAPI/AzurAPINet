using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class Mission
    {
        public Names Names;
        public MissionMap Normal;
        public MissionMap Hard;

        /// <summary>
        /// returns the english name of the mission
        /// </summary>
        public override string ToString()
            => Names.en;
    }
}
