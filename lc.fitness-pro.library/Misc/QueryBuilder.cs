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

        private string builtString = String.Empty;

        public void Filter(Expression<Predicate<T>> expression) => filterQueryGenerator.AddExpression(expression);

        public void And() => filterQueryGenerator.AddAnd();

        public void Or() => filterQueryGenerator.AddOr();

        public void AndAlso() => filterQueryGenerator.AndAlso();

        public void OrAlso() => filterQueryGenerator.OrAlso();

        public void Select(Expression<Func<T, object>> expression) => selectQueryGenerator.AddExpression(expression);

        public void Expand(Expression<Func<T, object>> expression) => expandQueryGenerator.AddExpression(expression);

        public string Build()
        {
            if (String.IsNullOrEmpty(builtString) == false) return builtString;

            var jsonParam = "?$format=json";

            builtString = jsonParam;

            if (filterQueryGenerator.IsFilterAvialable) builtString += "&" + filterQueryGenerator.Build();
            if (expandQueryGenerator.IsExpandAvialable) builtString += "&" + expandQueryGenerator.Build();
            if (selectQueryGenerator.IsSelectAvialable) builtString += "&" + selectQueryGenerator.Build();

            return builtString;
        }

        public void Clear()
        {
            selectQueryGenerator = new SelectQueryGenerator();
            expandQueryGenerator = new ExpandQueryGenerator();
            filterQueryGenerator = new FilterQueryGenerator();

            builtString = String.Empty;
        }
    }
}
