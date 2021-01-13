using lc.fitnesspro.library.Misc;
using Newtonsoft.Json;
using System;

namespace lc.fitnesspro.library.Model
{
    public partial class Student
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("DeletionMark")]
        public bool DeletionMark { get; set; }

        [JsonProperty("ФизЛицо_Key")]
        public Guid PersonKey{ get; set; }
        [CanExpand("ФизЛицо")]
        [JsonProperty("ФизЛицо")]
        public Person Person { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
