using lc.fitnesspro.library.Misc;
using Newtonsoft.Json;
using System;

namespace lc.fitnesspro.library.Model
{
    public class Employee : Catalog
    {
        private string description;

        [Obsolete]
        [JsonProperty("Description")]
        public string Description
        {
            get => description;
            set { Title = description = value; }
        }

        [CanExpand("ТекущаяДолжность")]
        [JsonProperty("ТекущаяДолжность_Key")] 
        public Guid JobPositionKey { get; set; }
        [JsonProperty("ФизЛицо_Key")] 
        public Guid PersonKey { get; set; }
        [CanExpand("ФизЛицо")]
        [JsonProperty("ФизЛицо")] 
        public Person Person { get; set; }
    }
}
