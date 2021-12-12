using MyFinance.DAL;
using MyFinance.BLL.Cards.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.BLL.Cards.Services
{
    public class CardCreateValidator : IValidator<CreateCardDto>
    {
        readonly IFinanceDbContext _db;
        public CardCreateValidator(IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task<Task> Validate(CreateCardDto dto)
        {
            if (dto is null)
            {
                throw new DtoNullReferenceException();
            }

            if (string.IsNullOrWhiteSpace(dto.Id))
            {
                throw new ValueNotSpecifiedException($"Id property not specified");
            }

            var card = await _db.Context.Cards.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (card is not null)
            {
                throw new ValueConflictException($"Specified account Id value {dto.Id} already exists");
            }

            var account = await _db.Context.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.AccountId);
            if (account is null)
            {
                throw new ValueNotFoundException($"Specified account Id value {dto.Id} was not found");
            }

            return Task.CompletedTask;
        }
    }
}
