using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using lc.fitnesspro.library.Extension;
using lc.fitnesspro.library.Interface;

namespace lc.fitnesspro.library
{
    public class Connection : IConnection
    {
        private readonly IAccount account;

        public Connection(IAccount account)
        {
            this.account = account;
        }

        public HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(@"http://217.16.28.213");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{account.GetLogin()}:{account.GetPassword()}")));

            return client;
        }

        public string GetURI(Type key)
        {
            return account.GetEndPoint(key);
        }

        public async Task<T> PostAsync<T>(T dto)
        {
            var client = GetClient();
            var url = GetURI(typeof(T));

            var post = await client.PostJsonAsync(url+"?$format=json", dto);

            var result = await post.Content.ReadAsAsync<T>().ConfigureAwait(false);

            return result;
        }
    }

}
