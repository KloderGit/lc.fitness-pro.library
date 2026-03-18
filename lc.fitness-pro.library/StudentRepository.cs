using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;

namespace lc.fitnesspro.library
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(IConnection connection)
            : base(connection)
        { }


        public async Task<IEnumerable<StudentEducationInfoSlim>> FilterStudentsInfo(FilterStudentInfoRequest request, CancellationToken cancellationToken = default)
        {
            var programFilter = request.EducationProgramKeys.Count == 0
                ? " and (ПрограммаОбучения_Key ne '00000000-0000-0000-0000-000000000000')"
                : " and (" + String.Join(" or ", request.EducationProgramKeys.Select(x => GetItemFilter("ПрограммаОбучения_Key", x))) + ")";
            
            var groupFilter = request.GroupKeys.Count == 0
                ? " and (ГруппаСлушателя_Key ne '00000000-0000-0000-0000-000000000000')"
                : " and (" + String.Join(" or ", request.GroupKeys.Select(x=>GetItemFilter("ГруппаСлушателя_Key", x))) + ")";
            
            var subGroupFilter = request.SubGroupKeys.Count == 0
                ? ""
                : " and (" + String.Join(" or ", request.SubGroupKeys.Select(x=>GetItemFilter("ПодгруппаСлушателя_Key", x))) + ")";
            
            var topFilter = request.Top is null
                ? ""
                : $"&$top={request.Top}";
            
            var skipFilter = request.Skip is null
                ? ""
                : $"&$skip={request.Skip}";
            
            var requestStringTemplate =
                "$format=json" +
                "&$expand=ПрограммаОбучения,Слушатель,ГруппаСлушателя,ПодгруппаСлушателя" +
                "&$select=ПрограммаОбучения/Ref_Key," +
                "ПрограммаОбучения/Description," +
                "Слушатель/Ref_Key," +
                "Слушатель/Description," +
                "ГруппаСлушателя/Ref_Key," +
                "ГруппаСлушателя/Description," +
                "ПодгруппаСлушателя/Ref_Key," +
                "ПодгруппаСлушателя/Description" +
                "&$filter=(DeletionMark eq false)" +
                " and (ГрупповойДоговор eq false)"
                + programFilter + groupFilter + subGroupFilter + topFilter + skipFilter;
            ;
            
            var result = await GetByQuery<StudentEducationInfoSlim>(requestStringTemplate, cancellationToken);

            return result;

            string GetItemFilter(string field, Guid programKey) => $"{field} eq '{programKey}'";
        }

        
        public class FilterStudentInfoRequest
        {
            public List<Guid> EducationProgramKeys { get; set; } = new List<Guid>();
            public List<Guid> GroupKeys { get; set; } = new List<Guid>();
            public List<Guid> SubGroupKeys { get; set; } = new List<Guid>();
            public int? Top { get; set; }
            public int? Skip { get; set; }
        }

    }
}
