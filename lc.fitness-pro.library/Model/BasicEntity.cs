using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace lc.fitnesspro.library.Model
{
    public class Core
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; } 
        [JsonProperty("DeletionMark")]
        public bool DeletionMark { get; set; }
        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }
    }

    public class Catalog : Core
    {
        [JsonProperty("Code")]
        public string Code { get; set; }
        [JsonProperty("Predefined")]
        public bool Predefined { get; set; }
        [JsonProperty("Description")]
        public string Title { get; set; }
    }

    public class Document : Core
    {
        [JsonProperty("Number")]
        public string Code { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("Posted")]
        public bool Posted { get; set; }
    }
}
