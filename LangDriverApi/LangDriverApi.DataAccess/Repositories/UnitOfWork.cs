using LangDriverApi.DataAccess.Interfaces;
using System;

namespace LangDriverApi.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LangDriverContext _context;

        public UnitOfWork(LangDriverContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Words = new WordRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #region IUnitOfWork Members

        public IWordRepository Words { get; }

        public IUserRepository Users { get; }

        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }

        #endregion
    }
}
