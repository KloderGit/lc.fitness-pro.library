using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace lc.fitnesspro.library.Interface
{
    public interface IQuery<T>
    {
        void Prepare();
        void Select(Expression<Func<T, object>> expression);
        void Expand(Expression<Func<T, object>> expression);
        void Filter(Expression<Predicate<T>> expression);
        void And();
        void Or();

        string Build();
        void AndAlso();
        void OrAlso();
        void Clear();
    }
}
