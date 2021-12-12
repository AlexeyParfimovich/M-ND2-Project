using MyFinance.DAL;
using MyFinance.BLL.Currencies.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.BLL.Currencies.Services
{
    public class CurrencyUpdateValidator : IValidator<UpdateCurrencyDto>
    {
        readonly IFinanceDbContext _db;

        public CurrencyUpdateValidator(IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task<Task> Validate(UpdateCurrencyDto dto)
        {
            if (dto is null)
            {
                throw new DataNullReferenceException();
            }

            var currency = await _db.Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (currency is null)
            {
                throw new ValueNotFoundException($"Specified currency {dto.Id} was not found");
            }

            return Task.CompletedTask;
        }
    }
}
