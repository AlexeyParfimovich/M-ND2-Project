using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Users.Services
{
    public class UserRemover : BaseRemoveService<UserEntity>, IRemover<UserEntity>
    {
        public UserRemover(IFinanceDbContext database): base(database)
        {
        }
    }
}
