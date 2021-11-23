using MyFinance.DAL.Interfaces;
using MyFinance.DAL.Repositories;
using System;

namespace MyFinance.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        private UserRepository _userRepository;

        private bool disposed = false;

        public UnitOfWork(AppDbContext context)
        {
            this._db = context;
        }

        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_db);
                return _userRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void SaveAsync()
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
