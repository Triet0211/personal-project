using BusinessObject;
using System.Collections.Generic;


namespace DataAccess.Repositories
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberByID(int memberId);
        Member GetMemberByEmail(string email);
        void InsertMember(Member member);
        void DeleteMember(int memberId);
        void UpdateMember(Member member);
        LoginUser Login(string email, string password);
        IEnumerable<Member> GetMembersByEmail(string email);
        IEnumerable<Member> SortMembers();
    }
}