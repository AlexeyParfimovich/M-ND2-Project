using System.Collections.Generic;
using MyFinance.BLL.Common.Abstracts;
using Newtonsoft.Json;

namespace MyFinance.BLL.Common.Infrastructure
{
    public class QueryFilter : BaseFilterDto
    {
        public List<QueryCondition> Conditions { set; get; }

        public ConditionOperator Operator { set; get; } = ConditionOperator.AndAlso;

        public QueryFilter()
        {
            Conditions = new List<QueryCondition>();
        }

        public QueryFilter AddCondition(string property, object data, string operation = "")
        {
            Conditions?.Add(new QueryCondition
            {
                Property = property,
                Operator = operation,
                Data = data
            });

            return this;
        }

        public QueryFilter AddConditions(string property, object[] data, string operation = "")
        {
            foreach(var item in data)
                Conditions?.Add(new QueryCondition
                {
                    Property = property,
                    Operator = operation,
                    Data = item
                });

            return this;
        }

        public QueryFilter RemoveCondition(string property)
        {
            Conditions.RemoveAll(c => c.Property == property);
            return this;
        }

        public QueryCondition GetCondition(string property)
        {
            return Conditions.Find(c => c.Property == property);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(Conditions);
        }
    }
}
