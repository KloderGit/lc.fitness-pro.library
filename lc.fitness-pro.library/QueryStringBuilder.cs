using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using lc.fitnesspro.library.Misc;

namespace lc.fitnesspro.library
{
    public class QueryStringBuilder
    {
        String queryString = String.Empty;
        string toJson = "$format=json";
        string key = String.Empty;
        ICollection<(string Title, string Condition, string Value)> filters = new List<(string Title, string Condition, string Value)>();

        ExpressionToParamConverter paramConverter = new ExpressionToParamConverter();

        public void AddKey(Guid guid)
        {
            key = $"(guid'{guid}')";
        }

        public void AddFilter(Expression expression)
        {
            var convertedExpression = paramConverter.Convert(expression);

            filters.Add(convertedExpression);
        }

        public string Build()
        {
            var filters = GetFilterString();

            queryString = String.IsNullOrEmpty(key) ? "?" + filters + "&" + toJson : key + "?" + toJson;

            return queryString;
        }

        private string GetFilterString()
        {
            if (filters.Any() != true) return String.Empty;

            string filterString = "$filter=";
            var stringPairs = filters.Select(x => x.Title + " " + x.Condition + " " + x.Value);
            filterString += String.Join(" and ", stringPairs);

            return filterString;
        }
    }
}
