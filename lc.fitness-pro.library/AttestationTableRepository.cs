using lc.fitnesspro.library.Extension;
using lc.fitnesspro.library.Interface;
using lc.fitnesspro.library.Model;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace lc.fitnesspro.library
{
    public class AttestationTableRepository : Repository<AttestationTable>
    {
        public AttestationTableRepository(IConnection connection)
            : base(connection)
        { }

        public async Task<AttestationTable> Create(AttestationTable model)
        {
            if(model.Validate() == false) throw new ArgumentException("Ошибка в сохраняемой модели");

            try
            {
                var client = connection.GetClient();
                var url = connection.GetURI(typeof(AttestationTable));

                var response = await client.PostJsonAsync(url + "?$format=json", model);
                response.EnsureSuccessStatusCode();

                var createdModelAsString = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<AttestationTable>(createdModelAsString);

                var signUpUrl = url + "(" + $"guid'{result.Key}'" + ")/Post?PostingModeOperational=false";

                var apply = await client.GetAsync(signUpUrl);
                apply.EnsureSuccessStatusCode();

                return result;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
    }
}