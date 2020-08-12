using System;
using System.Collections.Generic;
using System.Linq;
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
