using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project2.Controllers.APIs
{
    public class UserRoleManagementController : ApiController
    {
        // GET: api/UserRoleManagement
        [HttpGet]
        public IHttpActionResult getUsers()
        {
            return Json(new {  });
        }
    }
}
