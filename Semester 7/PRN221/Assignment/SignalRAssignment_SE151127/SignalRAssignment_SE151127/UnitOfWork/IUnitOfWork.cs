using SignalRAssignment_SE151127.Repositories;
using System;

namespace SignalRAssignment_SE151127.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IPostRepository PostRepository { get; }
        void Save();
    }
}
