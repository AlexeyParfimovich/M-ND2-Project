using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System.Threading.Tasks;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountCreator : BaseService, ICreator<CreateAccountDto, AccountDto>
    {
        protected readonly IValidator<CreateAccountDto> _validator;
        public AccountCreator(
            IFinanceDbContext database,
            IValidator<CreateAccountDto> validator)
            : base(database)
        {
            _validator = validator;
        }

        public async Task<AccountDto> Create(CreateAccountDto dto)
        {
            await _validator.Validate(dto);
            var entity = AccountDtoMapper.MapToEntityCreate(dto);
            var entry = await _db.Context.Accounts.AddAsync(entity);
            await _db.Context.SaveChangesAsync();

            return AccountDtoMapper.MapToDto(entry.Entity);
        }
    }
}
