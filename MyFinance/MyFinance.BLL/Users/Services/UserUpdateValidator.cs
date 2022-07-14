using MyFinance.DAL;
using MyFinance.BLL.Users.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.BLL.Users.Services
{
    public class UserUpdateValidator : IValidator<UpdateUserDto>
    {
        readonly IFinanceDbContext _db;

        public UserUpdateValidator(IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task<Task> Validate(UpdateUserDto dto)
        {
            if (dto is null)
            {
                throw new DataNullReferenceException();
            }

            var user = await _db.Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (user is null)
            {
                throw new ValueNotFoundException($"Specified user {dto.Id} was not found");
            }

            return Task.CompletedTask;
        }
    }
}
