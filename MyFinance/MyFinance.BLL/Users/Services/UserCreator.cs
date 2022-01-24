using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Users.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Users.Services
{
    public class UserCreator : BaseCreateService<UserEntity, FetchUserDto, CreateUserDto>, ICreator<UserEntity, FetchUserDto, CreateUserDto>
    {
        public UserCreator(
            IFinanceDbContext database,
            IValidator<CreateUserDto> validator) : base(database, validator)
        {
        }
    }
}
