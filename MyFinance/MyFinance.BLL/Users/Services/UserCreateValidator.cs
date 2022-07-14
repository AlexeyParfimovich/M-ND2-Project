using MyFinance.DAL;
using MyFinance.BLL.Users.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.BLL.Users.Services
{
    public class UserCreateValidator : IValidator<CreateUserDto>
    {
        readonly IFinanceDbContext _db;
        public UserCreateValidator(IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task<Task> Validate(CreateUserDto dto)
        {
            if (dto is null)
            {
                throw new DataNullReferenceException();
            }

            if (string.IsNullOrWhiteSpace(dto.UserName))
            {
                throw new ValueNotSpecifiedException($"UserName property not specified");
            }

            var user = await _db.Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == dto.UserName);
            if (user is not null)
            {
                throw new ValueConflictException($"Specified User Name value {dto.UserName} already exists");
            }

            return Task.CompletedTask;
        }
    }
}
