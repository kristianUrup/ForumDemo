using System;
using System.Collections.Generic;
using System.IO;
using SharedModels;
using UserAPI.Repository;
using UserAPI.Service.Messaging;

namespace UserAPI.Service.Implementation
{
    public class UserService : IUserService
    {
        private ConvertDtoHelper _converter;
        private IRepository<User> _userRepo;
        private IMessagePublisher _messagePublisher;

        public UserService(IRepository<User> userRepo, IMessagePublisher messagePublisher)
        {
            _userRepo = userRepo;
            _converter = new ConvertDtoHelper();
            _messagePublisher = messagePublisher;
        }

        public UserDto GetById(int id)
        {
            var user = _userRepo.GetById(id);
            var questions = _messagePublisher.GetQuestionByUserIdMessage(id);
            if (questions == null)
            {
                throw new InvalidDataException("The questions were not found");
            }

            return _converter.ConvertToUserDto(user, questions, new List<AnswerDto>());
        }

        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}