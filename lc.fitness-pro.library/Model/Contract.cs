using System;
using System.Collections.Generic;

using System.Globalization;
using lc.fitnesspro.library.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace lc.fitnesspro.library.Model
{
    public class Contract : IDocument
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

        [JsonProperty("DataVersion")]
        public string DataVersion { get; set; }

        [JsonProperty("DeletionMark")]
        public bool DeletionMark { get; set; }

        [JsonProperty("Number")]
        public string Number { get; set; }

        [JsonProperty("Date")]
        public DateTime SigningDate { get; set; }

        [JsonProperty("Posted")]
        public bool Posted { get; set; }

        [JsonProperty("НомерДоговора")]
        public string RegisterTitle { get; set; }

        [JsonProperty("ТипДоговора_Key")]
        public Guid ContactTypeKey { get; set; }

        [JsonProperty("СуммаДоговора")]
        public decimal Amount { get; set; }

        [JsonProperty("Слушатель_Key")]
        public Guid StudentKey { get; set; }

        [JsonProperty("ДатаНачала")]
        public DateTime StartEducationDate { get; set; }

        [JsonProperty("ДатаОкончания")]
        public DateTime FinisEducationhDate { get; set; }

        [JsonProperty("ПрограммаОбучения_Key")]
        public Guid EducationProgramKey { get; set; }

        [JsonProperty("Плательщик_Key")]
        public Guid PayerKey { get; set; }

        [JsonProperty("ГрупповойДоговор")]
        public bool IsGroupContract { get; set; }

        [JsonProperty("Финансирование")]
        public FinancingTypeEnum Financing { get; set; }

        [JsonProperty("ДатаЗакрытия")]
        public DateTime ExpiredDate { get; set; }

        [JsonProperty("Ответственный_Key")]
        public Guid ResponsiblePersonKey { get; set; }

        [JsonProperty("Комментарий")]
        public string Comment { get; set; }

        [JsonProperty("Скидка")]
        public decimal Discount { get; set; }

        [JsonProperty("ЦенаСоСкидкой")]
        public decimal DiscontedPrice { get; set; }

        [JsonProperty("УчитыватьПерсональнуюСкидку")]
        public bool CanIncludePersonalDiscount { get; set; }

        [JsonProperty("ГруппаСлушателя_Key")]
        public Guid GroupKey { get; set; }

        [JsonProperty("ПодгруппаСлушателя_Key")]
        public Guid SubGroupKey { get; set; }

        [JsonProperty("Слушатели")]
        public ICollection<RegisterStudent> Registry { get; private set; } = new List<RegisterStudent>();

        public void AddRegisterUnit(IRegisterUnit item)
        {
            Registry.Add((RegisterStudent)item);

            var count = 1;
            foreach (var unit in Registry)
            {
                unit.LineNumber = count.ToString();
                count++;
            }
        }

        public void RemoveRegisterUnit(IRegisterUnit item)
        {
            Registry.Remove((RegisterStudent)item);

            var count = 1;
            foreach (var unit in Registry)
            {
                unit.LineNumber = count.ToString();
                count++;
            }
        }
    }

    public enum FinancingTypeEnum { СОплатойОбучения };


    public class RegisterStudent : IRegisterUnit
    {
        [JsonProperty("Ref_Key")]
        public Guid Key { get; set; }

        [JsonProperty("LineNumber")]
        public string LineNumber { get; set; }

        [JsonProperty("Слушатель_Key")]
        public Guid StudentKey { get; set; }
    }
}
