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
        public StudentSlim Student { get; set; }
        [JsonProperty("ПрограммаОбучения")]
        public EducationProgramSlim EducationProgram { get; set; }
        [JsonProperty("ГруппаСлушателя")]
        public GroupSlim Group { get; set; }
        [JsonProperty("ПодгруппаСлушателя")]
        public BaseSlim SubGroup { get; set; }
        
        public class StudentSlim
        {
            [JsonProperty("Ref_Key")]
            public Guid Key { get; set; } 
            [JsonProperty("ФизЛицо_Key")]
            public Guid PersonKey { get; set; }
            [JsonProperty("Description")]
            public string Title { get; set; }
        }
        
        public class EducationProgramSlim
        {
            [JsonProperty("Ref_Key")]
            public Guid Key { get; set; } 
            [JsonProperty("ФормаОбучения_Key")]
            public Guid EducationFormKey { get; set; }
            [JsonProperty("Description")]
            public string Title { get; set; }
        }
        
        public class GroupSlim
        {
            [JsonProperty("Ref_Key")]
            public Guid Key { get; set; } 
            [JsonProperty("Description")]
            public string Title { get; set; }
            
            [JsonProperty("ДатаНачалаОбучения")]
            public DateTime StartDate { get; set; }
            [JsonProperty("ДатаокончанияОбучения")]
            public DateTime FinishDate { get; set; }
        }
        
        public class BaseSlim
        {
            [JsonProperty("Ref_Key")]
            public Guid Key { get; set; } 
            [JsonProperty("Description")]
            public string Title { get; set; }
        }
    }
}
