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
using System.Web.Http.Cors;
using CustomerProfileBank.Models.Repositories;

namespace Project2.WebAPIs.Survey_Management
{
    [EnableCors("*", "*", "*")]
    public class SurveysManagementController : ApiController
    {
        SurveyRepo sRepo = new SurveyRepo();
        private List<dynamic> errorsList = new List<dynamic>();

        [HttpGet]
        [Route("api/Surveys")]
        public IHttpActionResult getAll()
        {
            var res = sRepo.GetAll().Select(ele => new
            {
                ele.Id,
                ele.Name,
                ele.FromDate,
                ele.ToDate,
                ele.Description,
                ele.Status,
                ele.CreatorId,
                ele.CreationDate,
                ele.ValidiatyMonthlyPeriod,
                CreatorName = ele.Creator.FirstName + " " + ele.Creator.LastName,
                Questions = ele.Questions.Select(ques => new
                {
                    ques.Question.Id,
                    ques.Question.Text,
                    ques.Order,
                    CategoryId = ques.Question.CategoryId,
                    ques.Question.Category.Name,
                    ques.Question.Status,
                    ques.IsMandatory,
                })
            }).ToList();
            return Json(res);
        }


        [HttpGet]
        [Route("api/Surveys/{id}")]
        public IHttpActionResult getById(int id)
        {
            var ele = sRepo.FindById(id);
            var res = new
            {
                ele.Id,
                ele.Name,
                ele.FromDate,
                ele.ToDate,
                ele.Description,
                ele.Status,
                ele.CreatorId,
                ele.CreationDate,
                ele.ValidiatyMonthlyPeriod,
                CreatorName = ele.Creator.FirstName + " " + ele.Creator.LastName,
                Questions = ele.Questions.Select(ques => new
                {
                    ques.Question.Id,
                    ques.Question.Text,
                    ques.Order,
                    ques.Question.Status,
                    ques.IsMandatory,
                })
            };
            return Json(res);
        }


        /*
         * - Fix put 
         */


        [HttpPut]
        [Route("api/Surveys/put/{id}")]
        public IHttpActionResult put(int id, Survey newSurvey)
        {
            bool valid = false;

            try
            {
                Survey toUpdateSurvey = sRepo.FindById(id);
                if (toUpdateSurvey == null)
                {
                    throw new Exception("Can't find the selected survey");
                }

                /* if there are any deffirent Survey have the same new name */
                var toCheckTheNameIsUniqe = sRepo.FindBy(a => a.Id != id && a.Name.Trim().ToUpper() == newSurvey.Name.Trim().ToUpper());

                /* new Survey name isn't uniqe */
                if (toCheckTheNameIsUniqe != null)
                {
                    throw new Exception("new survey name is duplicated");
                }

                newSurvey.Id = id;

                /* check if the new object valid oppsite the configuration */
                Validate(newSurvey, "editSurvey");


                Survey updatedSurvey = null;
                valid = ModelState.IsValidField("editSurvey");
                if (valid)
                {
                    /* Add new Survey using Reository Add method passing the new Survey object */
                    updatedSurvey = sRepo.Edit(toUpdateSurvey, newSurvey);

                }

                /* Check if the Survey updated */
                if (updatedSurvey == null)
                {
                    throw new Exception("Can't update the survey information");
                }
                /* select the proprties of the addedCustomer to return */
                var result = updatedSurvey;

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
         * - Fix post 
         */

        [HttpPost]
        [Route("api/Surveys/post")]
        public IHttpActionResult post(Survey newSurvey)
        {
            bool valid = false;
            Survey toAddSurvey = new Survey();

            try
            {
                /* copy new survey data */
                toAddSurvey = newSurvey;

                /* Survey Creator define */
                if (newSurvey.CreatorId != 0)
                {
                    User Creator = new UserRepo().FindById(newSurvey.CreatorId);
                    if (Creator != null)
                    {
                        toAddSurvey.Creator = Creator;
                    }
                }

                /* make the current machine data is the creation date */
                toAddSurvey.CreationDate = DateTime.Now;

                List<Question> Questions = new List<Question>();
                QuestionRepo quesRepo = new QuestionRepo();

                if (newSurvey.Questions != null && newSurvey.Questions.Count > 0)
                {
                    foreach (var ques in newSurvey.Questions)
                    {
                        SurveyQuestion new_ = new SurveyQuestion();
                        new_ = ques;


                    }
                }

                return Json(new { });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /*
         * - Fix delete 
         */

        [HttpDelete]
        [Route("api/Surveys/{id}")]
        public IHttpActionResult delete(int id)
        {
            //Survey survey = db.Surveys.Find(id);
            //if (survey == null)
            //{
            //    return NotFound();
            //}

            //db.Surveys.Remove(survey);
            //db.SaveChanges();

            return Ok();
        }

    }
}