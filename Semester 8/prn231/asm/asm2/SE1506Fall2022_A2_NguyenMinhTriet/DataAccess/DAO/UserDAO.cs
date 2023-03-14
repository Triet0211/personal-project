using BusinessObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace DataAccess
{
    public class UserDAO
    {
        //Using Singleton Pattern
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();
        private UserDAO() { }
        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<User> GetUserList()
        {
            var users = new List<User>();
            try
            {
                using var context = new BookStoreContext();
                users = context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }

        public User GetUserByID(int userId)
        {
            User user = null;
            try
            {
                using var context = new BookStoreContext();
                user = context.Users.SingleOrDefault(m => m.UserId == userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        public User GetUserByEmail(string email)
        {
            User user = null;
            try
            {
                using var context = new BookStoreContext();
                user = context.Users.SingleOrDefault(m => m.EmailAddress.ToLower().Equals(email.ToLower()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public void AddUser(User user)
        {
            try
            {
                string email = new MailAddress(user.EmailAddress).Address;
                //email address is valid since the above line has not thrown an exception
            }
            catch (FormatException)
            {
                throw new Exception("Email is not valid!!!");
            }
            if (user.Password.Length < 8 || user.Password.Length > 30)
            {
                throw new Exception("Password must have 8 - 30 characters!!!");
            }
            try
            {
                User _user2 = GetUserByEmail(user.EmailAddress);
                if (_user2 == null && user.UserId == 0)
                {
                    using var context = new BookStoreContext();
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This User ID or Email is alreAdy existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Update(User user)
        {
            if (user.Password.Length < 8 || user.Password.Length > 30)
            {
                throw new Exception("Password must have 8 - 30 characters!!!");
            }
            try
            {
                User user0 = GetUserByID(user.UserId);
                if (user0 != null)
                {
                    User user2 = GetUserByEmail(user.EmailAddress);
                    if (user2 != null)
                    {
                        if (user2.UserId == user.UserId)
                        {
                            using var context = new BookStoreContext();
                            context.Users.Update(user);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("This email is used!!!");
                        }
                    }
                    else
                    {
                        using var context = new BookStoreContext();
                        context.Users.Update(user);
                        context.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("THis user is not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(int userId)
        {
            try
            {
                User user = GetUserByID(userId);
                if (user != null)
                {
                    using var context = new BookStoreContext();
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The user account is not existed.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public LoginUser Login(string email, string password)
        {
            User user = null;
            LoginUser loginUser = null;
            try
            {
                User admin = LoginAsAdmin(email, password);
                if (admin == null)
                {
                    user = LoginAsUser(email, password);
                    if (user == null)
                    {
                        throw new Exception("Wrong password and email");
                    }
                    loginUser = new LoginUser()
                    {
                        Role = user.RoleId,
                        Email = user.EmailAddress,
                        Id = user.UserId,
                    };
                }
                else
                {
                    user = admin;
                    loginUser = new LoginUser()
                    {
                        Role = user.RoleId,
                        Email = user.EmailAddress,
                        Id = 0
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return loginUser;
        }
        User LoginAsUser(string email, string password)
        {
            User user = null;
            try
            {
                using var context = new BookStoreContext();
                user = context.Users.SingleOrDefault(m => m.EmailAddress.ToLower().Equals(email.ToLower())
                                                && m.Password.Equals(password));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        User LoginAsAdmin(string email, string password)
        {
            User admin = null;

            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, true, true);
            var root = configurationBuilder.Build();
            string emailJson = root.GetSection("AdministratorAccount").GetSection("Email").Value;
            string passwordJson = root.GetSection("AdministratorAccount").GetSection("Password").Value;
            User tmp = new User
            {
                UserId = 0,
                EmailAddress = emailJson,
                Password = passwordJson,
                RoleId = 0,
            };
            if (email.Equals(tmp.EmailAddress, StringComparison.InvariantCultureIgnoreCase) && password.Equals(tmp.Password))
            {
                admin = tmp;
            }
            return admin;
        }
        public IEnumerable<User> SearchUsersByEmail(string email)
        {
            var users = new List<User>();
            try
            {
                using var context = new BookStoreContext();
                users = context.Users.Where(m => m.EmailAddress.ToLower().Contains(email.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }
        public IEnumerable<User> SortByEmail => GetUserList().ToList().OrderBy(user => user.EmailAddress);
    }
}
