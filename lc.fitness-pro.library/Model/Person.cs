using lc.fitnesspro.library.Misc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lc.fitnesspro.library.Model
{
    public class Person
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
        public DateTime Birthday { get; set; }

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
        public DateTime ModifyAt { get; set; }

        [JsonProperty("ОпытЗанятияСпортом")]
        public string SportExpirience { get; set; }

        [JsonProperty("ИностранныеЯзыки")]
        public List<object> ForeignLanguages { get; set; }

        [JsonProperty("КонтактнаяИнформация")]
        public List<Contact> Contacts { get; set; }


        [JsonProperty("Гражданство_Key")]
        public Guid CitizenshipKey { get; set; }
        [CanExpand("Гражданство")]
        [JsonProperty("Гражданство")]
        public Citizenship Citizenship { get; set; }

        [JsonProperty("Должность_Key")]
        public Guid JobPositionKey { get; set; }
        [CanExpand("Должность")]
        [JsonProperty("Должность")]
        public JobPosition JobPosition { get; set; }


        [JsonProperty("МестоРаботы_Key")]
        public Guid CompanyKey { get; set; }
        [CanExpand("МестоРаботы")]
        [JsonProperty("МестоРаботы")]
        public Company Company { get; set; }


        [JsonProperty("Ответственный_Key")]
        public Guid ResponsiblePersonKey { get; set; }
        [CanExpand("Ответственный")]
        [JsonProperty("Ответственный")]
        public ResponsibleUser ResponsibleUser { get; set; }        
    }

    public class Contact
    {
        IEnumerable<Guid> phoneTypes = new List<Guid> {
                    new Guid("07ba41ce-3e65-4d14-8d3e-046a2729af4f"),
                    new Guid("a071e1b7-4a29-4bd2-b949-3d07ec290951"),
                    new Guid("02a496e5-32f5-4939-a320-46b7218e4ce5")};

        Guid emailType = new Guid("ea0a71c0-2218-410c-9c96-d7412c1a81ce");


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


        public bool IsPhone()
        {
            return phoneTypes.Contains(KindOfKey);
        }

        public bool IsEmail()
        {
            return this.KindOfKey == emailType;
        }
    }

    public class Citizenship
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }

        [JsonProperty("DeletionMark")]
        public bool IsDelete { get; set; }

        [JsonProperty("Predefined")]
        public bool Predefined { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("НаименованиеПолное")]
        public string Title { get; set; }

        [JsonProperty("КодАльфа2")]
        public string RegionCode1 { get; set; }

        [JsonProperty("КодАльфа3")]
        public string RegionCode2 { get; set; }
    }

    public class JobPosition
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }

        [JsonProperty("DeletionMark")]
        public bool IsDelete { get; set; }

        [JsonProperty("Predefined")]
        public bool Predefined { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }

    public class Company
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }

        [JsonProperty("DeletionMark")]
        public bool IsDelete { get; set; }

        [JsonProperty("Predefined")]
        public bool Predefined { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("НаименованиеПолное")]
        public string Title { get; set; }

        [JsonProperty("ИНН")]
        public string INN { get; set; }
    }

    public class ResponsibleUser
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }

        [JsonProperty("DeletionMark")]
        public bool IsDelete { get; set; }

        [JsonProperty("Predefined")]
        public bool Predefined { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ФизЛицо_Key")]
        public Guid PersonKey { get; set; }

        [JsonProperty("Сотрудник_Key")]
        public Guid EmployeeKey { get; set; }
    }

}