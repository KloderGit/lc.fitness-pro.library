using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace lc.fitnesspro.library.Interface
{
    public interface ISelect<T>
    {
        IRepository<T> Select(Expression<Func<T, bool>> expression);
    }
}
