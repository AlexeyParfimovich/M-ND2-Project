using MyFinance.DAL;
using MyFinance.BLL.Currencies.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.BLL.Currencies.Services
{
    public class CurrencyCreateValidator : IValidator<CreateCurrencyDto>
    {
        readonly IFinanceDbContext _db;
        public CurrencyCreateValidator(IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task<Task> Validate(CreateCurrencyDto dto)
        {
            if (dto is null)
            {
                throw new DtoNullReferenceException();
            }

            if (string.IsNullOrWhiteSpace(dto.Id))
            {
                throw new ValueNotSpecifiedException($"Id property not specified");
            }

            var currency = await _db.Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (currency is not null)
            {
                throw new ValueConflictException($"Specified currency Id value {dto.Id} already exists");
            }

            if (dto.ExchangeRate <= 0)
            {
                throw new ValueOutOfRangeException($"Specified Exchange Rate value is out of range");
            }

            return Task.CompletedTask;
        }
    }
}
