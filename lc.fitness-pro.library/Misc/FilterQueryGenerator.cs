using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace lc.fitnesspro.library.Misc
{
    public class FilterQueryGenerator
    {
        Tree tree = new Tree();
        Tree currentNode;

        public FilterQueryGenerator()
        {
            currentNode = tree;
        }

        public bool IsFilterAvialable => currentNode.NodeExpression.Any();

        public void AddExpression(Expression expression)
        {
            currentNode.NodeExpression.AddLast(new ReduceExpressionInfo { NodeType = NodeType.Expression, Expression = expression });
        }
        public void AddAnd()
        {
            currentNode.NodeExpression.AddLast(new ReduceExpressionInfo { NodeType = NodeType.And });
        }

        public void AddOr()
        {
            currentNode.NodeExpression.AddLast(new ReduceExpressionInfo { NodeType = NodeType.Or });
        }


        public void AndAlso()
        {
            currentNode.Child = new Tree() { JoinType = "and" };
            currentNode = currentNode.Child;
        }

        public void OrAlso()
        {
            currentNode.Child = new Tree() { JoinType = "or" };
            currentNode = currentNode.Child;
        }

        public void Return()
        {
            currentNode = tree;
        }


        public string Build()
        {
            var result = "$filter=" + RecursiveBuild(tree);

            return result;
        }


        private string RecursiveBuild(Tree node)
        {
            var visitor = new FilterQueryVisitor();
            var resultExpression = BuildExpression(node.NodeExpression);
            visitor.Apply(resultExpression);

            if(node.Child == null) return visitor.GetResult;

            var child = RecursiveBuild(node.Child);

            var filterString = "(" + visitor.GetResult + ")" + $" {node.Child.JoinType} " + $"({child})";

            return filterString;
        }



        private Expression BuildExpression(LinkedList<ReduceExpressionInfo> reduceExpressions)
        {
            Expression newExpression = reduceExpressions.First.Value.Expression;

            for (var node = reduceExpressions.First; node != null; node = node.Next)
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

            return newExpression;
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
