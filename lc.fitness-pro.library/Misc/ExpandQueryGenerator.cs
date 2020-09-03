using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace lc.fitnesspro.library.Misc
{
    public class ExpandQueryGenerator
    {
        ICollection<MemberExpression> members = new List<MemberExpression>();
        public bool IsExpandAvialable => members.Any();

        public void AddExpression(Expression expression)
        {
            if (IsBinaryExpression(expression) == false) throw new ArgumentException("This expression format is not avialable");

            var body = ((LambdaExpression)expression).Body as BinaryExpression;

            var member = (MemberExpression)body.Left;

            members.Add(member);
        }

        public string Build()
        {
            var result = String.Join(",", members.Select(x => GetParamTitle(x)).Where(x => !String.IsNullOrEmpty(x)));
            return String.IsNullOrEmpty(result) ? String.Empty : "$expand=" + result;
        }

        private bool IsBinaryExpression(Expression expression)
        {
            if (expression.NodeType != ExpressionType.Lambda) return false;
            if (((LambdaExpression)expression).Body is BinaryExpression != true) return false;
            return true;
        }

        private string GetParamTitle(MemberExpression item)
        {
            var attributes = item.Member.GetCustomAttributes(false);
            var jsonAttribute = attributes.FirstOrDefault(x => x.GetType() == typeof(CanExpandAttribute)) as CanExpandAttribute;
            return jsonAttribute == null ? String.Empty : jsonAttribute.FieldTitle;
        }
    }
}
