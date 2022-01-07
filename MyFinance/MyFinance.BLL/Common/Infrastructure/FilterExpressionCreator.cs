using System;
using System.Linq.Expressions;

namespace MyFinance.BLL.Common.Infrastructure
{
    public static class FilterExpressionCreator
    {

        public static Expression GetConditionsExpression(QueryCondition[] conditions, ParameterExpression parameter)
        {
            Expression expr = GetExpression(conditions[0], parameter);
            for (var i = 1; i < conditions.Length; i++)
            {
                expr = Expression.AndAlso(expr,
                    GetExpression(conditions[i], parameter));
            }

            return expr;
        }

        public static Expression GetExpression(QueryCondition condition, ParameterExpression parameter)
        {
            var property = Expression.Property(parameter, condition.Property);
            var data = Expression.Constant(condition.Data);

            switch (condition.Operator.ToLower())
            {
                case "":
                case "eq":
                    return Expression.Equal(property, data);
                case "neq":
                    return Expression.NotEqual(property, data);
                case "gt":
                    CheckPropertyIsNotString(property);
                    return Expression.GreaterThan(property, data);
                case "gte":
                    CheckPropertyIsNotString(property);
                    return Expression.GreaterThanOrEqual(property, data);
                case "lt":
                    CheckPropertyIsNotString(property);
                    return Expression.LessThan(property, data);
                case "lte":
                    CheckPropertyIsNotString(property);
                    return Expression.LessThanOrEqual(property, data);
                case "cs":
                    CheckPropertyIsString(property);
                    return Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) }), data);
                case "sw":
                    CheckPropertyIsString(property);
                    return Expression.Call(property, typeof(string).GetMethod("StartsWith", new[] { typeof(string) }), data);
                case "ew":
                    CheckPropertyIsString(property);
                    return Expression.Call(property, typeof(string).GetMethod("EndsWith", new[] { typeof(string) }), data);

                default: return null;
            }
        }

        public static void CheckPropertyIsString(MemberExpression property)
        {
            if (property.Type != typeof(string))
                throw new ArgumentException($"Property {property.Member.Name} must be a string");
        }
        public static void CheckPropertyIsNotString(MemberExpression property)
        {
            if (property.Type == typeof(string))
                throw new ArgumentException($"Property {property.Member.Name} must not be a string");
        }
    }
}
