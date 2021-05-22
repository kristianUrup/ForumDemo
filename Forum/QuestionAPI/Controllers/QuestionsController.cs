using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Repository;

namespace QuestionAPI.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IRepository<Question> _questionRepo;

        public QuestionsController(IRepository<Question> questionRepo)
        {
            _questionRepo = questionRepo;
        }

        [HttpGet("{id}")]
        public ActionResult<Question> GetById(int id)
        {
            try
            {
                return Ok(_questionRepo.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("/GetByUserId/{userId}")]
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