using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace lc.fitnesspro.library.Misc
{
    public class SelectQueryGenerator
    {
        public bool IsSelectAvialable => visitor.GetResult.Any();

        SelectQueryVisitor visitor = new SelectQueryVisitor();

        public void AddExpression(Expression expression)
        {
            visitor.Apply(expression);
        }

        public string Build()
        {
            var result = visitor.GetResult;
            return String.IsNullOrEmpty(result) ? String.Empty : "$select=" + result;
        }
    }
}
