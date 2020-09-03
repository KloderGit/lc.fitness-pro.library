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
        private IConnection connection;

        private SelectQueryGenerator selectQueryGenerator = new SelectQueryGenerator();
        private ExpandQueryGenerator expandQueryGenerator = new ExpandQueryGenerator();

        private QueryStringBuilder queryStringBuilder = new QueryStringBuilder();

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

        public async Task<IEnumerable<T>> GetByFilter()
        {
            var queryString = queryStringBuilder.Build();

            if(selectQueryGenerator.IsSelectAvialable) queryString += "&" + selectQueryGenerator.Build();

            if (expandQueryGenerator.IsExpandAvialable) queryString += "&" + expandQueryGenerator.Build();


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

            return result.value;
        }

        public IRepository<T> Filter(Expression<Func<T, bool>> expression)
        {
            queryStringBuilder.AddFilter(expression);
            return this;
        }

        public IRepository<T> Select(Expression<Func<T,bool>> expression)
        {
            selectQueryGenerator.AddExpression(expression);
            return this;
        }

        private async Task<HttpResponseMessage> DoGetRequest(string queryString)
        {
            var client = connection.GetClient();
            var uri = connection.GetURI(typeof(T));
            var url = uri + queryString;
            var response = await client.GetAsync(url).ConfigureAwait(false);

            //var asString = await response.Content.ReadAsStringAsync();

            return response;
        }

        public IRepository<T> Expand(Expression<Func<T, bool>> expression)
        {
            expandQueryGenerator.AddExpression(expression);
            return this;
        }
    }
}
