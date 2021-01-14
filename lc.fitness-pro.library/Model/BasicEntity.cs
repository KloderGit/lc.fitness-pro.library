using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace lc.fitnesspro.library.Model
{
    public class BasicEntity
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }
        [JsonProperty("Description")]
        public string Title { get; set; }
        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }
        [JsonProperty("DeletionMark")]
        public bool DeletionMark { get; set; }
        [JsonProperty("Predefined")]
        public bool Predefined { get; set; }
        [JsonProperty("Code")]
        public string Code { get; set; }
    }
}
