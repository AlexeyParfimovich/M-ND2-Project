using MyFinance.DAL.Entities;

namespace MyFinance.DAL.Interfaces
{
    public interface IUserRepository: IBaseRepository<UserEntity, long>
    {
        /*
         * Implement methods specific for User
         * 
         */
    }
}
