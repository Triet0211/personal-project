using BusinessObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace DataAccess
{
    public class MemberDAO
    {
        //Using Singleton Pattern
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Member> GetMemberList()
        {
            var members = new List<Member>();
            try
            {
                using var context = new MyFStoreContext();
                members = context.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public Member GetMemberByID(int memberId)
        {
            Member member = null;
            try
            {
                using var context = new MyFStoreContext();
                member = context.Members.SingleOrDefault(m => m.MemberId == memberId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public Member GetMemberByEmail(string email)
        {
            Member member = null;
            try
            {
                using var context = new MyFStoreContext();
                member = context.Members.SingleOrDefault(m => m.Email.ToLower().Equals(email.ToLower()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void AddMember(Member member)
        {
            try
            {
                string email = new MailAddress(member.Email).Address;
                //email address is valid since the above line has not thrown an exception
            }
            catch (FormatException)
            {
                throw new Exception("Email is not valid!!!");
            }
            if (member.Password.Length < 8 || member.Password.Length > 30)
            {
                throw new Exception("Password must have 8 - 30 characters!!!");
            }
            try
            {
                Member _mem1 = GetMemberByID(member.MemberId);
                Member _mem2 = GetMemberByEmail(member.Email);
                if (_mem1 == null && _mem2 == null)
                {
                    using var context = new MyFStoreContext();
                    context.Members.Add(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Member ID or Email is alreAdy existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Update(Member member)
        {
            if (member.Password.Length < 8 || member.Password.Length > 30)
            {
                throw new Exception("Password must have 8 - 30 characters!!!");
            }
            try
            {
                Member mem = GetMemberByID(member.MemberId);
                if(mem != null)
                {
                    Member mem2 = GetMemberByEmail(member.Email);
                    if(mem2 != null)
                    {
                        if(mem2.MemberId == mem.MemberId)
                        {
                            using var context = new MyFStoreContext();
                            context.Members.Update(member);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("This email is used!!!");
                        }
                    }
                    else
                    {
                        using var context = new MyFStoreContext();
                        context.Members.Update(member);
                        context.SaveChanges();
                    }
                    
                }
                else
                {
                    throw new Exception("THis member is not existed!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(int memberId)
        {
            try
            {
                Member mem = GetMemberByID(memberId);
                if (mem != null)
                {
                    using var context = new MyFStoreContext();
                    context.Members.Remove(mem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member account is not existed.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Member LoginAsMember(string email, string password)
        {
            Member member = null;        
            try
            {
                using var context = new MyFStoreContext();
                member = context.Members.SingleOrDefault(m => m.Email.ToLower().Equals(email.ToLower())
                                                && m.Password.Equals(password) );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public Member LoginAsAdmin(string email, string password)
        {
            Member admin = null;

            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, true, true);
            var root = configurationBuilder.Build();
            string emailJson = root.GetSection("accountAdmin").GetSection("email").Value;
            string passwordJson = root.GetSection("accountAdmin").GetSection("password").Value;
            Member tmp = new Member
            {
                MemberId = 0,
                Email = emailJson,
                Password = passwordJson,
                City = "",
                Country = "",
                CompanyName = ""
            };
            if (email.Equals(tmp.Email, StringComparison.InvariantCultureIgnoreCase) && password.Equals(tmp.Password))
            {
                admin = tmp;
            }
            return admin;
        }
        public IEnumerable<Member> SearchMembersByEmail(string email)
        {
            var members = new List<Member>();
            try
            {
                using var context = new MyFStoreContext();
                members = context.Members.Where(m => m.Email.ToLower().Contains(email.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }
        public IEnumerable<Member> SortByEmail => GetMemberList().ToList().OrderBy(mem => mem.Email);
    }
}
