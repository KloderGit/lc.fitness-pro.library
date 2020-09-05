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

        private string queryString = "?$format=json";

        public void Filter(Expression<Predicate<T>> expression) => filterQueryGenerator.AddExpression(expression);

        public void And() => filterQueryGenerator.AddAnd();

        public void Or() => filterQueryGenerator.AddOr();        

        public void Select(Expression<Func<T, object>> expression) => selectQueryGenerator.AddExpression(expression);
        
        public void Expand(Expression<Func<T, object>> expression) => expandQueryGenerator.AddExpression(expression);

        public string Build()
        {
            if (filterQueryGenerator.IsFilterAvialable) queryString += "&" + filterQueryGenerator.Build();
            if (expandQueryGenerator.IsExpandAvialable) queryString += "&" + expandQueryGenerator.Build();
            if (selectQueryGenerator.IsSelectAvialable) queryString += "&" + selectQueryGenerator.Build();

            return queryString;
        }
    }
}
