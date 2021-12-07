using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System.Threading.Tasks;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountUpdater : BaseService, IUpdater<UpdateAccountDto, AccountDto>
    {
        protected readonly IValidator<UpdateAccountDto> _validator;

        public AccountUpdater(
            IFinanceDbContext database,
            IValidator<UpdateAccountDto> validator) : base(database)
        {
            _validator = validator;
        }

        public async Task<AccountDto> Update(UpdateAccountDto dto)
        {
            await _validator.Validate(dto);
            var entity = AccountDtoMapper.MapToEntityUpdate(dto);
            var entry = _db.Context.Accounts.Update(entity);
            await _db.Context.SaveChangesAsync();

            return AccountDtoMapper.MapToDto(entry.Entity);
        }
    }
}
