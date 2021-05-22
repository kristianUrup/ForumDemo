using System;
using SharedModels;
using UserAPI.Repository;

namespace UserAPI.Service.Implementation
{
    public class UserService : IService<UserDto>
    {
        private ConvertDtoHelper _converter;
        private IRepository<User> _userRepo;

        public UserService(IRepository<User> userRepo, ConvertDtoHelper converter)
        {
            _userRepo = userRepo;
            _converter = converter;
        }

        public UserDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}