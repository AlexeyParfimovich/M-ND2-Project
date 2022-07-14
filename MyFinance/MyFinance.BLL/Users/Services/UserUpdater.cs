using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Users.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Users.Services
{
    public class UserUpdater : BaseUpdateService<UserEntity, FetchUserDto, UpdateUserDto>, IUpdater<UserEntity, FetchUserDto, UpdateUserDto>
    {
        public UserUpdater(
             IFinanceDbContext database,
             IValidator<UpdateUserDto> validator) : base(database, validator)
        {
        }
    }
}
