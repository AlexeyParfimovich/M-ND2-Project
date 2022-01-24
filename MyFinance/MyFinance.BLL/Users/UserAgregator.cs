using MyFinance.DAL.Entities;
using MyFinance.BLL.Users.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Users
{
    public class UserAgregator :
        BaseAgregator<UserEntity, FetchUserDto, CreateUserDto, UpdateUserDto>,
        IAgregator<UserEntity, FetchUserDto, CreateUserDto, UpdateUserDto>
    {
        public UserAgregator(
            ICreator<UserEntity, FetchUserDto, CreateUserDto> creator,
            IUpdater<UserEntity, FetchUserDto, UpdateUserDto> updater,
            IFetcher<UserEntity, FetchUserDto> fetcher,
            IRemover<UserEntity> remover) : base(creator, updater, fetcher, remover)
        {
        }
    }
}
