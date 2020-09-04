using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace lc.fitnesspro.library.Interface
{
    public interface IRepository<T>
    {
       // Task<T> GetById(Guid key);
        Task<IEnumerable<T>> GetByFilter();
        Task<IEnumerable<T>> GetByQuery(string query);

        IQuery<T> Query { get; }
    }
}
