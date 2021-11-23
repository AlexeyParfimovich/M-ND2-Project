using MyFinance.DAL.Interfaces;
using MyFinance.DAL.Entities;

namespace MyFinance.DAL.Repositories
{
    public class UserRepository: BaseRepository<UserEntity, long>, IUserRepository //, IBaseRepository<User, long>
    {
        public UserRepository(AppDbContext context)
           : base(context)
        {
        }
    }
}
