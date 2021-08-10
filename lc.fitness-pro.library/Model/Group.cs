using System;
using Newtonsoft.Json;

namespace lc.fitnesspro.library.Model
{
    public class Group : Catalog
    {
        [JsonProperty("ПрограммаОбучения_Key")]
        public Guid ProgramKey { get; set; }
        [JsonProperty("ДатаНачалаОбучения")]
        public DateTime Start { get; set; }
        [JsonProperty("ДатаокончанияОбучения")]
        public DateTime Finish { get; set; }
    }
}