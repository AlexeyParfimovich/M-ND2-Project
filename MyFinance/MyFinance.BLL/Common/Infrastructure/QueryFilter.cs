#nullable enable
using System.Collections.Generic;
using MyFinance.BLL.Common.Abstracts;

namespace MyFinance.BLL.Common.Infrastructure
{
    public class QueryFilter: BaseFilterDto
    {
        public List<QueryCondition>? Conditions { set; get; }
    }
}
