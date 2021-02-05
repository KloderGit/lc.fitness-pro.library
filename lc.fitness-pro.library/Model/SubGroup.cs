using System;
using Newtonsoft.Json;

namespace lc.fitnesspro.library.Model
{
    public class SubGroup : Catalog
    {
        [JsonProperty("Owner_Key")]
        public Guid GroupKey { get; set; }
    }
}