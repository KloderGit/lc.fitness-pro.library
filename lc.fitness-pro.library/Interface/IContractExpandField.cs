using lc.fitnesspro.library.Misc;
using System;

namespace lc.fitnesspro.library.Interface
{
    public interface IContractExpandField
    {
        [CanExpand("ТипДоговора")]
        Guid ContactTypeKey { get; set; }

        [CanExpand("Слушатель")]
        Guid StudentKey { get; set; }

        [CanExpand("ПрограммаОбучения")]
        Guid EducationProgramKey { get; set; }

        [CanExpand("Плательщик")]
        Guid PayerKey { get; set; }

        [CanExpand("Ответственный")]
        Guid ResponsiblePersonKey { get; set; }

        [CanExpand("ГруппаСлушателя")]
        Guid GroupKey { get; set; }

        [CanExpand("ПодгруппаСлушателя")]
        Guid SubGroupKey { get; set; }
    }
}
