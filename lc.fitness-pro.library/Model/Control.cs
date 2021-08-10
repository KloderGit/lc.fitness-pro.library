using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Model
{
    public class Control : Catalog
    {
        private string description;

        [Obsolete]
        [JsonProperty("Description")]
        public string Description
        {
            get => description;
            set { Title = description = value; }
        }

        [JsonProperty("СистемаОценки_Key")]
        public Guid ControlType { get; set; }

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
