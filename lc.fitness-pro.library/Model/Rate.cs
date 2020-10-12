using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Model
{
    public class Rate
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

        [JsonProperty("Parent_Key")]
        public Guid ParentKey { get; set; }

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

        [JsonProperty("МаксимальныйБалл")]
        public int MaxGrade { get; set; }

        [JsonProperty("МинимальныйБалл")]
        public int MinGrade { get; set; }

        [JsonProperty("Балл")]
        public string Grade { get; set; }
    }
}
