using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace lc.fitness_pro.library.Interface
{
    public interface IConnection
    {
        HttpClient GetClient();
        string GetURI(Type key);

        //Task<T> GetAsync<T>(string url);
        //Task<T> PostAsync<T>(T dto);
    }
}
