using SignalRAssignment_SE151127.DataAccess;
using SignalRAssignment_SE151127.Models;
using SignalRAssignment_SE151127.Repositories;
using System;

namespace SignalRAssignment_SE151127.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        IUserRepository _userRepository;
        ICategoryRepository _categoryRepository;
        IPostRepository _postRepository;

        private ApplicationDBContext _db;

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            _userRepository = new UserRepository(new UserDAO(_db));
            _categoryRepository = new CategoryRepository(new CategoryDAO(_db));
            _postRepository = new PostRepository(new PostDAO(_db));
        }

        public IUserRepository UserRepository => _userRepository;
        public IPostRepository PostRepository => _postRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository;
        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
