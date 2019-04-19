using CustomerProfileBank.Models.Models;
using CustomerProfileBank.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Project2.WebAPIs
{
    [EnableCors("http://localhost:4200", "*", "*")]
    public class UsersController : ApiController
    {
        UserRepo uRepo = new UserRepo();
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            try
            {              
                    var user = uRepo.FindById(id);
                    if (user == null) return NotFound();
                    return Ok(user);                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            try
            {              
                    var users = uRepo.GetAll();
                    return Ok(users);                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public IHttpActionResult PostUser([FromBody]User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                
                    uRepo.Add(user);
                    return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateUser(int id, [FromBody]User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != user.Id) return BadRequest();

            try
            {              
                    var oldUser = uRepo.FindById(id);
                    if (oldUser == null) return NotFound();
                    var newUser = uRepo.Edit(oldUser, user);
                    return Ok(newUser);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
               
                    var user = uRepo.FindById(id);
                    if (user == null) return NotFound();

                   var deletedUser= uRepo.Delete(id);

                    return Ok(deletedUser);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
