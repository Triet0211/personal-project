using BusinessObject;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMemberList();
        public Member GetMemberByID(int memberId) => MemberDAO.Instance.GetMemberByID(memberId);
        public Member GetMemberByEmail(string email) => MemberDAO.Instance.GetMemberByEmail(email);
        public void InsertMember(Member member) => MemberDAO.Instance.AddMember(member);
        public void DeleteMember(int memberId) => MemberDAO.Instance.Remove(memberId);
        public void UpdateMember(Member member) => MemberDAO.Instance.Update(member);
        public LoginUser Login(string email, string password) => MemberDAO.Instance.Login(email, password);
        public IEnumerable<Member> GetMembersByEmail(string email) => MemberDAO.Instance.SearchMembersByEmail(email);
        public IEnumerable<Member> SortMembers() => MemberDAO.Instance.SortByEmail;
    }
}
