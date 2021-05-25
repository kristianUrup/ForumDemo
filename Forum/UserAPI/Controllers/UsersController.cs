using System;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using UserAPI.Repository;
using UserAPI.Service;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private IRepository<User> _userRepository;

        public UsersController(IUserService userService,IRepository<User> userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            try
            {
                return Ok(_userService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public void Create(User user)
        {
            try
            {
                _userRepository.Create(user);
                Ok();
            }
            catch (Exception e)
            {
                BadRequest(e);
            }
        }

        [HttpPut]
        public void Update(User user)
        {
            try
            {
                _userRepository.Update(user);
                Ok("Success");
            }
            catch (Exception e)
            {
                BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _userRepository.Delete(id);
                Ok("Success");
            }
            catch (Exception e)
            {
                BadRequest(e);
            }
        }
    }
}