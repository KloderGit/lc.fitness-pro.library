using System;
using Newtonsoft.Json;

namespace lc.fitnesspro.library.Model
{
    public class Payer : Catalog
    {
        private string description;

        [JsonProperty("DeletionMark")]
        public bool IsDelete { get; set; }

        [Obsolete]
        [JsonProperty("Description")]
        public string Description
        {
            get => description;
            set { Title = description = value; }
        }

        [JsonProperty("ЮрФизЛицо")]
        public string PersonOrCompany { get; set; }
    }
}