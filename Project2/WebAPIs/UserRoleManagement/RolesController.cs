using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CustomerProfileBank.Models.Context;
using CustomerProfileBank.Models.Models;
using CustomerProfileBank.Models.Repositories;

namespace Project2.WebAPIs.UserRoleManagement
{
    public class RolesController : ApiController
    {
        private List<dynamic> errorsList = new List<dynamic>();
        RoleRepo RoleRepo = new RoleRepo();


        /// <summary>
        /// get all system roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Roles")]
        public IHttpActionResult GetRoles()
        {
            errorsList.Clear();
            try
            {
                var roles = RoleRepo.GetAll().Select(ele => new
                {
                    Id = ele.Id,
                    Name = ele.Name,
                    Description = ele.Description,
                    Status = ele.Status,
                    Users = ele.Users.Select(user => new
                    {
                        Id = user.Id,
                        Alias = user.Alias,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    }),
                    Privileges = ele.Privileges.Select(pri => new
                    {
                        Id = pri.Id,
                        Name = pri.Name,
                        Description = pri.Description
                    })
                });


                return Json(roles);
            }
            catch (Exception ex)
            {
                errorsList.Add(new { Code = ex.HResult, Message = ex.Message, InnerException = ex.InnerException });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, errorsList));
            }

        }


        /// <summary>
        /// get role by id
        /// </summary>
        /// <param name="id">role id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Roles/{id}")]
        public IHttpActionResult GetRole(int id)
        {
            errorsList.Clear();
            try
            {
                var ele = RoleRepo.FindById(id);
                if (ele == null)
                {
                    throw new Exception("Role Not Found");
                }
                var toReturnRole = new
                {
                    Id = ele.Id,
                    Name = ele.Name,
                    Description = ele.Description,
                    Status = ele.Status,
                    Users = ele.Users.Select(user => new
                    {
                        Id = user.Id,
                        Alias = user.Alias,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    }),
                    Privileges = ele.Privileges.Select(pri => new
                    {
                        Id = pri.Id,
                        Name = pri.Name,
                        Description = pri.Description
                    })
                };
                return Json(toReturnRole);
            }
            catch (Exception ex)
            {
                errorsList.Add(new { Code = ex.HResult, Message = ex.Message, InnerException = ex.InnerException });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }
        }




        /// <summary>
        /// edit role
        /// </summary>
        /// <param name="id">role id</param>
        /// <param name="role">updated role object</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Roles/{id}")]
        public IHttpActionResult PutRole(int id, Role role)
        {

            errorsList.Clear();

            Role newRole = RoleRepo.FindById(id);

            if (newRole == null)
            {
                errorsList.Add(new { Code = 404, Message = "Role Not Found" });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }

            if (newRole.Status.Trim().ToUpper() == "INACTIVE")
            {
                errorsList.Add(new { Code = 404, Message = "Can't Edit deactivated Role" });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }


            #region validation
            // Check Required Name 
            if (role.Name.Trim() != null && role.Name.Trim() != String.Empty)
            {
                // Check Name Duplication
                if (RoleRepo.GetAll().FirstOrDefault(it => it.Id != id && it.Name.Trim().ToUpper() == role.Name.Trim().ToUpper()) != null)
                {
                    errorsList.Add(new { Code = 505, Message = "This Name aleady exist" });
                }
            }
            else
            {
                errorsList.Add(new { Code = 404, Message = "Name is required" });
            }


            // Check Required Description 
            if (role.Description.Trim() != null && role.Description.Trim() != String.Empty)
            {
                role.Description = role.Description.Trim();
            }
            else
            {
                errorsList.Add(new { Code = 404, Message = "Description is required" });
            }


            if (errorsList.Count > 0)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, errorsList));
            }

            #endregion

            try
            {
                newRole.Name = role.Name;
                newRole.Status = role.Status;
                newRole.Description = role.Description;

                newRole.Users.Clear();
                newRole.Users = role.Users;

                newRole.Privileges.Clear();
                newRole.Privileges = role.Privileges;
                
                var ele = RoleRepo.Edit(newRole);

                if (ele == null)
                {
                    throw new Exception("No returned role after update it");
                }
                var updatedRole = new
                {
                    Id = ele.Id,
                    Name = ele.Name,
                    Description = ele.Description,
                    Status = ele.Status,
                    Users = ele.Users.Select(user => new
                    {
                        Id = user.Id,
                        Alias = user.Alias,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    }),
                    Privileges = ele.Privileges.Select(pri => new
                    {
                        Id = pri.Id,
                        Name = pri.Name,
                        Description = pri.Description
                    })
                };
                return Json(updatedRole);
            }

            catch (Exception ex)
            {
                errorsList.Add(new { Code = ex.HResult, Message = ex.Message, InnerException = ex.InnerException });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }


        }




        /// <summary>
        /// add new role to system
        /// </summary>
        /// <param name="role">the new role</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Roles")]
        public IHttpActionResult PostRole(Role role)
        {
            errorsList.Clear();
            Role newRole = new Role();

            #region Validation

            // Check Required Name 
            if (role.Name.Trim() != null && role.Name.Trim() != String.Empty)
            {
                // Check Name Duplication
                if (RoleRepo.GetAll().FirstOrDefault(it => it.Name.Trim().ToUpper() == role.Name.Trim().ToUpper()) != null)
                {
                    errorsList.Add(new { Code = 505, Message = "This Name aleady exist" });
                }
            }
            else
            {
                errorsList.Add(new { Code = 404, Message = "Name is required" });
            }


            // Check Required Description 
            if (role.Description.Trim() != null && role.Description.Trim() != String.Empty)
            {
                role.Description = role.Description.Trim();
            }
            else
            {
                errorsList.Add(new { Code = 404, Message = "Description is required" });
            }


            if (errorsList.Count > 0)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, errorsList));
            }


            #endregion

            try
            {
                newRole = role;

                newRole.Status = "Active";

                var ele = RoleRepo.Add(newRole);

                if (ele == null)
                {
                    throw new Exception("No returned role after Add it");
                }
                var addedRole = new
                {

                    Id = ele.Id,
                    Name = ele.Name,
                    Description = ele.Description,
                    Status = ele.Status,
                    Users = ele.Users.Select(user => new
                    {
                        Id = user.Id,
                        Alias = user.Alias,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    }),
                    Privileges = ele.Privileges.Select(pri => new
                    {
                        Id = pri.Id,
                        Name = pri.Name,
                        Description = pri.Description
                    })
                };
                return Json(addedRole);
            }

            catch (Exception ex)
            {
                errorsList.Add(new { Code = ex.HResult, Message = ex.Message, InnerException = ex.InnerException });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }

        }

        
        /// <summary>
        /// delete role from the system
        /// </summary>
        /// <param name="id">role id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/Roles/{id}")]
        public IHttpActionResult DeleteRole(int id)
        {

            errorsList.Clear();
            try
            {
                var ele = RoleRepo.FindById(id);
                if (ele == null)
                {
                    throw new Exception("Can't find the role with id : " + id);
                }

                var deletedRole = new
                {
                    Id = ele.Id,
                    Name = ele.Name,
                    Description = ele.Description,
                    Status = ele.Status,
                    Users = ele.Users.Select(user => new
                    {
                        Id = user.Id,
                        Alias = user.Alias,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    }).ToList(),
                    Privileges = ele.Privileges.Select(pri => new
                    {
                        Id = pri.Id,
                        Name = pri.Name,
                        Description = pri.Description
                    }).ToList()
                };

                bool res = RoleRepo.Delete(id);

                if (res == false)
                {
                    throw new Exception("Can't Delete the role with id :" + id);
                }

                return Json(deletedRole);

            }
            catch (Exception ex)
            {
                errorsList.Add(new { Code = ex.HResult, Message = ex.Message, InnerException = ex.InnerException });
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, errorsList));
            }

        }

    }
}