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
        public IHttpActionResult GetSurveys()
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
        public IHttpActionResult GetSurvey(int id)
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


        [HttpPut]
        [Route("api/Surveys/{id}")]
        public IHttpActionResult PutSurvey(int id, Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != survey.Id)
            {
                return BadRequest();
            }

            //db.Entry(survey).State = EntityState.Modified;

            try
            {
                //db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }



        [HttpPost]
        [Route("api/Surveys")]
        public IHttpActionResult PostSurvey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Surveys.Add(survey);
            //db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = survey.Id }, survey);
        }



        [HttpDelete]
        [Route("api/Surveys/{id}")]
        public IHttpActionResult DeleteSurvey(int id)
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