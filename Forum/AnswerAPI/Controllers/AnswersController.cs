using System;
using System.Collections.Generic;
using System.Linq;
using AnswerAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AnswerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswersController : Controller
    {
        private readonly IRepository<Answer> _answerRepo;

        public AnswersController(IRepository<Answer> answerRepo)
        {
            _answerRepo = answerRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Answer>> GetAll()
        {
            try
            {
                return Ok(_answerRepo.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("/GetAllAnswersByUserId/{userId}")]
        public ActionResult<List<Answer>> GetAllAnswersByUserId(int userId)
        {
            try
            {
                var result = _answerRepo.GetAllByUserId(userId).ToList();
                Console.WriteLine(result);
                return Ok(_answerRepo.GetAllByUserId(userId).ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("/GetAllAnswersByQuestionId/{questionId}")]
        public ActionResult<List<Answer>> GetAllAnswersByQuestionId(int questionId)
        {
            try
            {
                return Ok(_answerRepo.GetAllByQuestionId(questionId).ToList());
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