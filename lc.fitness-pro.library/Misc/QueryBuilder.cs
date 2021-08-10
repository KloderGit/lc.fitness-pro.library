using lc.fitnesspro.library.Interface;
using System;
using System.Linq.Expressions;

namespace lc.fitnesspro.library.Misc
{
    public class QueryBuilder<T> : IQuery<T>
    {
        private SelectQueryGenerator selectQueryGenerator = new SelectQueryGenerator();
        private ExpandQueryGenerator expandQueryGenerator = new ExpandQueryGenerator();
        private FilterQueryGenerator filterQueryGenerator = new FilterQueryGenerator();

        public void Filter(Expression<Predicate<T>> expression) => filterQueryGenerator.AddExpression(expression);

        public void And() => filterQueryGenerator.AddAnd();

        public void Or() => filterQueryGenerator.AddOr();

        public void AndAlso() => filterQueryGenerator.AndAlso();

        public void OrAlso() => filterQueryGenerator.OrAlso();

        public void Select(Expression<Func<T, object>> expression) => selectQueryGenerator.AddExpression(expression);

        public void Expand(Expression<Func<T, object>> expression) => expandQueryGenerator.AddExpression(expression);

        public string Build()
        {
            var jsonParam = "?$format=json";

            var result = jsonParam;

            if (filterQueryGenerator.IsFilterAvialable) result += "&" + filterQueryGenerator.Build();
            if (expandQueryGenerator.IsExpandAvialable) result += "&" + expandQueryGenerator.Build();
            if (selectQueryGenerator.IsSelectAvialable) result += "&" + selectQueryGenerator.Build();

            return result;
        }

        public void Clear()
        {
            selectQueryGenerator = new SelectQueryGenerator();
            expandQueryGenerator = new ExpandQueryGenerator();
            filterQueryGenerator = new FilterQueryGenerator();
        }
    }
}
