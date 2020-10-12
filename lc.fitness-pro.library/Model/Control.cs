using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Model
{
    public class Control
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

        [JsonProperty("ВидНагрузки")]
        public string ControlType { get; set; }

        [JsonProperty("СистемыОценки")]
        public IEnumerable<ControlType> RateType { get; set; }
    }

    public class ControlType
    {
        [JsonProperty("Ref_Key")] public Guid Key { get; set; }
        [JsonProperty("LineNumber")] public string LineNumber { get; set; }
        [JsonProperty("СистемаОценки_Key")] public Guid RateKey { get; set; }
    }

}
