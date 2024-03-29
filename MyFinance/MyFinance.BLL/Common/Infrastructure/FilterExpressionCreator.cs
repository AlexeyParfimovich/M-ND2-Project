﻿using System;
using System.Linq.Expressions;

namespace MyFinance.BLL.Common.Infrastructure
{
    public static class FilterExpressionCreator
    {
        public static Expression GetConditionsExpression(QueryFilter filter, ParameterExpression parameter)
        {
            Expression expr = null;
               
            foreach(var condition in filter.Conditions)
            {
                if(expr is null)
                {
                    expr = GetExpression(condition, parameter);
                }
                else
                {
                    switch (filter.Operator)
                    {
                        case ConditionOperator.AndAlso:
                            expr = Expression.AndAlso(expr, GetExpression(condition, parameter));
                            break;
                        case ConditionOperator.OrElse:
                            expr = Expression.OrElse(expr, GetExpression(condition, parameter));
                            break;
                    }
                }
            }

            return expr;
        }

        public static Expression GetExpression(QueryCondition condition, ParameterExpression parameter)
        {
            if (condition.Data is null)
                return null;

            var property = Expression.Property(parameter, condition.Property);
            var data = condition.Data is null 
                ? Expression.Constant(condition.Data, property.Type) 
                : Expression.Constant(condition.Data);

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
                //case "in":
                //    CheckPropertyIsString(property);
                //    return Expression.Call(data, typeof(string).GetMethod("Contains", new[] { typeof(string) }), property);
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
