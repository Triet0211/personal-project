using System;
using System.Collections.Generic;
using SignalRAssignment_SE151127.Models;

namespace SignalRAssignment_SE151127.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<AppUser> GetAll();
        public AppUser GetById(int id);
        public AppUser GetByEmail(string email);
        public void Register(AppUser user);
        public void Update(AppUser user);
        public void DeleteUser(int id);
    }
}
