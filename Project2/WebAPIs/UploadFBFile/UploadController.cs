using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project2.WebAPIs.UploadFBFile
{
    public class UploadController : ApiController
    {
        [HttpPost]
        [Route("api/Upload")]
        public async Task<IHttpActionResult> Upload()
        {

            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }

            // img 

            var b = Request.Content.ReadAsStringAsync().Result;


            return Json(new { });
        }
    }
}
