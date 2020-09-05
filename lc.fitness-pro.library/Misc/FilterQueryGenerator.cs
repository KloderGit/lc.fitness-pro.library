using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace lc.fitnesspro.library.Misc
{
    public class FilterQueryGenerator
    {
        LinkedList<ReduceExpressionInfo> reduceInfo = new LinkedList<ReduceExpressionInfo>();

        public bool IsFilterAvialable => reduceInfo.Any();

        public void AddExpression(Expression expression)
        {
            reduceInfo.AddLast(new ReduceExpressionInfo { NodeType = NodeType.Expression, Expression = expression });
        }
        public void AddAnd()
        {
            reduceInfo.AddLast(new ReduceExpressionInfo { NodeType = NodeType.And });
        }

        public void AddOr()
        {
            reduceInfo.AddLast(new ReduceExpressionInfo { NodeType = NodeType.Or });
        }

        public string Build()
        {
            Expression newExpression = reduceInfo.First.Value.Expression;

            for (var node = reduceInfo.First; node != null; node = node.Next)
            {
                if (node.Value.NodeType == NodeType.And)
                {
                    var leftExpression = newExpression is LambdaExpression ? ((LambdaExpression)newExpression).Body : newExpression;
                    var nextExpression = node.Next.Value.Expression;
                    var rightExpression = nextExpression is LambdaExpression ? ((LambdaExpression)nextExpression).Body : nextExpression;

                    newExpression = Expression.AndAlso(leftExpression, rightExpression);
                }
                if (node.Value.NodeType == NodeType.Or)
                {
                    var leftExpression = newExpression is LambdaExpression ? ((LambdaExpression)newExpression).Body : newExpression;
                    var nextExpression = node.Next.Value.Expression;
                    var rightExpression = nextExpression is LambdaExpression ? ((LambdaExpression)nextExpression).Body : nextExpression;

                    newExpression = Expression.OrElse(leftExpression, rightExpression);
                }
            }

            var visitor = new FilterQueryVisitor();

            visitor.Apply(newExpression);

            var filterString = visitor.GetResult;

            return filterString;
        }
    }

    class ReduceExpressionInfo
    { 
        public NodeType NodeType { get; set; }
        public Expression Expression { get; set; }
    }

    enum NodeType
    { 
        Expression,
        And,
        Or
    }
}
