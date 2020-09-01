using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Model
{
    public class Program
    {
        [JsonProperty("Ref_Key")]
        public Guid RefKey { get; set; }

        [JsonProperty("ПолноеНаименование")]
        public string Title { get; set; }

        [JsonProperty("Часы")]
        public long Hours { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("DeletionMark")]
        public bool DeletionMark { get; set; }

        [JsonProperty("Цена")]
        public int Price { get; set; }

        [JsonProperty("Специальность_Key")]
        public Guid MajorKey { get; set; }

        [JsonProperty("ВидПрограммы_Key")]
        public Guid KindOfKey { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Примечание")]
        public string Comment { get; set; }

        [JsonProperty("Статус")]
        public string Status { get; set; }

        [JsonProperty("Сертифицируемый")]
        public bool IsSertificated { get; set; }

        [JsonProperty("ВыдаваемыйДокумент_Key")]
        public Guid GraduateDocumentKey { get; set; }

        [JsonProperty("ФормаОбучения_Key")]
        public Guid EducationFormKey { get; set; }

        [JsonProperty("ДатаУтверждения")]
        public DateTime SignAt { get; set; }

        [JsonProperty("ВсегоЧасов")]
        public int TotalHours { get; set; }

        [JsonProperty("ПрисваиваемаяКвалификация_Key")]
        public Guid QualificationKey { get; set; }

        [JsonProperty("ГруппаПрограммыОбучения_Key")]
        public Guid EducationProgramGroupKey { get; set; }

        [JsonProperty("НаправлениеПодготовки_Key")]
        public Guid EducationDirectionKey { get; set; }

        [JsonProperty("ПФ_ТипМероприятия_Key")]
        public Guid TypeKey { get; set; }

        [JsonProperty("Дисциплины")]
        public IEnumerable<Discipline> Disciplines { get; set; }

        [JsonProperty("Преподаватели")]
        public IEnumerable<Teacher> Teachers { get; set; }

        [JsonProperty("ФормыИтоговойАттестации")]
        public object[] AttestationType { get; set; }

        [JsonProperty("ВыдаваемыеДокументы")]
        public IEnumerable<IssuedDocument> IssuedDocuments { get; set; }
    }

    public class IssuedDocument
    {
        [JsonProperty("LineNumber")]
        public int LineNumber { get; set; }

        [JsonProperty("ВыдаваемыйДокумент_Key")]
        public Guid IssuedDocumentKey { get; set; }
    }

    public class Discipline
    {
        [JsonProperty("LineNumber")]
        public int LineNumber { get; set; }

        [JsonProperty("Дисциплина_Key")]
        public Guid DisciplineKey { get; set; }

        [JsonProperty("Часы")]
        public int Hours { get; set; }

        [JsonProperty("Обязательная")]
        public bool IsRequired { get; set; }

        [JsonProperty("ФормаКонтроля_Key")]
        public Guid ControlTypeKey { get; set; }

        [JsonProperty("ВсегоЧасов")]
        public int TotalHours { get; set; }
    }

    public class Teacher
    {
        [JsonProperty("LineNumber")]
        public int LineNumber { get; set; }

        [JsonProperty("Преподаватель_Key")]
        public Guid TeacherKey { get; set; }
    }
}
