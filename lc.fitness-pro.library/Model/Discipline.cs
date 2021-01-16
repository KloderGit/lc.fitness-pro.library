using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Model
{
    public class Discipline : Catalog
    {
        private string description;

        [Obsolete]
        [JsonProperty("Description")]
        public string Description
        {
            get => description;
            set { Title = description = value; }
        }
    }
}
