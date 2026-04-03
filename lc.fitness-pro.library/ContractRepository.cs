using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;

namespace lc.fitnesspro.library
{
    public class ContractRepository : Repository<Contract>
    {
        public ContractRepository(IConnection connection)
            : base(connection)
        { }

        public async Task<IEnumerable<Contract>> GetByStudents(IEnumerable<Guid> students)
        {
            var array = GetQueryStringArray(students);
            return await GetByStudentsRequest(array);
        }
        
        
        public async Task<IEnumerable<StudentEducationInfoSlim>> FilterStudentsInfo(
            List<Guid> educationProgramKeys,
            List<Guid> groupKeys,
            List<Guid> subGroupKeys,
            int? top,
            int? skip,
            bool? isArchivedIncluded,
            DateTimeOffset? startDate,
            DateTimeOffset? finishDate,
            CancellationToken cancellationToken = default)
        {
            var programFilter = educationProgramKeys is null || educationProgramKeys.Count == 0
                ? " and (ПрограммаОбучения_Key ne guid'00000000-0000-0000-0000-000000000000')"
                : " and (" + String.Join(" or ", educationProgramKeys.Select(x => GetItemFilter("ПрограммаОбучения_Key", x))) + ")";
            
            var groupFilter = groupKeys is null || groupKeys.Count == 0
                ? ""
                : " and (" + String.Join(" or ", groupKeys.Select(x=>GetItemFilter("ГруппаСлушателя_Key", x))) + ")";
            
            var subGroupFilter = subGroupKeys is null || subGroupKeys.Count == 0
                ? ""
                : " and (" + String.Join(" or ", subGroupKeys.Select(x=>GetItemFilter("ПодгруппаСлушателя_Key", x))) + ")";
            
            var topFilter = top is null
                ? ""
                : $"&$top={top}";
            
            var skipFilter = skip is null
                ? ""
                : $"&$skip={skip}";

            var isArchivedFilter = isArchivedIncluded is null || isArchivedIncluded.Value == true
                ? ""
                : " and (ПрограммаОбучения/Статус ne 'Архивный')";

            var startDateFilter = "";
            if (startDate != null)
            {
                var date = startDate.Value.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
                startDateFilter = $" and (ГруппаСлушателя/ДатаНачалаОбучения ge datetime'{date}')";
            }
            
            var finishDateFilter = "";
            if (finishDate != null)
            {
                var date = finishDate.Value.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
                finishDateFilter = $" and (ГруппаСлушателя/ДатаокончанияОбучения le datetime'{date}')";
            }
            
            var requestStringTemplate =
                "?$format=json" +
                "&$expand=ПрограммаОбучения,Слушатель,ГруппаСлушателя,ПодгруппаСлушателя" +
                "&$select=ПрограммаОбучения/Ref_Key," +
                "ПрограммаОбучения/Description," +
                "ПрограммаОбучения/ФормаОбучения_Key," +
                "Слушатель/Ref_Key," +
                "Слушатель/ФизЛицо_Key," +
                "Слушатель/Description," +
                "ГруппаСлушателя/Ref_Key," +
                "ГруппаСлушателя/Description," +
                "ГруппаСлушателя/ДатаНачалаОбучения," +
                "ГруппаСлушателя/ДатаокончанияОбучения," +
                "ПодгруппаСлушателя/Ref_Key," +
                "ПодгруппаСлушателя/Description" +
                "&$filter=(DeletionMark eq false)" +
                " and (ГрупповойДоговор eq false)" +
                isArchivedFilter + 
                startDateFilter +
                finishDateFilter +
                programFilter + groupFilter + subGroupFilter + topFilter + skipFilter;
            
            var result = await GetByQuery<StudentEducationInfoSlim>(requestStringTemplate, cancellationToken);

            return result;

            string GetItemFilter(string field, Guid programKey) => $"{field} eq guid'{programKey}'";
        }


        public async Task<IEnumerable<StudentEducationInfoSlim>> FilterStudentInfo(string title, CancellationToken cancellationToken = default)
        {
            var requestStringTemplate = "?$format=json" +
                                        "&$expand=ПрограммаОбучения,Слушатель,ГруппаСлушателя,ПодгруппаСлушателя" +
                                        "&$select=ПрограммаОбучения/Ref_Key," +
                                        "ПрограммаОбучения/Description," +
                                        "ПрограммаОбучения/ФормаОбучения_Key," +
                                        "Слушатель/Ref_Key," +
                                        "Слушатель/ФизЛицо_Key," +
                                        "Слушатель/Description," +
                                        "ГруппаСлушателя/Ref_Key," +
                                        "ГруппаСлушателя/Description," +
                                        "ГруппаСлушателя/ДатаНачалаОбучения," +
                                        "ГруппаСлушателя/ДатаокончанияОбучения," +
                                        "ПодгруппаСлушателя/Ref_Key," +
                                        "ПодгруппаСлушателя/Description" +
                                        $"&$filter=(DeletionMark eq false) and (substringof('{title}', Слушатель/Description))";

            var result = await GetByQuery<StudentEducationInfoSlim>(requestStringTemplate, cancellationToken);

            return result;
        }



        private IEnumerable<string> GetQueryStringArray(IEnumerable<Guid> students)
        {
            if (students == null || students.Count() == 0) return new List<string>();

            var array = students.Select(x => GuidToQuery(x));

            return array;


            string GuidToQuery(Guid guid) => $"Слушатели/any(d: d/Слушатель_Key eq guid'{guid.ToString()}')";
        }


        private async Task<IEnumerable<Contract>> GetByStudentsRequest(IEnumerable<string> array)
        {
            var query = "?$filter=" + String.Join(" or ", array) + "&$format=json";
            var result = await GetByQuery(query);
            return result;
        }
    }
}
