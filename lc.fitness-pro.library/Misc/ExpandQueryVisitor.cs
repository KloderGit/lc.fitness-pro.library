using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace lc.fitnesspro.library.Misc
{
    public class ExpandQueryVisitor : ExpressionVisitor
    {
        ICollection<string> fieldsName = new List<string>();

        public Expression Apply(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            var title = GetParamTitle(node);
            fieldsName.Add(title);

            return node;
        }

        private string GetParamTitle(MemberExpression item)
        {
            var attributes = item.Member.GetCustomAttributes(false);
            var jsonAttribute = attributes.FirstOrDefault(x => x.GetType() == typeof(CanExpandAttribute)) as CanExpandAttribute;
            return jsonAttribute == null ? String.Empty : jsonAttribute.FieldTitle;
        }

        public string GetResult => fieldsName.Any()
            ? String.Join(",", fieldsName.Where(x => String.IsNullOrEmpty(x) == false))
            : String.Empty;
    }
}
