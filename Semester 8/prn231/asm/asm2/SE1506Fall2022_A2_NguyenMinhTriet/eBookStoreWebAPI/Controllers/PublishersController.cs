using BusinessObject;
using DataAccess.Repositories;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace eBookStoreWebAPI.Controllers
{
    public class PublishersController : ODataController
    {
        private IPublisherRepository publisherRepository = new PublisherRepository();

        [Authorize]
        [EnableQuery]
        public ActionResult<IEnumerable<Publisher>> Get()
        {
            try
            {
                return publisherRepository.GetPublishers().ToList();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        public ActionResult Post([FromBody] Publisher publisher)
        {
            try
            {
                publisherRepository.CreateNewPublisher(publisher);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }
        [EnableQuery]
        public SingleResult<Publisher> Get([FromODataUri] int key)
        {
            IQueryable<Publisher> result = publisherRepository.GetPublishers().Where(p => p.PubId == key).AsQueryable();
            return SingleResult.Create(result);
        }

        public ActionResult Put([FromODataUri] int key, [FromBody] Publisher publisher)
        {
            try
            {
                Publisher pub = publisherRepository.GetPublishers().FirstOrDefault(p => p.PubId == key);
                if (pub == null)
                {
                    throw new Exception("Publisher not found!");
                }
                publisherRepository.UpdatePublisher(publisher);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }
        public ActionResult Delete([FromODataUri] int key)
        {
            try
            {
                publisherRepository.DeletePublisher(key);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Publisher>> GetPublishers()
        //{
        //    try
        //    {
        //        return publisherRepository.GetPublishers().ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(detail: e.Message);
        //    }
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<Publisher>> GetPublishers()
        //{
        //    try
        //    {
        //        return publisherRepository.GetPublishers().ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(detail: e.Message);
        //    }
        //}

        //[HttpGet("{id}")]
        //public ActionResult<User> GetUserById(int id)
        //{
        //    try
        //    {
        //        return userRepository.GetUserByID(id);
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(detail: e.Message);
        //    }
        //}

        //[HttpGet("email/{email}")]
        //public ActionResult<User> GetUserByEmail(string email)
        //{
        //    try
        //    {
        //        return userRepository.GetUserByEmail(email);
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(detail: e.Message);
        //    }
        //}

        //[HttpPost]
        //public IActionResult InsertUser(User mem)
        //{
        //    try
        //    {
        //        userRepository.InsertUser(mem);

        //        return NoContent();
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(detail: e.Message);
        //    }

        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateUser(int id, User mem)
        //{
        //    try
        //    {
        //        mem.UserId = id;
        //        userRepository.UpdateUser(mem);
        //        return NoContent();
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(detail: e.Message);
        //    }

        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteUser(int id)
        //{
        //    try
        //    {
        //        userRepository.DeleteUser(id);
        //        return NoContent();
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(detail: e.Message);
        //    }

        //}

        //[HttpPost("login")]
        //public ActionResult<LoginUser> Login([FromBody] LoginObject user)
        //{
        //    try
        //    {
        //        return userRepository.Login(user.Email, user.Password);
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(detail: e.Message);
        //    }
        //}

    }
}
