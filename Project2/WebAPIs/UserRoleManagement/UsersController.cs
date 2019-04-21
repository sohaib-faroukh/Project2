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


        // URL : api/UserRoleManagement/User/{id}
        /// <summary>
        /// return user information by it's id from repo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// gets all users from repo
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// add new user to system user list 
        /// </summary>
        /// <param name="user">user object</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PostUser([FromBody]User user)
        {
            int error_code = 0;

            //if (!ModelState.IsValid) {
            //    return BadRequest(ModelState);
            //}

            User newUser = new CustomerProfileBank.Models.Models.User();

            if (user.HRId < Int32.MaxValue && user.HRId > Int32.MinValue)
            {
                newUser.HRId = user.HRId;
            }
            else
            {
                error_code = 100;
                throw new Exception("HRID volume is out of boundaries");

            }
            if (user.FirstName != null && user.FirstName != String.Empty) {

                newUser.FirstName = user.FirstName.Trim();
            }
            else
            {
                error_code = 120;
                throw new Exception("FirstName is required");
            }
            if (user.LastName != null && user.FirstName != String.Empty) {
                newUser.LastName = user.LastName.Trim();
            }else
            {

                error_code = 130;
                throw new Exception("LastName is required");


            }
            if (user.Alias != null && user.Alias != String.Empty)
            {
                newUser.Alias = user.Alias.Trim().ToUpperInvariant();

            }
            else
            {
                error_code = 110;
                throw new Exception("Alias is required");

            }

            newUser.Status = "Active";
            newUser.CreationDate = DateTime.Now;
            newUser.Roles = user.Roles;

            try
            {

                    uRepo.Add(newUser);
                    return Json(new { user = newUser , error_code});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// update user information
        /// </summary>
        /// <param name="id">the user to update id </param>
        /// <param name="user">user new data </param>
        /// <returns></returns>
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

        /// <summary>
        /// delete or deactivate user from use system
        /// </summary>
        /// <param name="id">the user to delete/deactivate id </param>
        /// <returns></returns>
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
