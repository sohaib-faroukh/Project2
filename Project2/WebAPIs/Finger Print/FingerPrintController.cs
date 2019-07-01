using CustomerProfileBank.FingerPrint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Project2.WebAPIs.Finger_Print
{
    public class FingerPrintController : ApiController
    {
        CompareTwoFingerPrints comparer = new CompareTwoFingerPrints();
        FingerPrintBestMatch bestMatch = new FingerPrintBestMatch();


        [HttpPost]
        [Route("api/Upload")]
        public async Task<IHttpActionResult> UploadFile()
        {
            result result = new result();
            //init contex
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/App_Data");
            var provider =
                new MultipartFormDataStreamProvider(root);

            List<string> images = new List<string>(); 
            try
            {

                //get uploaded file from request body
                await Request.Content
                    .ReadAsMultipartAsync(provider);

                string ISPN = provider.FormData.Get(0);

                //iterate each file in the request (in case multiple file uploaded)
                foreach (var file in provider.FileData)
                {
                    //get the file's current name to set in app_data (from the header)
                    var name = file.Headers
                        .ContentDisposition
                        .FileName;

                    // remove double quotes from string.
                    // name = name.Trim('"');
                    name = ISPN.Trim('"');
                    //get the physical fila name with current state
                    var localFileName = file.LocalFileName;

                    //set up the destination path
                    var filePath = Path.Combine(root, ISPN);

                    images.Add(localFileName);

                    //check if the file name is already existed
                    if (!System.IO.File.Exists(filePath))
                    {
                        throw new Exception("Fingerprint doesn't exist in the database");
                    }

                    images.Add(filePath);

                }
                var arr = images.ToArray();
                if(arr.Length == 2)
                {
                     result = comparer.match(arr[0], arr[1]);
                }
               
                if(result != null)
                {
                    return Ok(result);

                }else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        [Route("api/Algo2")]
        public async Task<IHttpActionResult> SecondAlogrithm()
        {
            result result = new result();
            var source = "";
            //init contex
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/App_Data");
            var provider =
                new MultipartFormDataStreamProvider(root);

            List<string> images = new List<string>();
            try
            {

                //get uploaded file from request body
                await Request.Content
                    .ReadAsMultipartAsync(provider);

                string ISPN = provider.FormData.Get(0);

                //iterate each file in the request (in case multiple file uploaded)
                foreach (var file in provider.FileData)
                {
                    //get the file's current name to set in app_data (from the header)
                    var name = file.Headers
                        .ContentDisposition
                        .FileName;

                    // remove double quotes from string.
                    // name = name.Trim('"');
                    name = ISPN.Trim('"');
                    //get the physical fila name with current state
                    var localFileName = file.LocalFileName;

                    //set up the destination path
                    var filePath = Path.Combine(root, ISPN);

                    source=localFileName;

                    // Process the list of files found in the directory.
                    string[] fileEntries = Directory.GetFiles(root);
                    foreach (string fileName in fileEntries)
                        if (fileName.Contains(name))
                        {
                            images.Add(fileName);
                        }


                    ////check if the file name is already existed
                    //if (System.IO.File.Exists(filePath))
                    //{
                    //    images.Add(filePath);
                    //    //remove existed file
                    //    //  System.IO.File.Delete(filePath);

                    //}
                    //else
                    //{
                    //    return Ok("Fingerprint doesn't exist in the database");
                    //}
                    ////add new file
                    //System.IO.File.Move(localFileName, filePath);


                }

                bool a  ;

                if (images.Count == 0)
                {
                    throw new Exception("Can't find fingerprints between customer files");

                }
                if (images.Count > 2)
                {
                   a = bestMatch.match(source, images);
                    return Ok(a);

                }
                else
                {
                    throw new Exception("Less than 2 FingerPrints");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
