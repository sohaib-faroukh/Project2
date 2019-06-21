using Antlr.Runtime;
using CustomerProfileBank.Models.Models;
using CustomerProfileBank.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace Project2.WebAPIs
{
    [EnableCors("*", "*", "*")]
    public class UsersController : ApiController
    {
        UserRepo uRepo = new UserRepo();

        private List<dynamic> errorsList = new List<dynamic>();

      
        /// <summary>
        /// gets all users from repo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Users")]
        public IHttpActionResult GetUsers()
        {
            errorsList.Clear();
            try
            {
                var users = uRepo.GetAll().Select(ele => new
                {
                    Id = ele.Id,
                    HRId = ele.HRId,
                    Alias = ele.Alias,
                    LastName = ele.LastName,
                    FirstName = ele.FirstName,
                    Status = ele.Status,
                    CreationDate = ele.CreationDate,
                    DeactivationDate = ele.DeactivationDate,
                    Roles = ele.Roles.Select(rol => new
                    {
                        Id = rol.Id,
                        Name = rol.Name,
                        Description = rol.Description
                    })
                });

                return Json(users);
            }
            catch (Exception ex)
            {
                errorsList.Add(new { Code = ex.HResult, Message = ex.Message, InnerException = ex.InnerException });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, errorsList));
            }

        }

        /// <summary>
        /// return user full information 
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Users/{id}")]
        public IHttpActionResult GetUser(int id)
        {

            errorsList.Clear();
            try
            {
                var ele = uRepo.FindById(id);
                if (ele == null)
                {
                    throw new Exception("User Not Found");
                }
                var toReturnUser = new
                {
                    Id = ele.Id,
                    HRId = ele.HRId,
                    Alias = ele.Alias,
                    LastName = ele.LastName,
                    FirstName = ele.FirstName,
                    Status = ele.Status,
                    CreationDate = ele.CreationDate,
                    DeactivationDate = ele.DeactivationDate,
                    Roles = ele.Roles.Select(rol => new
                    {
                        Id = rol.Id,
                        Name = rol.Name,
                        Description = rol.Description
                    })
                };
                return Json(toReturnUser);
            }
            catch (Exception ex)
            {
                errorsList.Add(new { Code = ex.HResult, Message = ex.Message, InnerException = ex.InnerException });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }

        }


        /// <summary>
        /// add new user to system user list 
        /// </summary>
        /// <param name="user">user object</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Users")]

        public IHttpActionResult PostUser([FromBody]User user)
        {

            errorsList.Clear();
            User newUser = new User();

            user.Status = "Active";
            user.CreationDate = DateTime.Now;

            // Check Required HRId 

            if (user.HRId != 0 && user.HRId <= int.MaxValue && user.HRId >= int.MinValue)
            {
                // Check HRId Duplication
                if (uRepo.GetAll().FirstOrDefault(it => it.HRId == user.HRId) == null)
                {
                    newUser.HRId = user.HRId;
                }

                else
                {
                    errorsList.Add(new { error_code = 10, Message = "This HRId aleady exist" });
                }
            }
            else
            {
                errorsList.Add(new { error_code = 10, Message = "HRId ir required" });
            }


            // Check Required ALias 
            if (user.Alias != null && user.Alias != String.Empty)
            {
                // Check ALias Duplication
                if (uRepo.GetAll().FirstOrDefault(it => it.Alias.Trim().ToUpper() == user.Alias.Trim().ToUpper()) == null)
                {
                    newUser.Alias = user.Alias.Trim().ToUpperInvariant();

                }
                else
                {
                    errorsList.Add(new { error_code = 10, Message = "This Alias aleady exist" });
                }

            }
            else
            {
                errorsList.Add(new { error_code = 10, Message = "Alias is required" });
            }



            // Check Required FirstName 
            if (user.FirstName != null && user.FirstName != String.Empty)
            {
                newUser.FirstName = user.FirstName.Trim();
            }
            else
            {
                errorsList.Add(new { error_code = 10, Message = "First Name is required" });
            }


            // Check Required LastName 
            if (user.LastName != null && user.FirstName != String.Empty)
            {
                newUser.LastName = user.LastName.Trim();
            }
            else
            {
                errorsList.Add(new { error_code = 10, Message = "Last Name is required" });
            }


            if (errorsList.Count > 0)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, errorsList));
            }

            try
            {
                newUser.Status = "Active";
                newUser.CreationDate = DateTime.Now;
                newUser.Roles = user.Roles;


                var ele = uRepo.Add(newUser);

                if (ele == null)
                {
                    throw new Exception("No returned user after Add it");
                }
                var addedUser = new
                {
                    Id = ele.Id,
                    HRId = ele.HRId,
                    Alias = ele.Alias,
                    LastName = ele.LastName,
                    FirstName = ele.FirstName,
                    Status = ele.Status,
                    CreationDate = ele.CreationDate,
                    DeactivationDate = ele.DeactivationDate,
                    Roles = ele.Roles.Select(rol => new
                    {
                        Id = rol.Id,
                        Name = rol.Name,
                        Description = rol.Description
                    })
                };
                return Json(addedUser);
            }

            catch (Exception ex)
            {
                errorsList.Add(new { Code = ex.HResult, Message = ex.Message, InnerException = ex.InnerException });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }
        }

        /// <summary>
        /// update user information
        /// </summary>
        /// <param name="id">the user id </param>
        /// <param name="user">user new data </param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Users/{id}")]
        public IHttpActionResult UpdateUser(int id, [FromBody]User user)
        {

            errorsList.Clear();

            User newUser = uRepo.FindById(id);

            if (newUser == null)
            {
                errorsList.Add(new { Code = 404, Message = "User Not Found" });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }

            if (newUser.Status.Trim().ToUpper() == "INACTIVE")
            {
                errorsList.Add(new { Code = 404, Message = "Can't Edit deactivated User" });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }


            #region validation
            // Check Required HRId 
            if (user.HRId != 0 && user.HRId <= int.MaxValue && user.HRId >= int.MinValue)
            {
                // Check HRId Duplication
                if (uRepo.GetAll().FirstOrDefault(it => it.Id != id && it.HRId == user.HRId) != null)
                {
                    errorsList.Add(new { Code = 505, Message = "This HRId aleady exist" });
                }
            }
            else
            {
                errorsList.Add(new { Code = 404, Message = "HRId is required" });
            }


            // Check Required ALias 
            if (user.Alias != null && user.Alias != String.Empty)
            {
                // Check ALias Duplication
                if (uRepo.GetAll().FirstOrDefault(it => it.Id != id && it.Alias.Trim().ToUpper() == user.Alias.Trim().ToUpper()) == null)
                {
                    user.Alias = user.Alias.Trim().ToUpper();
                }
                else
                {
                    errorsList.Add(new { Code = 505, Message = "This Alias aleady exist" });
                }

            }
            else
            {
                errorsList.Add(new { Code = 404, Message = "Alias is required" });
            }



            // Check Required FirstName 
            if (user.FirstName != null && user.FirstName != String.Empty)
            {
                user.FirstName = user.FirstName.Trim();
            }
            else
            {
                errorsList.Add(new { Code = 404, Message = "First Name is required" });
            }


            // Check Required LastName 
            if (user.LastName != null && user.FirstName != String.Empty)
            {
                user.LastName = user.LastName.Trim();
            }
            else
            {
                errorsList.Add(new { Code = 404, Message = "Last Name is required" });
            }


            if (errorsList.Count > 0)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, errorsList));
            }

            #endregion

            try
            {
                newUser.HRId = user.HRId;
                newUser.Alias = user.Alias;
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.Roles.Clear();
                newUser.Roles = user.Roles;

                var ele = uRepo.Edit(newUser);

                if (ele == null)
                {
                    throw new Exception("No returned user after update it");
                }
                var updatedUser = new
                {
                    Id = ele.Id,
                    HRId = ele.HRId,
                    Alias = ele.Alias,
                    LastName = ele.LastName,
                    FirstName = ele.FirstName,
                    Status = ele.Status,
                    CreationDate = ele.CreationDate,
                    DeactivationDate = ele.DeactivationDate,
                    Roles = ele.Roles.Select(rol => new
                    {
                        Id = rol.Id,
                        Name = rol.Name,
                        Description = rol.Description
                    })
                };
                return Json(updatedUser);
            }

            catch (Exception ex)
            {
                errorsList.Add(new { Code = ex.HResult, Message = ex.Message, InnerException = ex.InnerException });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }

        }



        /// <summary>
        /// delete user from system
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/Users/{id}")]

        public IHttpActionResult DeleteUser(int id)
        {
            errorsList.Clear();
            try
            {
                var ele = uRepo.FindById(id);
                if (ele == null)
                {
                    throw new Exception("Can't find the user with id : " + id);
                }

                var deletedUser = new
                {
                    Id = ele.Id,
                    HRId = ele.HRId,
                    Alias = ele.Alias,
                    LastName = ele.LastName,
                    FirstName = ele.FirstName,
                    Status = ele.Status,
                    CreationDate = ele.CreationDate,
                    DeactivationDate = ele.DeactivationDate,
                    Roles = ele.Roles.Select(rol => new
                    {
                        Id = rol.Id,
                        Name = rol.Name,
                        Description = rol.Description
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
                errorsList.Add(new { Code = ex.HResult, Message = ex.Message, InnerException = ex.InnerException });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }

        }

    }

}
