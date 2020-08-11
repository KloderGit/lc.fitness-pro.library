using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using lc.fitness_pro.library.Interface;
using lc.fitness_pro.library.Misc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace lc.fitness_pro.library
{
    public class FilteredRepositoryDecorator<T> : IRepository<T>
    {
        IRepository<T> source;

        ICollection<Expression> filterExpression = new List<Expression>();
        ExpressionToParamConverter paramConverter = new ExpressionToParamConverter();


        public IConnection Connection => source.Connection;

        public QueryStringBuilder QueryStringBuilder => source.QueryStringBuilder;


        public FilteredRepositoryDecorator(IRepository<T> repository)
        {
            source = repository;
        }

        public Task<T> GetById(Guid key)
        {
            return source.GetById(key);
        }

        public FilteredRepositoryDecorator<T> Filter(Expression<Func<T, bool>> expression)
        {
            filterExpression.Add(expression);
            return this;
        }

        public async Task<IEnumerable<T>> GetByFilter()
        {
            PerformFilters();
            return await source.GetByFilter();
        }

        public async Task<IEnumerable<T>> GetByQuery(string query)
        {
            return await source.GetByQuery(query);
        }

        private void PerformFilters()
        {
            filterExpression.ToList().ForEach(x => QueryStringBuilder.AddFilter(x));
        }

    }
}
