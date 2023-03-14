using BusinessObject;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IMemberRepository memberRepository = new MemberRepository();

        //[HttpGet("{email}")]
        //public ActionResult<Member> GetMemberInfor(string email)
        //{
        //    try
        //    {
        //        return memberRepository.GetMemberByEmail(email);
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(detail: e.Message);
        //    }

        //}

        [HttpGet("{id}")]
        public ActionResult<Member> GetMemberById(int id)
        {
            try
            {
                return memberRepository.GetMemberByID(id);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, Member mem)
        {
            try
            {
                mem.MemberId = id;
                memberRepository.UpdateMember(mem);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }

        }

    }
}
