﻿using Newtonsoft.Json;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace lc.fitnesspro.library.Misc
{
    public class FilterQueryVisitor : ExpressionVisitor
    {
        string str = String.Empty;

        public string GetResult => str;

        public Expression Apply(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.AndAlso || node.NodeType == ExpressionType.OrElse)
            {
                Visit(node.Left);
                str += node.NodeType == ExpressionType.AndAlso ? " and " : " or ";
                Visit(node.Right);

                return node;
            }

            if (node.NodeType == ExpressionType.Equal || node.NodeType == ExpressionType.NotEqual ||
                node.NodeType == ExpressionType.GreaterThanOrEqual || node.NodeType == ExpressionType.GreaterThan ||
                node.NodeType == ExpressionType.LessThanOrEqual || node.NodeType == ExpressionType.LessThan)
            {
                if (node.Left.NodeType == ExpressionType.MemberAccess)
                {
                    Visit(node.Left);

                    str += " " + ConvertConditionToOData(node.NodeType) + " ";

                    Visit(node.Right);

                    var result = Expression.Lambda(node.Right).Compile().DynamicInvoke();

                    str += GetValueString(result);
                }

                return node;
            }

            return base.VisitBinary(node);
        }


        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Any")
            {
                if (node.Arguments.Count < 2) throw new ArgumentException("Метод Any() без аргументов не поддерживается");

                var nd = (LambdaExpression)node.Arguments[1];

                if (nd.Body.NodeType == ExpressionType.MemberAccess) throw new ArgumentException("Проверка только по имени поля не поддерживается");

                if (nd.Body.NodeType == ExpressionType.Call)
                {
                    var bd = nd.Body as MethodCallExpression;

                    if (bd.Method.Name == "EndsWith")
                    {
                        str += "endswith(";
                        Visit(node.Arguments.First());
                        str += "/";
                        Visit(node.Arguments[1]);
                        str += ",";

                        var result = Expression.Lambda(bd.Arguments[0]).Compile().DynamicInvoke();
                        str += GetValueString(result);

                        str += ")";
                    }
                    else
                    {
                        throw new ArgumentException("Проверка по произвольному методу не поддерживается");
                    }
                }
                //else if (nd.Body is BinaryExpression)
                //{
                //    throw new ArgumentException("Проверка по составному условию не поддерживается");
                //}
                else
                {
                    Visit(node.Arguments.First());
                    str += "/";
                    Visit(node.Arguments[1]);
                }

                return node;
            }



            return base.VisitMethodCall(node);
        }


        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.NodeType == ExpressionType.MemberAccess)
            {
                if(node.Expression.NodeType == ExpressionType.Parameter)
                {
                    var attributes = node.Member.GetCustomAttributes(false);
                    var jsonAttribute = attributes.FirstOrDefault(x => x.GetType() == typeof(JsonPropertyAttribute)) as JsonPropertyAttribute;

                    str += jsonAttribute.PropertyName;

                    return node;
                }

                //str += "AAAAA";
                return node;
            }

            return base.VisitMember(node);
        }

        private string GetValueString(Object item)
        {
            string val = "";

            switch (item)
            {
                case Guid i:
                    val = $"guid'{i}'";
                    break;
                case String i:
                    val = $"'{i}'";
                    break;
                case DateTime i:
                    //datetime'2020-02-27T00:00:00'
                    val = "datetime" + $"'{i.ToString("yyyy-MM-dd")}" + "T00:00:00'";
                    //val = $"'{i.ToString("dd.MM.yyyy")}'";
                    break;
                case bool i:
                    val = $"{i.ToString().ToLower()}";
                    break;
                default:
                    val = item.ToString();
                    break;
            }

            return val;
        }

        private string ConvertConditionToOData(ExpressionType @enum)
        {
            ODataOperation result;
            try
            {
                var number = (int)@enum;
                result = (ODataOperation)number;
            }
            catch
            {
                throw new ArgumentException("Данное условие или операция не поддерживается");
            }

            return result.ToString();
        }
    }

    public enum ODataOperation
    {
        eq = 13,
        ne = 35,
        gt = 0xF,
        ge = 0x10,
        lt = 20,
        le = 21
    }
}
