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
        public IEnumerable<eStoreUser> GetMemberList()
        {
            var members = new List<eStoreUser>();
            try
            {
                using var context = new eStoreDbContext();
                members = context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public eStoreUser GetMemberByID(string memberId)
        {
            eStoreUser member = null;
            try
            {
                using var context = new eStoreDbContext();
                member = context.Users.SingleOrDefault(m => m.Id == memberId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public eStoreUser GetMemberByEmail(string email)
        {
            eStoreUser member = null;
            try
            {
                using var context = new eStoreDbContext();
                member = context.Users.SingleOrDefault(m => m.Email.ToLower().Equals(email.ToLower()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
    }
}
