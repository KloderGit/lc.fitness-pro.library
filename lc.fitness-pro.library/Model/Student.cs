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
    
    
    public class StudentEducationInfoSlim
    {
        [JsonProperty("Слушатель")]
        public BaseSlim Student { get; set; }
        [JsonProperty("ПрограммаОбучения")]
        public BaseSlim EducationProgram { get; set; }
        [JsonProperty("ГруппаСлушателя")]
        public BaseSlim Group { get; set; }
        [JsonProperty("ПодгруппаСлушателя")]
        public BaseSlim SubGroup { get; set; }
        
        public class BaseSlim
        {
            [JsonProperty("Ref_Key")]
            public Guid Key { get; set; } 
            [JsonProperty("Description")]
            public string Title { get; set; }
        }
    }
}
