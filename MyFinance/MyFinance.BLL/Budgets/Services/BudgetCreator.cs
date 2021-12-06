using System.Threading.Tasks;
using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetCreator : BaseService, ICreator<CreateBudgetDto, BudgetDto>
    {
        protected readonly IValidator<CreateBudgetDto> _validator;
        public BudgetCreator(
            IFinanceDbContext database,
            IValidator<CreateBudgetDto> validator)
            : base(database)
        {
            _validator = validator;
        }

        public async Task<BudgetDto> Create(CreateBudgetDto dto)
        {
            await _validator.Validate(dto);
            var entity = BudgetDtoMapper.MapToEntityCreate(dto);
            var entry = await _db.Context.Budgets.AddAsync(entity);
            await _db.Context.SaveChangesAsync();

            return BudgetDtoMapper.MapToDto(entry.Entity);
        }
    }
}
