using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace lc.fitnesspro.library.Model
{
    public partial class Student
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }


        [JsonProperty("IntTest")]
        public int SomeInt { get; set; }

        [JsonProperty("Dateee")]
        public DateTime Dateee { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("DeletionMark")]
        public bool DeletionMark { get; set; }

        [JsonProperty("ФизЛицо_Key")]
        public Guid PersonKey{ get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
