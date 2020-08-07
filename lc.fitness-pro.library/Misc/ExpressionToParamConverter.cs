using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;

namespace lc.fitness_pro.library.Misc
{
    public class ExpressionToParamConverter
    {
        public (string, string, string) Convert(Expression expression)
        {
            if (expression.NodeType != ExpressionType.Lambda) throw new ArgumentException("Такой вид функции не поддерживается");

            var lambda = (LambdaExpression)expression;

            var functionBody = (BinaryExpression)lambda.Body;

            var leftOperand = (MemberExpression)functionBody.Left;
            var rightOperand = Expression.Lambda(functionBody.Right).Compile().DynamicInvoke();


            var result = (GetParamTitle(leftOperand),
                          ConvertConditionToOData(functionBody.NodeType),
                          GetValueByType(leftOperand, rightOperand));

            return result;
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

        private string GetParamTitle(MemberExpression item)
        {
            var attribute = item.Member.GetCustomAttributes(false).First() as JsonPropertyAttribute;
            return attribute.PropertyName;
        }

        private string GetValueByType(MemberExpression item, object rightOperand)
        {
            var property = (PropertyInfo)item.Member;
            var type = property.PropertyType;

            var value = "'" + rightOperand.ToString() + "'";
            if (type == typeof(Guid)) value = $"guid'{rightOperand}'";
            if (type == typeof(bool) || type == typeof(int)) value = rightOperand.ToString();

            return value;
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
