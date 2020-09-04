using lc.fitnesspro.library.Interface;
using System;
using System.Linq.Expressions;

namespace lc.fitnesspro.library.Misc
{
    public class QueryBuilder<T> : IQuery<T>
    {
        private readonly SelectQueryGenerator selectQueryGenerator = new SelectQueryGenerator();
        private readonly ExpandQueryGenerator expandQueryGenerator = new ExpandQueryGenerator();
        private readonly FilterQueryGenerator filterQueryGenerator = new FilterQueryGenerator();

        string queryString = "?$format=json";



        public IQuery<T> Filter(Expression<Predicate<T>> expression)
        {
            filterQueryGenerator.AddExpression(expression);
            return this;
        }

        public IQuery<T> And()
        {
            filterQueryGenerator.AddAnd();
            return this;
        }

        public IQuery<T> Or()
        {
            filterQueryGenerator.AddOr();
            return this;
        }

        public IQuery<T> Select(Expression<Func<T, object>> expression)
        {
            selectQueryGenerator.AddExpression(expression);
            return this;
        }

        //public IQuery<T> Expand(Expression<Func<T, object>> expression)
        //{
        //    expandQueryGenerator.AddExpression(expression);
        //    return this;
        //}

        public IQuery<T> Expand(Expression<Func<IContractExpandField, object>> expression)
        {
            expandQueryGenerator.AddExpression(expression);
            return this;
        }

        public string Build()
        {
            if (filterQueryGenerator.IsFilterAvialable) queryString += "&" + filterQueryGenerator.Build();
            if (expandQueryGenerator.IsExpandAvialable) queryString += "&" + expandQueryGenerator.Build();
            if (selectQueryGenerator.IsSelectAvialable) queryString += "&" + selectQueryGenerator.Build();

            return queryString;
        }
    }
}
