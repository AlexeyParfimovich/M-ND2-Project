using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Users.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Users.Services
{
    public class UserFetcher : BaseFetchService<UserEntity, FetchUserDto>, IFetcher<UserEntity, FetchUserDto>
    {
        public UserFetcher(
            IFinanceDbContext database) : base(database)
        {}
    }
}
