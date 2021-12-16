using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using Newtonsoft.Json;
using System;

namespace MyFinance.BLL.Common.Services
{
    public class ContractMapper: IContractMapper
    {
        public TDest Map<TSource, TDest>(TSource source)
        {
            try
            {
                return JsonConvert.DeserializeObject<TDest>(
                    JsonConvert.SerializeObject(source));
            }
            catch (Exception ex)
            {
                throw new DataNotMappedException($"Error mapping {typeof(TSource).Name} to {typeof(TDest).Name}", ex);
            }
        }
    }
}
