using lc.fitnesspro.library.Misc;
using Newtonsoft.Json;
using System;

namespace lc.fitnesspro.library.Model
{
    public class Employee
    {
        [JsonProperty("Ref_Key")]
        public string Key { get; set; }
        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }
        [JsonProperty("DeletionMark")]
        public bool DeletionMark { get; set; }
        [JsonProperty("Predefined")] 
        public bool Predefined { get; set; }
        [JsonProperty("Code")] 
        public string Code { get; set; }
        [JsonProperty("Description")] 
        public string Description { get; set; }

        [CanExpand("ТекущаяДолжность")]
        [JsonProperty("ТекущаяДолжность_Key")] 
        public Guid JobPositionKey { get; set; }

        [CanExpand("ФизЛицо")]
        [JsonProperty("ФизЛицо_Key")] 
        public Guid PersonKey { get; set; }
    }
}
