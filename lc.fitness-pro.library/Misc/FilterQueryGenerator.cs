using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace lc.fitnesspro.library.Misc
{
    public class FilterQueryGenerator
    {
        LinkedList<Expression> expressions = new LinkedList<Expression>();

        ICollection<string> members = new List<string>();
        public bool IsFilterAvialable => members.Any();

        public void AddExpression(Expression expression)
        {
            expressions.AddLast(expression);

            var visitor = new FilterQueryVisitor();

            visitor.Apply(expression);

            var filterString = visitor.GetResult;

            members.Add(filterString);
        }

        public string Build()
        {
            var result = String.Join(" ", members.Where(x => !String.IsNullOrEmpty(x)));
            return String.IsNullOrEmpty(result) ? String.Empty : "$filter=" + result;
        }


        public void AddAnd()
        {
            members.Add("and");
        }

        public void AddOr()
        {
            members.Add("or");
        }
    }
}
