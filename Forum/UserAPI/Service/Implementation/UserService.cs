using SharedModels;
using UserAPI.Repository;

namespace UserAPI.Service.Implementation
{
    public class UserService: IService<UserDto>
    {
        private IRepository<User> _userRepo;
        private ConvertDtoHelper _converter;

        public UserService(IRepository<User> userRepo, ConvertDtoHelper converter)
        {
            _userRepo = userRepo;
            _converter = converter;
        }
        public UserDto GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(UserDto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(UserDto entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}