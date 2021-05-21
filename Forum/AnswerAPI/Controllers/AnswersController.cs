using System;
using System.Collections.Generic;
using System.Linq;
using AnswerAPI.Repository;
using AnswerAPI.Repository.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace AnswerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswersController : Controller
    {
        private IRepository<Answer> _answerRepo;

        public AnswersController(IRepository<Answer> answerRepo)
        {
            _answerRepo = answerRepo;
        }
        [HttpGet("/GetAllAnswersByUserId/{userId}")]
        public ActionResult<List<Answer>> GetAllAnswersByUserId(int userId)
        {
            try
            {
                return Ok(_answerRepo.GetAllByUserId(userId).ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("/GetAllAnswersByQuestionId/{questionId}")]
        public ActionResult<Answer> GetAllAnswersByQuestionId(int questionId)
        {
            try
            {
                return Ok(_answerRepo.GetAllByQuestionId(questionId));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Create(Answer answer)
        {
            try
            {
                return Ok("It is succesfully created");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}