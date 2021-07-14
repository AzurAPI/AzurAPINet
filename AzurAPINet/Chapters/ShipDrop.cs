using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jan0660.AzurAPINet.Chapters
{
    public class ShipDrop
    {
        public string Name;
        public string Note;

        /// <summary>
        /// Returns the name of this ShipDrop.
        /// </summary>
        public override string ToString()
            => Name;
    }
}
