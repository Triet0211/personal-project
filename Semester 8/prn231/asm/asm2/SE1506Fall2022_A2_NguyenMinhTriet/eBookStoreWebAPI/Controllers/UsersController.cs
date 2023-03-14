using BusinessObject;
using DataAccess.Repositories;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository userRepository = new UserRepository();

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                return userRepository.GetUsers().ToList();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            try
            {
                return userRepository.GetUserByID(id);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpGet("email/{email}")]
        public ActionResult<User> GetUserByEmail(string email)
        {
            try
            {
                return userRepository.GetUserByEmail(email);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertUser(User mem)
        {
            try
            {
                userRepository.InsertUser(mem);

                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User mem)
        {
            try
            {
                mem.UserId = id;
                userRepository.UpdateUser(mem);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                userRepository.DeleteUser(id);
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
                return userRepository.Login(user.Email, user.Password);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

    }
}
