using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace lc.fitnesspro.library.Interface
{
    public interface IQuery<T>
    {        
        IQuery<T> Select(Expression<Func<T, object>> expression);
        //IQuery<T> Expand(Expression<Func<T, object>> expression);
        IQuery<T> Expand(Expression<Func<IContractExpandField, object>> expression);
        IQuery<T> Filter(Expression<Predicate<T>> expression);
        IQuery<T> And();
        IQuery<T> Or();

        string Build();

    }
}
