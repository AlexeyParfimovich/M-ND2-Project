namespace MyFinance.BLL.Common.Interfaces
{
    public interface IContractMapper
    {
        public TDest Map<TSource, TDest>(TSource source);
    }
}
