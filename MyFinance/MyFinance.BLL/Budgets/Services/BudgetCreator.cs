using System.Threading.Tasks;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetCreator : ICreator<CreateBudgetDto, BudgetDto>
    {
        private readonly IFinanceDbContext _db;
        private readonly IValidator<CreateBudgetDto> _validator;

        public BudgetCreator(
            IFinanceDbContext database,
            IValidator<CreateBudgetDto> validator)
        {
            _db = database;
            _validator = validator;
        }

        public async Task<BudgetDto> Create(CreateBudgetDto dto)
        {
            await _validator.Validate(dto);
            var entity = BudgetMapper.MapToEntityCreate(dto);
            var entry = await _db.Context.Budgets.AddAsync(entity);
            await _db.Context.SaveChangesAsync();

            return BudgetMapper.MapToDto(entry.Entity);
        }
    }
}
