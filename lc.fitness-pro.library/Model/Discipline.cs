using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Model
{
    public class Discipline
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

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
    }
}
