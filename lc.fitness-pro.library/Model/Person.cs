using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace lc.fitness_pro.library.Model
{
    public partial class Person
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }

        [JsonProperty("DeletionMark")]
        public bool DeletionMark { get; set; }

        [JsonProperty("Predefined")]
        public bool Predefined { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ДатаРождения")]
        public DateTimeOffset Birthday { get; set; }

        [JsonProperty("ИНН")]
        public string INN { get; set; }

        [JsonProperty("ИностранныйГражданин")]
        public bool IsForeignPerson { get; set; }

        [JsonProperty("МестоРождения")]
        public string BirthdayPlace { get; set; }

        [JsonProperty("Пол")]
        public string Gender { get; set; }

        [JsonProperty("Хранилище_Type")]
        public string StoreType { get; set; }

        [JsonProperty("Хранилище_Base64Data")]
        public string StoreBase64Data { get; set; }

        [JsonProperty("ЛогинСкайп")]
        public string Skype { get; set; }

        [JsonProperty("Коментарий")]
        public string Comment { get; set; }

        [JsonProperty("РасширениеФайла")]
        public string FileExtension { get; set; }

        [JsonProperty("ДатаПоследнегоИзменения")]
        public DateTimeOffset ModifyAt { get; set; }

        [JsonProperty("ОпытЗанятияСпортом")]
        public string SportExpirience { get; set; }

        [JsonProperty("ИностранныеЯзыки")]
        public List<object> ForeignLanguages { get; set; }

        [JsonProperty("КонтактнаяИнформация")]
        public List<КонтактнаяИнформация> Contacts { get; set; }


        [JsonProperty("Гражданство_Key")]
        public Guid CitizenshipKey { get; set; }

        [JsonProperty("Должность_Key")]
        public Guid JobPositionKey { get; set; }

        [JsonProperty("МестоРаботы_Key")]
        public Guid CompanyKey { get; set; }

        [JsonProperty("Ответственный_Key")]
        public Guid ResponsiblePersonKey { get; set; }

        [JsonProperty("СемейноеПоложение_Key")]
        public Guid MarriedStatus { get; set; }
    }

    public partial class КонтактнаяИнформация
    {
        [JsonProperty("Ref_Key")]
        public Guid ParentKey { get; set; }

        [JsonProperty("LineNumber")]
        public long LineNumber { get; set; }

        [JsonProperty("Тип")]
        public string Type { get; set; }

        [JsonProperty("Вид_Key")]
        public Guid KindOfKey { get; set; }

        [JsonProperty("Представление")]
        public string Description { get; set; }

        [JsonProperty("ЗначенияПолей")]
        public string FieldValues { get; set; }

        [JsonProperty("Страна")]
        public string Country { get; set; }

        [JsonProperty("Регион")]
        public string Region { get; set; }

        [JsonProperty("Город")]
        public string City { get; set; }

        [JsonProperty("АдресЭП")]
        public string Email { get; set; }

        [JsonProperty("ДоменноеИмяСервера")]
        public string DomenName { get; set; }

        [JsonProperty("НомерТелефона")]
        public string Phone { get; set; }

        [JsonProperty("НомерТелефонаБезКодов")]
        public string ShortPhone { get; set; }
    }
}
