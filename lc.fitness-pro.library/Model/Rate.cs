using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Model
{
    public class Rate : Catalog
    {
        private string description;

        [JsonProperty("Parent_Key")]
        public Guid ParentKey { get; set; }

        [Obsolete]
        [JsonProperty("Description")]
        public string Description
        {
            get => description;
            set => Title = description = value;
        }

        [JsonProperty("МаксимальныйБалл")]
        public int MaxGrade { get; set; }

        [JsonProperty("МинимальныйБалл")]
        public int MinGrade { get; set; }

        [JsonProperty("Балл")]
        public string Grade { get; set; }
    }
}
