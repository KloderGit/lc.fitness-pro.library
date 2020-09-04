using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace lc.fitnesspro.library.Misc
{
    public class FilterQueryVisitor : ExpressionVisitor
    {
        string str = String.Empty;

        public Expression Apply(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.AndAlso || node.NodeType == ExpressionType.OrElse)
            {
                str += "(";
                Visit(node.Left);
                str += node.NodeType == ExpressionType.AndAlso ? " and " : " or ";
                Visit(node.Right);
                str += ")";

                return node;
            }

            if (node.NodeType == ExpressionType.Equal)
            {
                //str += "(";
                Visit(node.Left);
                str += " eq ";
                Visit(node.Right);
                //str += ")";

                return node;
            }

            if (node.NodeType == ExpressionType.NotEqual)
            {
                //str += "(";
                Visit(node.Left);
                str += " ne ";
                Visit(node.Right);
                //str += ")";

                return node;
            }

            return base.VisitBinary(node);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.NodeType == ExpressionType.MemberAccess)
            {
                var attributes = node.Member.GetCustomAttributes(false);
                var jsonAttribute = attributes.FirstOrDefault(x => x.GetType() == typeof(JsonPropertyAttribute)) as JsonPropertyAttribute;

                str += jsonAttribute?.PropertyName;

                return node;
            }

            return base.VisitMember(node);
        }

        protected override Expression VisitInvocation(InvocationExpression p)
        {

            return p;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var compiled = Expression.Lambda(node).Compile();
            var sf = compiled.DynamicInvoke();

            str += sf;

            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            //var compiled = Expression.Lambda(node).Compile();
            //var sf = compiled.DynamicInvoke();
            

            if (node.Type.Name.Contains("DisplayClass0_0")) throw new ArgumentException();            // Except closures (-!!!-)

            if (node.NodeType == ExpressionType.Constant)
            {
                var value = node.Value;

                if (Guid.TryParse(value.ToString(), out var guid)) 
                {
                    str += $"guid'{value}'";
                    return node;
                }
                
                switch (value)
                {
                    case string intValue:
                        str += $"'{node.Value}'";
                        break;
                    case DateTime intValue:
                        str += $"'{node.Value}'";
                        break;
                    default:
                        str += node.Value.ToString();
                        break;
                }

                return node;
            }

            return base.VisitConstant(node);
        }

        public string GetResult => str;
    }
}
