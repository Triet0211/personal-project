using BusinessObject;
using System.Collections.Generic;


namespace DataAccess.Repositories
{
    public interface IMemberRepository
    {
        IEnumerable<eStoreUser> GetMembers();
        eStoreUser GetMemberByID(string memberId);
        eStoreUser GetMemberByEmail(string email);
    }
}