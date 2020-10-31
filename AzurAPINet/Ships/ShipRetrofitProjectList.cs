using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace Jan0660.AzurAPINet.Ships
{
    public class ShipRetrofitProjectList
    {
        [JsonProperty]
        public readonly ShipRetrofitProject A;
        [JsonProperty]
        public readonly ShipRetrofitProject B;
        [JsonProperty]
        public readonly ShipRetrofitProject C;
        [JsonProperty]
        public readonly ShipRetrofitProject D;
        [JsonProperty]
        public readonly ShipRetrofitProject E;
        [JsonProperty]
        public readonly ShipRetrofitProject F;
        [JsonProperty]
        public readonly ShipRetrofitProject G;
        [JsonProperty]
        public readonly ShipRetrofitProject H;
        [JsonProperty]
        public readonly ShipRetrofitProject I;
        [JsonProperty]
        public readonly ShipRetrofitProject J;
        [JsonProperty]
        public readonly ShipRetrofitProject K;
        /// <summary>
        /// 
        /// </summary>
        /// <returns>A list with all the available <see cref="ShipRetrofitProject">retrofit project</see>s</returns>
        public List<ShipRetrofitProject> ToList()
        {
            var result = new List<ShipRetrofitProject>();
            // youve evr jsut
            if (A != null) { result.Add(A); }
            if (B != null) { result.Add(B); }
            if (C != null) { result.Add(C); }
            if (D != null) { result.Add(D); }
            if (E != null) { result.Add(E); }
            if (F != null) { result.Add(F); }
            if (G != null) { result.Add(G); }
            if (H != null) { result.Add(H); }
            if (I != null) { result.Add(I); }
            if (J != null) { result.Add(J); }
            if (K != null) { result.Add(K); }
            return result;
        }
    }
}
