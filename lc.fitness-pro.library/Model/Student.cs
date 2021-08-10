using lc.fitnesspro.library.Misc;
using Newtonsoft.Json;
using System;

namespace lc.fitnesspro.library.Model
{
    public partial class Student : Catalog
    {
        private string description;

        [JsonProperty("ФизЛицо_Key")]
        public Guid PersonKey{ get; set; }
        [CanExpand("ФизЛицо")]
        [JsonProperty("ФизЛицо")]
        public Person Person { get; set; }

        [Obsolete]
        [JsonProperty("Description")]
        public string Description
        {
            get => description;
            set => Title = description = value;
        }
    }
}
