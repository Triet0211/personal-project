using BusinessObject;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<eStoreUser> GetMembers() => MemberDAO.Instance.GetMemberList();
        public eStoreUser GetMemberByID(string memberId) => MemberDAO.Instance.GetMemberByID(memberId);
        public eStoreUser GetMemberByEmail(string email) => MemberDAO.Instance.GetMemberByEmail(email);
    }
}
