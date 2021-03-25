using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using lc.fitnesspro.library.Extension;
using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Misc;
using lc.fitnesspro.library.Model;

namespace lc.fitnesspro.library
{
    public class Repository<T> : IRepository<T>
    {
        protected IConnection connection;

        IQuery<T> Query { get; } = new QueryBuilder<T>();

        QueryStringBuilder queryStringBuilder = new QueryStringBuilder();


        public Repository(IConnection connection)
        {
            this.connection = connection;
        }

        [Obsolete]
        public async Task<T> GetById(Guid key)
        {
            queryStringBuilder.AddKey(key);
            var queryString = queryStringBuilder.Build();

            var response = await DoGetRequest(queryString);
            var result = await response.Content.ReadAsAsync<T>();

            return result;
        }

        public virtual async Task<IEnumerable<T>> GetByFilter()
        {
            var queryString = Query.Build();

            var result = await GetByQuery(queryString);

            return result;
        }

        public async Task<IEnumerable<T>> GetByQuery(string queryString)
        {
            var result = await GetByQuery<T>(queryString);

            return result;
        }

        public async Task<IEnumerable<TResult>> GetByQuery<TResult>(string queryString)
        {
            var requestResult = await DoGetRequest(queryString);

            var result = await requestResult.Content.ReadAsAsync<ODataResponse<TResult>>();

            Query.Prepare();

            return result.value;
        }

        private async Task<HttpResponseMessage> DoGetRequest(string queryString)
        {
            var client = connection.GetClient();
            var uri = connection.GetURI(typeof(T));
            var url = uri + queryString;
            var response = await client.GetAsync(url).ConfigureAwait(false);

            return response;
        }

        public IRepository<T> Select(Expression<Func<T, object>> expression)
        {
            Query.Select(expression);
            return this;
        }

        public IRepository<T> Expand(Expression<Func<T, object>> expression)
        {
            Query.Expand(expression);
            return this;
        }

        public IRepository<T> Filter(Expression<Predicate<T>> expression)
        {
            Query.Filter(expression);
            return this;
        }

        public IRepository<T> And()
        {
            Query.And();
            return this;
        }

        public IRepository<T> Or()
        {
            Query.Or();
            return this;
        }

        public IRepository<T> AndAlso()
        {
            Query.AndAlso();
            return this;
        }

        public IRepository<T> OrAlso()
        {
            Query.OrAlso();
            return this;
        }

        public string DebugViewQuery()
        {
            return Query.Build();
        }
    }
}
