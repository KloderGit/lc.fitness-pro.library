using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using lc.fitnesspro.library.Model;
using Newtonsoft.Json;

namespace lc.fitnesspro.library.Extension
{
    public static class HttpClientExtensions
    {
        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        public static async Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, string uri, Object @object)
        {
            var objToJson = JsonConvert.SerializeObject(@object, serializerSettings);
            var stringContent = new StringContent(objToJson, Encoding.UTF8, "application/json");

            return await client.PostAsync(uri, stringContent).ConfigureAwait(false);
        }

        public static async Task<T> ReadAsAsync<T>(this HttpContent httpContent)
        {
            var response = await httpContent.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<T>(response, serializerSettings);

            return result;
        }
    }
}


