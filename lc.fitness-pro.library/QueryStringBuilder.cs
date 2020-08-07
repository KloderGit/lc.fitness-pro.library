using System;
using System.Collections.Generic;
using System.Linq;

namespace lc.fitness_pro.library
{
    public class QueryStringBuilder
    {
        String queryString = String.Empty;

        Dictionary<string, string> @params = new Dictionary<string, string>();


        public void AddParam(string key, string value)
        {
            @params.Add(key, value);
        }

        public string Build()
        {
            string result = string.Empty;

            var array = @params.Select(x => "$" + x.Key + "=" + x.Value);
            result = string.Join("&", array);

            if (@params.Select(x => x.Key.ToUpper()).Contains("KEY"))
            {
                var key = @params.First(x => x.Key.ToUpper() == "KEY").Value;
                result = $"(guid'{key}')";
                @params.Clear();
            }

            return result;
        }
    }
}
