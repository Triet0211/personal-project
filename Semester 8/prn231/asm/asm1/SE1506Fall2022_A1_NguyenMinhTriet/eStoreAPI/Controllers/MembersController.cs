using BusinessObject;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private IMemberRepository memberRepository = new MemberRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetMembers()
        {
            try
            {
                return memberRepository.GetMembers().ToList();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

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

        [HttpGet("email/{email}")]
        public ActionResult<Member> GetMemberByEmail(string email)
        {
            try
            {
                return memberRepository.GetMemberByEmail(email);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertMember(Member mem)
        {
            try
            {
                memberRepository.InsertMember(mem);

                return NoContent();
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

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            try
            {
                memberRepository.DeleteMember(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }

        }

        [HttpPost("login")]
        public ActionResult<LoginUser> Login([FromBody] LoginObject user)
        {
            try
            {
                return memberRepository.Login(user.Email, user.Password);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

    }
}
