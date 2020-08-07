using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using lc.fitness_pro.library.Extension;
using lc.fitness_pro.library.Interface;
using lc.fitness_pro.library.Model;

namespace lc.fitness_pro.library
{
    public class Repository<T> : IRepository<T>
    {
        IConnection connection;

        public IConnection Connection => connection;
        public QueryStringBuilder QueryStringBuilder { get; private set; } = new QueryStringBuilder();

        public Repository(IConnection connection)
        {
            this.connection = connection;
        }

        public async Task<T> GetById(Guid key)
        {
            QueryStringBuilder.AddParam("key", key.ToString());
            var queryString = QueryStringBuilder.Build();

            var response = await DoGetRequest(queryString);
            var result = await response.Content.ReadAsAsync<T>();

            return result;
        }

        public async Task<IEnumerable<T>> GetByFilter()
        {
            var queryString = QueryStringBuilder.Build();

            var result = await GetByQuery(queryString);

            return result;
        }

        public async Task<IEnumerable<T>> GetByQuery(string queryString)
        {
            var requestResult = await DoGetRequest(queryString);

            var result = await requestResult.Content.ReadAsAsync<ODataResponse<T>>();

            return result.value;
        }

        public FilteredRepositoryDecorator<T> Filter(Expression<Func<T, bool>> expression)
        {
            var decorator = new FilteredRepositoryDecorator<T>(this);
            decorator.Filter(expression);
            return decorator;
        }

        private async Task<HttpResponseMessage> DoGetRequest(string queryString)
        {
            var client = connection.GetClient();
            var uri = connection.GetURI(typeof(T));
            var url = uri + "?" + queryString + "&$format=json";
            var response = await client.GetAsync(url).ConfigureAwait(false);

            return response;
        }
    }
}
