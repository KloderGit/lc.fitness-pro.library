using lc.fitnesspro.library.Misc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace lc.fitnesspro.library.Model
{
    public class Program : Catalog
    {
        private Guid refKey;

        [Obsolete]
        [JsonProperty("Ref_Key")]
        public Guid RefKey
        {
            get => refKey;
            set => Key = refKey = value;
        }

        [JsonProperty("ПолноеНаименование")]
        public new string Title { get; set; }

        [JsonProperty("Часы")]
        public long Hours { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Цена")]
        public int Price { get; set; }

        // Тип мероприятия - Стажировка\Практика\Обучение
        [JsonProperty("ВидПрограммы_Key")]
        public Guid KindOfProgramKey { get; set; }
        [CanExpand("ВидПрограммы")]
        [JsonProperty("ВидПрограммы")]
        public EducationType KindOfProgram { get; set; }

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
        [CanExpand("ФормаОбучения")]
        [JsonProperty("ФормаОбучения")]
        public EducationForm EducationForm { get; set; }

        [JsonProperty("ДатаУтверждения")]
        public DateTime SignAt { get; set; }

        [JsonProperty("ВсегоЧасов")]
        public int TotalHours { get; set; }

        [JsonProperty("ПрисваиваемаяКвалификация_Key")]
        public Guid QualificationKey { get; set; }
        [CanExpand("ПрисваиваемаяКвалификация")]
        [JsonProperty("ПрисваиваемаяКвалификация")]
        public Qualification Qualification { get; set; }

        [JsonProperty("ГруппаПрограммыОбучения_Key")]
        public Guid EducationGroupKey { get; set; }
        [CanExpand("ГруппаПрограммыОбучения")]
        [JsonProperty("ГруппаПрограммыОбучения")]
        public EducationGroup EducationGroup { get; set; }

        [JsonProperty("НаправлениеПодготовки_Key")]
        public Guid EducationDirectionKey { get; set; }
        [CanExpand("НаправлениеПодготовки")]
        [JsonProperty("НаправлениеПодготовки")]
        public EducationDirection EducationDirection { get; set; }

        // Программа\Семинар
        [JsonProperty("ПФ_ТипМероприятия_Key")]
        public Guid EducationVariantKey { get; set; }
        [CanExpand("ПФ_ТипМероприятия")]
        [JsonProperty("ПФ_ТипМероприятия")]
        public EducationVariant EducationVariant { get; set; }

        [JsonProperty("Дисциплины")]
        public IEnumerable<DisciplineInfo> Disciplines { get; set; }

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

    public class DisciplineInfo
    {
        [JsonProperty("LineNumber")]
        public int LineNumber { get; set; }

        [JsonProperty("Дисциплина_Key")]
        public Guid DisciplineKey { get; set; }

        public Discipline Discipline { get; set; }

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
