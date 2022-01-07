using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using MyFinance.BLL.Common.Abstracts;

namespace MyFinance.BLL.Common.Infrastructure
{
    public static class ContractsMapper
    {
        public static IEnumerable<TDest> MapEnumarable<TSource, TDest>(IEnumerable<TSource> source)
        {
            try
            {
                return source.Select(item => Map<TSource, TDest>(item));
            }
            catch (Exception ex)
            {
                throw new DataNotMappedException($"Error mapping {typeof(TSource).Name} to {typeof(TDest).Name}", ex);
            }
        }

        public static TDest Map<TSource, TDest>(TSource source)
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

        public static QueryFilter MapQueryFilter<TDto>(BaseFilterDto filter)
        {
            var qFilter = new QueryFilter() { Conditions = new List<QueryCondition>() };

            foreach (var fProp in filter.GetType().GetProperties())
            {
                var fValue = fProp.GetValue(filter);
                if (fValue is null)
                    continue;

                var qProp = qFilter.GetType().GetProperty(fProp.Name);
                if (qProp is not null)
                {
                    qProp.SetValue(qFilter, fValue);
                }
                else
                {
                    var dtoProp = typeof(TDto).GetProperty(fProp.Name);
                    if (dtoProp is null)
                        continue;

                    if (fProp.PropertyType != typeof(string[]))
                        throw new Exception($"Условия '{fProp.Name}' фильтра заданы не корректно: {fValue}");

                    foreach (var v in (string[])fValue)
                    {
                        var p = v.Split(':');

                        if (p is null || p.Length == 0 || p.Length > 2)
                            throw new Exception($"Условия '{fProp.Name}' фильтра заданы не корректно: {fValue}");

                        qFilter.Conditions.Add(new QueryCondition
                        {
                            Property = fProp.Name,
                            Operator = p.Length == 1 ? "" : p[0],
                            Data = p.Length == 1
                                ? Convert.ChangeType(p[0], dtoProp.PropertyType)
                                : Convert.ChangeType(p[1], dtoProp.PropertyType)
                        });
                    }
                }
            }

            return qFilter;
        }
    }
}
