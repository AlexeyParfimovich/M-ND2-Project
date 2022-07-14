namespace MyFinance.BLL.Common.Infrastructure
{
    public enum ConditionOperator
    {
        AndAlso,
        OrElse
    }

    public class QueryCondition
    {
        public string Property { set; get; }
        public string Operator { set; get; }
        public object Data { set; get; }
    }
}
