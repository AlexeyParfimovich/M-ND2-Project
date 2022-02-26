using System.Collections.Generic;
using MyFinance.BLL.Common.Abstracts;
using Newtonsoft.Json;

namespace MyFinance.BLL.Common.Infrastructure
{
    public class QueryFilter: BaseFilterDto
    {
        public List<QueryCondition> Conditions { set; get; }

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

        public override string ToString()
        {
            return JsonConvert.SerializeObject(Conditions);
        }
    }
}
