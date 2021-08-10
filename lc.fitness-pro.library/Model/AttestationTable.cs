using lc.fitnesspro.library.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Model
{
    public class AttestationTable : Document
    {
        [JsonProperty("НомерВедомости")]
        public string Title { get; set; }
        [JsonProperty("ДатаСдачи")]
        public DateTime AttestationDate { get; set; }
        [JsonProperty("Дисциплина_Key")]
        public Guid DisciplineKey { get; set; }
        [JsonProperty("Преподаватель_Key")]
        public Guid TeacherKey { get; set; }
        [JsonProperty("ЦиклДПО_Key")]
        public Guid ProgramKey { get; set; }
        [JsonProperty("ВидНагрузки_Key")]
        public Guid ControlTypeKey { get; set; }
        [JsonProperty("Группа_Key")]
        public Guid GroupKey { get; set; }
        [JsonProperty("Слушатели")]
        public ICollection<AttestationStudent> Registry { get; private set; } = new List<AttestationStudent>();

        public void AddRegisterUnit(IRegisterUnit item)
        {
            Registry.Add((AttestationStudent)item);

            var count = 1;
            foreach (var unit in Registry)
            {
                unit.LineNumber = count.ToString();
                count++;
            }
        }

        public void RemoveRegisterUnit(IRegisterUnit item)
        {
            Registry.Remove((AttestationStudent)item);

            var count = 1;
            foreach (var unit in Registry)
            {
                unit.LineNumber = count.ToString();
                count++;
            }
        }

        public bool Validate()
        { 
            return Date != default;
        }
    }

    public class AttestationStudent : IRegisterUnit
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }
        [JsonProperty("LineNumber")]
        public string LineNumber { get; set; }
        [JsonProperty("Слушатель_Key")]
        public Guid StudentKey { get; set; }
        [JsonProperty("Оценка_Key")]
        public Guid Rate { get; set; }
        [JsonProperty("ПФ_Комментарий")]
        public string Comment { get; set; }
        [JsonProperty("ОтличникУчебы")]
        public bool IsExcelentStudent { get; set; }
    }

}
