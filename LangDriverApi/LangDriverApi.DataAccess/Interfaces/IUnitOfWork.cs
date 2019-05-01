using System;

namespace LangDriverApi.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        IUserRepository Users { get; }
        IWordRepository Words { get; }
    }
}
