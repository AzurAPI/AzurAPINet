using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class MissionNodeMap
    {
        public string Preview;
        public int Width;
        public int Height;
        public string[,] Map;
        public MissionMapNode[] Nodes;
    }
}
