using Antlr.Runtime;
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


        /// <summary>
        /// return user full information 
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/User/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            try
            {
                var ele = uRepo.FindById(id);
                if (ele == null)
                {
                    throw new Exception("Not Found");
                }
                var toReturnUser = new
                {
                    id = ele.Id,
                    hrId = ele.HRId,
                    alias = ele.Alias,
                    lastName = ele.LastName,
                    firstName = ele.FirstName,
                    status = ele.Status,
                    creationDate = ele.CreationDate,
                    deactivationDate = ele.DeactivationDate,
                    Roles = ele.Roles.Select(rol => new
                    {
                        id = rol.Id,
                        name = rol.Name,
                        description = rol.Description
                    })
                };
                return Ok(toReturnUser);
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
        [Route("api/Users")]
        public IHttpActionResult GetUsers()
        {
            try
            {
                var users = uRepo.GetAll().Select(ele => new
                {
                    id = ele.Id,
                    hrId = ele.HRId,
                    alias = ele.Alias,
                    lastName = ele.LastName,
                    firstName = ele.FirstName,
                    status = ele.Status,
                    creationDate = ele.CreationDate,
                    deactivationDate = ele.DeactivationDate,
                    Roles = ele.Roles.Select(rol => new
                    {
                        id = rol.Id,
                        name = rol.Name,
                        description = rol.Description
                    })
                });


                return Json(users);
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
        [Route("api/Users/post")]

        public IHttpActionResult PostUser([FromBody]User user)
        {
            User newUser = new User();

            user.Status = "Active";
            user.CreationDate = DateTime.Now;

            this.Validate(user, "errorModelState");

            if (!ModelState.IsValidField("errorModelState"))
            {
                return BadRequest(ModelState);
            }


            // Check Required HRId 
            if (user.HRId != null)
            {
                // Check HRId Duplication
                if (uRepo.GetAll().FirstOrDefault(it => it.HRId == user.HRId) == null)
                {
                    newUser.HRId = user.HRId;
                }

                else
                {
                    throw new Exception("HRId is required");
                }
            }
            else
            {
                throw new Exception("This HRId aleady exist");
            }


            // Check Required ALias 
            if (user.Alias != null && user.Alias != String.Empty)
            {
                // Check ALias Duplication
                if (uRepo.GetAll().FirstOrDefault(it => it.Alias == user.Alias) == null)
                {
                    newUser.Alias = user.Alias.Trim().ToUpperInvariant();

                }
                else
                {
                    throw new Exception("This Alias aleady exist");
                }

            }
            else
            {
                throw new Exception("Alias is required");
            }



            // Check Required FirstName 
            if (user.FirstName != null && user.FirstName != String.Empty)
            {

                newUser.FirstName = user.FirstName.Trim();
            }
            else
            {
                throw new Exception("First Name is required");
            }


            // Check Required LastName 
            if (user.LastName != null && user.FirstName != String.Empty)
            {
                newUser.LastName = user.LastName.Trim();
            }
            else
            {
                throw new Exception("Last Name is required");
            }


            newUser.Status = "Active";
            newUser.CreationDate = DateTime.Now;
            newUser.Roles = user.Roles;

            try
            {
                var ele = uRepo.Add(newUser);

                if (ele == null)
                {
                    throw new Exception("No returned user after Add it");
                }
                var addedUser = new
                {
                    id = ele.Id,
                    hrId = ele.HRId,
                    alias = ele.Alias,
                    lastName = ele.LastName,
                    firstName = ele.FirstName,
                    status = ele.Status,
                    creationDate = ele.CreationDate,
                    deactivationDate = ele.DeactivationDate,
                    Roles = ele.Roles.Select(rol => new
                    {
                        id = rol.Id,
                        name = rol.Name,
                        description = rol.Description
                    })
                };
                return Json(addedUser);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// update user information
        /// </summary>
        /// <param name="id">the user id </param>
        /// <param name="user">user new data </param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Users/put/{id}")]
        public IHttpActionResult UpdateUser(int id, [FromBody]User user)
        {
            User newUser = uRepo.FindById(id);
            if (newUser == null)
            {
                throw new Exception("Not Found");

            }

            user.Status = "Active";
            user.CreationDate = DateTime.Now;

            this.Validate(user, "errorModelState");

            if (!ModelState.IsValidField("errorModelState"))
            {
                return BadRequest(ModelState);
            }


            // Check Required HRId 
            if (user.HRId != null && user.HRId <= Int32.MaxValue && user.HRId >= Int32.MinValue)
            {
                // Check HRId Duplication
                if (uRepo.GetAll().FirstOrDefault(it => it.Id != id && it.HRId == user.HRId) == null)
                {
                    newUser.HRId = user.HRId;
                }

                else
                {
                    throw new Exception("This HRId aleady exist");
                }
            }
            else
            {
                throw new Exception("HRId is required");

            }


            // Check Required ALias 
            if (user.Alias != null && user.Alias != String.Empty)
            {
                // Check ALias Duplication
                if (uRepo.GetAll().FirstOrDefault(it => it.Id != id && it.Alias == user.Alias) == null)
                {
                    newUser.Alias = user.Alias.Trim().ToUpperInvariant();

                }
                else
                {
                    throw new Exception("This Alias aleady exist");
                }

            }
            else
            {
                throw new Exception("Alias is required");

            }



            // Check Required FirstName 
            if (user.FirstName != null && user.FirstName != String.Empty)
            {

                newUser.FirstName = user.FirstName.Trim();
            }
            else
            {
                throw new Exception("First Name is required");
            }


            // Check Required LastName 
            if (user.LastName != null && user.FirstName != String.Empty)
            {
                newUser.LastName = user.LastName.Trim();
            }
            else
            {
                throw new Exception("Last Name is required");
            }


            newUser.Status = "Active";
            newUser.CreationDate = DateTime.Now;
            newUser.Roles = user.Roles;

            try
            {
                var ele = uRepo.Edit(newUser);
                if (ele == null)
                {
                    throw new Exception("No returned user after update it");
                }
                var updatedUser = new
                {
                    id = ele.Id,
                    hrId = ele.HRId,
                    alias = ele.Alias,
                    lastName = ele.LastName,
                    firstName = ele.FirstName,
                    status = ele.Status,
                    creationDate = ele.CreationDate,
                    deactivationDate = ele.DeactivationDate,
                    Roles = ele.Roles.Select(rol => new
                    {
                        id = rol.Id,
                        name = rol.Name,
                        description = rol.Description
                    })
                };
                return Json(updatedUser);
            }

            catch (Exception ex)
            {
                //Request.CreateResponse(ex);
                //return this.InternalServerError(ex);
                return BadRequest(ex.Message);
            }

        }

        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                var ele = uRepo.FindById(id);
                if (ele == null)
                {
                    throw new Exception("Can't find the user with id :" + id);
                }

                var deletedUser = new
                {
                    id = ele.Id,
                    hrId = ele.HRId,
                    alias = ele.Alias,
                    lastName = ele.LastName,
                    firstName = ele.FirstName,
                    status = ele.Status,
                    creationDate = ele.CreationDate,
                    deactivationDate = ele.DeactivationDate,
                    Roles = ele.Roles.Select(rol => new
                    {
                        id = rol.Id,
                        name = rol.Name,
                        description = rol.Description
                    })
                };

                bool res = uRepo.Delete(id);
                if (res == false)
                {
                    throw new Exception("Can't Delete the user with id :" + id);
                }

                return Json(deletedUser);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }

}
