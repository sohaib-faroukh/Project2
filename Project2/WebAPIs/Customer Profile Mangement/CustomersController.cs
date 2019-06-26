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

namespace Project2.WebAPIs.Customer_Profile_Mangement
{
    public class CustomersController : ApiController
    {
        CustomerRepo Repo = new CustomerRepo();


        [HttpGet]
        [Route(template: "api/customers")]
        public IHttpActionResult getAll()
        {

            try
            {

                var selectResult = Repo.GetAll().Select(ele => new
                {
                    Id = ele.Id,
                    Name = ele.FirstName + " " + ele.LastName,
                    ISPN = ele.ISPN,
                    Status = ele.Status,
                    Address = ele.Address,

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
                    Name = ele.FirstName + " " + ele.LastName,
                    ISPN = ele.ISPN,
                    Status = ele.Status,
                    Address = ele.Address,

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


        [HttpPost]
        [Route(template: "api/customers")]
        public IHttpActionResult post(CustomerVM Customer)
        {

            bool valid = false;
            try
            {
                /* validate */


                Customer newCustomer = new Customer();



                /* assing these objects using ovloaded operator in CustomerVM class */
                newCustomer = Customer;

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
                var result = addedCustomer;
                //    new {
                //    Id = addedCustomer.Id,
                //    Name = addedCustomer?.FirstName + " " + addedCustomer?.LastName,
                //    ISPN = addedCustomer?.ISPN,
                //    Status = addedCustomer?.Status,
                //    Address = addedCustomer?.Address,

                //    Numbers = addedCustomer.Numbers.Select(num => new
                //    {
                //        num.Id,
                //        num.PhoneNumber,
                //    }).ToList(),


                //    Services = addedCustomer.Services.Select(srv => new
                //    {
                //        srv.Id,
                //        srv.Name,
                //        srv.Status,
                //        ServiceTypeName = srv.ServiceType.Name,
                //    }).ToList(),

                //};

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

        [HttpPut]
        [Route(template: "api/customers/{id}")]
        public IHttpActionResult put(int id,CustomerVM _Customer)
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
                if (valid)
                {
                    /* Add new Customer using Reository Add method passing the new Customer object */
                    updatedCustomer = Repo.Edit(toUpdateCustomer,newCustomerData);
                }


                /* Check if the customer Added */
                if (updatedCustomer == null)
                {
                    throw new Exception("Can't add the survey");
                }

                /* select the proprties of the addedCustomer to return */
                var result = updatedCustomer;

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

    }
}
