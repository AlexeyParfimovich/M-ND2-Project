using System;

namespace MyFinance.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        void Save();

        void SaveAsync();
    }
}
