using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace lc.fitnesspro.library.Interface
{
    public interface IRepository<T>
    {
       // Task<T> GetById(Guid key);
        Task<IEnumerable<T>> GetByFilter(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetByQuery(string query, CancellationToken cancellationToken);
        Task Delete(Guid key);

        IRepository<T> Select(Expression<Func<T, object>> expression);
        IRepository<T> Expand(Expression<Func<T, object>> expression);
        IRepository<T> Filter(Expression<Predicate<T>> expression);
        IRepository<T> And();
        IRepository<T> Or();
        IRepository<T> AndAlso();
        IRepository<T> OrAlso();
        IRepository<T> Top(int? value);
        IRepository<T> Skip(int? value);
        
        dynamic DebugViewQuery();
        void ClearQuery();
        bool IsQueryLengthMoreThen(int length);
        string GetQueryString();
    }
}
