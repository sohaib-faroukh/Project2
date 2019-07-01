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
using CustomerProfileBank.Models.Helpers;

namespace Project2.WebAPIs.Survey_Management
{
    [EnableCors("*", "*", "*")]
    public class SurveysManagementController : ApiController
    {
        SurveyRepo sRepo = new SurveyRepo();
        private List<dynamic> errorsList = new List<dynamic>();

        /// <summary>
        /// get all surveys configuration
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// return survey configuration 
        /// </summary>
        /// <param name="id">survey id</param>
        /// <returns></returns>
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
                    Id = ques.Question.Id,
                    IsMandatory = ques.IsMandatory,
                    Text = ques.Question.Text,
                    Type = ques.Question.Type,
                    Order = ques.Order,
                    Category = ques.Question.Category.Name,
                    ParentOptionId = ques.Question.ParentOptionId,
                    ParentQuestionId = ques.Question.ParentQuestionId,
                    Options = ques.Question.Options.Select(op => new
                    {
                        op.Id,
                        op.IsDefault,
                        op.Order,
                        op.Text,
                    }).OrderBy(op => op.Order).ToList()

                }).OrderBy(ques => ques.Order).ToList()
            };
            return Json(res);
        }



        /// <summary>
        /// edit existing survey configuration
        /// </summary>
        /// <param name="id">to edit survey id</param>
        /// <param name="newSurvey">the new configuration</param>
        /// <returns></returns>
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


        

        /// <summary>
        /// add new survey configuration 
        /// </summary>
        /// <param name="newSurvey">new survey instance</param>
        /// <returns></returns>
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


        

        /// <summary>
        /// delete survey API
        /// </summary>
        /// <param name="id">survey id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/Surveys/delete/{id}")]
        public IHttpActionResult delete(int id)
        {

            try
            {
                var res = sRepo.FindById(id);
                if (res == null)
                {
                    throw new Exception("Can't find the survey");
                }

                if (!isAnswered(id))
                {
                    throw new Exception("the proccess failed because Can't remove the answered surveys");
                }

                var dRes = sRepo.Delete(id);
                if (dRes == false)
                {
                    throw new Exception();
                }
                return Json(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        /// <summary>
        /// get not responding survey by customer based on his NationalNumber
        /// </summary>
        /// <param name="NationalNumber">Customer identity National Number</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Surveys/answer/{NationalNumber}")]

        public IHttpActionResult getSurveyToRespond(string NationalNumber)
        {
            try
            {
                if (!Helper.isAllCharsDigits(NationalNumber))
                {
                    throw new Exception("Invalid National Number");
                }

                CustomerRepo CR = new CustomerRepo();

                Customer Customer = CR.Context.Customers
                    .FirstOrDefault(ele => ele.NationalNumber.Trim() == NationalNumber.Trim() || ele.ISPN.Trim() == NationalNumber.Trim());
                if (Customer == null)
                {
                    throw new Exception("can't find the customer");
                }

                //get surveys ids that the customer have answered

                List<int> ids = CR.Context.SurveyResponses.Where(ele => ele.Customer.Id == Customer.Id)
                    .Select(ele => ele.SurveyId).ToList<int>();

                // select sureys that aren't answered by this customer

                List<Survey> Surveys = CR.Context.Surveys.Where(ele => !ids.Contains(ele.Id)).ToList();


                #region returned result
                var customer = new
                {
                    Customer.Id,
                    Customer.NationalNumber,
                    Customer.ISPN,
                    Customer.FirstName,
                    Customer.LastName,
                };
                var survey = Surveys.Select(ele => new
                {
                    ele.Id,
                    ele.Name,
                    ele.Status,
                    ele.ToDate,
                    ele.FromDate,
                    ele.ValidiatyMonthlyPeriod,
                    Questions = ele.Questions.Select(ques => new
                    {
                        Id = ques.Question.Id,
                        IsMandatory = ques.IsMandatory,
                        Text = ques.Question.Text,
                        Type = ques.Question.Type,
                        Order = ques.Order,
                        Category = ques.Question.Category.Name,
                        ParentOptionId = ques.Question.ParentOptionId,
                        ParentQuestionId = ques.Question.ParentQuestionId,
                        Options = ques.Question.Options.Select(op => new
                        {
                            op.Id,
                            op.IsDefault,
                            op.Order,
                            op.Text,
                        }).OrderBy(op => op.Order).ToList()

                    }).OrderBy(ques => ques.Order).ToList()
                }).OrderByDescending(ele=>ele.Questions.Count).FirstOrDefault();
                #endregion

                return Json(new { customer, survey });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// API : submit survey response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Surveys/sendResponse")]
        public IHttpActionResult submitSurveyResponse(ResponseVM response)
        {
            try
            {

                #region validation
                Survey Survey = sRepo.FindById(response.SurveyId);
                Customer Customer = new CustomerRepo().FindById(response.CustomerId);

                if (Survey == null)
                {
                    throw new Exception("this Survey isn't exist");
                }

                if (Customer == null)
                {
                    throw new Exception("this Customer isn't exist");
                }

                var Answers = response?.Answers;

                if (Answers == null || Answers.Count == 0)
                {
                    throw new Exception("there are not answers");
                }
                #endregion

                SurveyResponse surveyResponse = new SurveyResponse();

                surveyResponse.CustomerId = Customer.Id;
                surveyResponse.SurveyId = Survey.Id;
                surveyResponse.RespondDateTime = DateTime.Now;

                SurveyResponseRepo SRR = new SurveyResponseRepo();

                var addedSurveyResponse = SRR.Add(surveyResponse);

                if (addedSurveyResponse == null)
                {
                    throw new Exception("can't post the response");
                }


                AnswerRepo AR = new AnswerRepo();

                List<Answer> insertedAnswers = new List<Answer>();
                List<string> insertedAnswersErrors = new List<string>();
                foreach (var ans in Answers)
                {
                    Answer answer = new Answer();
                    answer.SurveyResponseId = addedSurveyResponse.Id;
                    answer.QuestionId = ans.Id;

                    #region extract answer text 

                    Type type = ans.answer.GetType();

                    if (
                        ans.Type.Trim().ToUpper().Equals("OPEN")
                        && ans.answer != null
                        )
                    {
                        answer.Text = ans.answer;
                    }
                    else if (
                        ans.Type.Trim().ToUpper().Equals("SINGLESELECT")
                        && ans.answer != null
                        )
                    {
                        answer.Text = ans.answer.ToString();
                    }
                    else if (
                        ans.Type.Trim().ToUpper().Equals("MULTISELECT")
                        && ans.answer != null
                        && ans.answer.Count > 0
                        )
                    {
                        string answerText = "|";
                        foreach (var c in ans.answer)
                        {
                            answerText += c + ";";
                        }
                        answerText += "|";

                        answer.Text = answerText;
                    }
                    #endregion

                    var tempRes = AR.Add(answer);
                    if (tempRes != null)
                    {
                        insertedAnswers.Add(tempRes);
                    }
                    else
                    {
                        insertedAnswersErrors.Add("can't post answer with the question id : " + ans.Id);
                    }

                }

                return Json(new { insertedAnswers, insertedAnswersErrors });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// check if the survey with the given id is answerd regardless who answerd and return boolean value
        /// </summary>
        /// <param name="id">Survey id</param>
        /// <returns></returns>
        public bool isAnswered(int id)
        {
            if (sRepo.FindById(id) == null)
            {
                throw new Exception("Can't found the survey");
            }

            SurveyResponseRepo SRRepo = new SurveyResponseRepo();
            var result = SRRepo.FindBy(ele => ele.SurveyId == id);

            if (result != null)
            {
                return true;
            }
            return false;
        }

    }



    /// <summary>
    /// View Model response class helps to recive the Interface response data
    /// </summary>
    public class ResponseVM
    {
        public int SurveyId { get; set; }
        public int CustomerId { get; set; }

        public List<AnswerVM> Answers { get; set; }

    }

    /// <summary>
    /// View Model answer class helps to recive the Interface answer data into response class
    /// </summary>
    public class AnswerVM
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public dynamic answer { get; set; }

    }
}
