using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Model
{
    public class AssignDiscipline
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }

        [JsonProperty("DeletionMark")]
        public bool DeletionMark { get; set; }

        [JsonProperty("Number")]
        public string Code { get; set; }

        [JsonProperty("ПФ_Преподаватели")]
        public IEnumerable<TeacherForDiscipline> Teachers { get; set; }

        [JsonProperty("Дисциплины")]
        public IEnumerable<DisciplineForTeacher> Disciplines { get; set; }
    }


    public class TeacherForDiscipline
    {
        [JsonProperty("Преподаватель_Key")]
        public Guid TeacherKey { get; set; }

        [JsonProperty("КлючСтроки")]
        public int Marker { get; set; }
    }

    public class DisciplineForTeacher
    {
        [JsonProperty("Дисциплина_Key")]
        public Guid DisciplineKey { get; set; }

        [JsonProperty("КлючСтроки")]
        public int Marker { get; set; }
    }
}
