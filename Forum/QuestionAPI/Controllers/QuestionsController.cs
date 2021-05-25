using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuestionAPI.Service;
using SharedModels;
using UserAPI.Repository;

namespace QuestionAPI.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IRepository<Question> _questionRepo;
        private IQuestionService _questionService;

        public QuestionsController(IRepository<Question> questionRepo, IQuestionService questionService)
        {
            _questionRepo = questionRepo;
            _questionService = questionService;
        }

        [HttpGet("{id}")]
        public ActionResult<QuestionDto> GetById(int id)
        {
            try
            {
                Console.WriteLine("hello");
                return Ok(_questionService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("GetByUserId/{userId}")]
        public ActionResult<List<Question>> GetByUserId(int userId)
        {
            try
            {
                return Ok(_questionRepo.GetAllByUserId(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Question question)
        {
            try
            {
                _questionRepo.Create(question);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _questionRepo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}