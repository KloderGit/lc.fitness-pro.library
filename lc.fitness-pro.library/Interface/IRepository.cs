using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lc.fitness_pro.library.Interface
{
    public interface IRepository<T>
    {
        IConnection Connection { get; }
        QueryStringBuilder QueryStringBuilder { get; }

        Task<T> GetById(Guid key);
        Task<IEnumerable<T>> GetByFilter();
        Task<IEnumerable<T>> GetByQuery(string query);
    }
}
