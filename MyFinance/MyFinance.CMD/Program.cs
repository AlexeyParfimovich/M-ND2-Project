using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MyFinance.CMD
{
    class Person
    {
        public string First { set; get; }
        public string Last { set; get; }
        public int Age { set; get; }
    }

    class Filter
    {
        internal string Property { set; get; }
        internal string Operator { set; get; }
        internal object Data { set; get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person() 
            { 
                First = "John",
                Last = "Down",
                Age = 33
            };

            var filters = new Filter[]
            {
                new () {
                    Property = "First",
                    Operator = "eq",
                    Data = "John"
                },
                new () {
                    Property = "Last",
                    Operator = "cs",
                    Data = "ow"
                },
                new () {
                    Property = "Age",
                    Operator = "cs",
                    Data = 16
                },
            };

            //Func<Person, string> lambda = p => p.First;
            ////Expression<Func<Person, string>> expression = p => p.First;
            ////MemberExpression memExp = (MemberExpression)expression.Body;
            ////MemberInfo memInfo = memExp.Member;

            //////var fieldName = memInfo.Name;
            ////var fieldName = GetFieldName<Person, string>(p => p.First);

            ////// A parameter for the lambda expression.
            ////ParameterExpression paramExpr = Expression.Parameter(typeof(int), "p");

            ////// This expression represents a lambda expression
            ////// that adds 1 to the parameter value.
            ////LambdaExpression lambdaExpr = Expression.Lambda(
            ////    Expression.Add(
            ////        paramExpr,
            ////        Expression.Constant(1)
            ////    ),
            ////    new List<ParameterExpression>() { paramExpr }
            ////);

            ////// Print out the expression.
            ////Console.WriteLine(lambdaExpr);
            ////Console.WriteLine(lambdaExpr.Compile().DynamicInvoke(1));



            // entity => entity.PropName == const
            //var propName = "First";
            //var value = "Alex";
            //var itemParameter = Expression.Parameter(typeof(Person), "entity");


            Expression expr = GetFilterExpression<Person>(filters[0]); 
            for(var i=1; i < filters.Length; i++)
            {
                expr = Expression.AndAlso( expr,
                    GetFilterExpression<Person>(filters[i]));
            }

            //var expression = SetExpression<Person>(filters[0]);

            //var query = Repository.GetQuery().Where(PropertyEqual(typeof(Person), "First", "Alex"));

            Console.WriteLine(expr);
            //Console.WriteLine(lambdaExpr.Compile().DynamicInvoke(person));



            Console.ReadKey();
        }

        public static Expression GetFilterExpression<TEntity>(Filter filter)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "p");
            var property = Expression.Property(parameter, filter.Property);
            var data = Expression.Constant(filter.Data);

            switch (filter.Operator.ToLower())
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


        public static LambdaExpression PropertyEqual<TEntity>(string propertyName, object value)
        {
            var itemParameter = Expression.Parameter(typeof(TEntity), "entity");
            return Expression.Lambda
            (
                Expression.Equal
                (
                    Expression.Property
                    (
                        itemParameter,
                        propertyName
                    ),
                    Expression.Constant(value)
                ),
                new[] { itemParameter }
            );
        }

        public static string GetFieldName<TSource, TResult>(Expression<Func<TSource, TResult>> expression)
        {
            return ((MemberExpression)expression.Body).Member.Name;
        }
    }
}
