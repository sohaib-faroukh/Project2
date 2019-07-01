using CustomerProfileBank.Models.Helpers;
using CustomerProfileBank.Models.Models;
using CustomerProfileBank.Models.Repositories;
using CustomerProfileBank.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Project2.WebAPIs.Customer_Profile_Mangement
{

    [EnableCors("*", "*", "*"/*,SupportsCredentials =false*/)]
    public class CustomersController : ApiController
    {
        CustomerRepo Repo = new CustomerRepo();

        /*
        * - TODO : this below list represent the last tasks related the following API
        * 1 - validate if user Authorized to this process
        */

        [HttpGet]
        [Route(template: "api/customers")]
        public IHttpActionResult getAll()
        {

            try
            {

                var selectResult = Repo.GetAll().Select(ele => new
                {
                    Id = ele.Id,
                    ele.FirstName,
                    ele.LastName,
                    ISPN = ele.ISPN,
                    Status = ele.Status,
                    Address = ele.Address,
                    NationalNumber=ele.NationalNumber,

                    Numbers = ele.Numbers.Select(num => new
                    {
                        num.Id,
                        num.PhoneNumber,
                    }),


                    Services = ele.Services.Select(srv => new
                    {
                        srv.Id,
                        srv.Name,
                        srv.Status,
                        ServiceTypeName = srv.ServiceType.Name,
                    }),

                });

                var result = new Object();

                if (selectResult != null)
                {
                    result = selectResult;
                }

                return Json(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /*
        * - TODO : this below list represent the last tasks related the following API
        * 1 - validate if user Authorized to this process
        */
        [HttpGet]
        [Route(template: "api/customers/{Id}")]
        public IHttpActionResult getById(int Id)
        {
            try
            {
                var ele = Repo.FindById(Id);

                if (ele == null)
                {
                    throw new Exception("Customer not found");
                }

                var result = new
                {
                    Id = ele.Id,
                    ele.FirstName,
                    ele.LastName,
                    ISPN = ele.ISPN,
                    Status = ele.Status,
                    Address = ele.Address,
                    NationalNumber = ele.NationalNumber,

                    Numbers = ele.Numbers.Select(num => new
                    {
                        num.Id,
                        num.PhoneNumber,
                    }),


                    Services = ele.Services.Select(srv => new
                    {
                        srv.Id,
                        srv.Name,
                        srv.Status,
                        ServiceTypeName = srv.ServiceType.Name,
                    }),

                };

                return Json(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
        * - TODO : this below list represent the last tasks related the following API
        * 1 - validate if the customer need to post the configurations depends on the relations with other tables (i.e : Numbers,...)
        * 2 - validate if user Authorized to this process
        */
        [HttpPost]
        [Route(template: "api/customers/post")]
        public IHttpActionResult post(CustomerVM Customer)
        {

            bool valid = true;
            try
            {
                /* validate */



                Customer newCustomer = new Customer();



                /* assing these objects using ovloaded operator in CustomerVM class */
                newCustomer = Customer;


                int count = Repo.FindBy(ele => ele.NationalNumber.Equals(newCustomer.NationalNumber)).Count();

                if (count > 0)
                {
                    throw new Exception("This National Number is Already Exist");
                }

                /* set the initial status when add customer for the first time */
                newCustomer.Status = "ACTIVE";

                /* check if the new object valid oppsite the configuration */
                Validate(newCustomer, "newCustomer");


                Customer addedCustomer = null;
                valid = ModelState.IsValidField("newCustomer");
                if (valid)
                {
                    /* Add new Customer using Reository Add method passing the new Customer object */
                    addedCustomer = Repo.Add(newCustomer);
                }



                /* Check if the customer Added */
                if (addedCustomer == null)
                {
                    throw new Exception("Can't add the survey");
                }

                /* select the proprties of the addedCustomer to return */
                var result = Repo.FindById(addedCustomer.Id);
                if (result == null)
                {
                    throw new Exception("Can't post Customer");
                }


                return Json(result);

            }
            catch (Exception ex)
            {
                if (valid)
                    return BadRequest(ex.Message);
                else
                    return BadRequest(ModelState);
            }


        }

        /*
         * - TODO : this below list represent the last tasks related the following API
         * 1 - validate if the customer need to update the configurations depends on the relations with other tables (i.e : Numbers,...)
         * 2 - validate if user Authorized to this process
         */




        /// <summary>
        /// update customer information API
        /// </summary>
        /// <param name="id">the customer id</param>
        /// <param name="_Customer">the new customer information object</param>
        /// <returns></returns>
        [HttpPut]
        [Route(template: "api/customers/put/{id}")]
        public IHttpActionResult put(int id, CustomerVM _Customer)
        {

            bool valid = false;

            try
            {
                Customer toUpdateCustomer = Repo.FindById(id);

                if (toUpdateCustomer == null)
                {
                    throw new Exception("Customer not Found");
                }

                Customer newCustomerData = new Customer();


                /* assing these objects using ovloaded operator in CustomerVM class */
                newCustomerData = _Customer;


                newCustomerData.Id = id;
                newCustomerData.Status = toUpdateCustomer.Status;

                /* check if the new object valid oppsite the configuration */
                Validate(newCustomerData, "editCustomer");


                Customer updatedCustomer = null;
                valid = ModelState.IsValidField("editCustomer");
                if (!valid)
                {
                    /* Add new Customer using Reository Add method passing the new Customer object */
                    throw new Exception("Can't update beacause invalid data");

                }

                updatedCustomer = Repo.Edit(toUpdateCustomer, newCustomerData);


                /* Check if the customer Updated */
                if (updatedCustomer == null)
                {
                    throw new Exception("Can't update the customer information");
                }

                /* select the proprties of the addedCustomer to return */
                var result = Repo.FindById(updatedCustomer.Id);
                if (result == null)
                {
                    throw new Exception("Can't post Customer");
                }
                return Json(result);

            }
            catch (Exception ex)
            {
                if (valid)
                    return BadRequest(ex.Message);
                else
                    return BadRequest(ModelState);
            }


        }


        /*
         * - TODO : this below list represent the last tasks related the following API
         * 1 - validate if user Authorized to this process
         */
        [HttpPut]
        [Route(template: "api/customers/deactivate/{id}")]
        public IHttpActionResult deactivate(int id)
        {

            bool valid = false;

            try
            {
                Customer toUpdateCustomer = Repo.FindById(id);

                if (toUpdateCustomer == null)
                {
                    throw new Exception("Customer not Found");
                }

                if (toUpdateCustomer.Status.Trim().ToUpper().Equals("INACTIVE"))
                {
                    throw new Exception("Customer is already deactivated");
                }


                Customer newCustomerData = new Customer();


                /* assing these objects using ovloaded operator in CustomerVM class */
                newCustomerData = toUpdateCustomer;

                /* make the object status "InActive" */
                newCustomerData.Status = "INACTIVE";

                /* check if the new object valid oppsite the configuration */
                Validate(newCustomerData, "editCustomer");


                Customer updatedCustomer = null;
                valid = ModelState.IsValidField("editCustomer");
                if (valid)/* if valid continue update object process */
                {
                    /* Add new Customer using Reository Add method passing the new Customer object */
                    updatedCustomer = Repo.Edit(toUpdateCustomer, newCustomerData);
                }


                /* Check if the customer Added */
                if (updatedCustomer == null)
                {
                    throw new Exception("Can't deactivate the customer record");
                }

                /* select the proprties of the addedCustomer to return */
                var result = updatedCustomer;

                return Json(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}
