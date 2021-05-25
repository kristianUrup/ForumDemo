using SharedModels;

namespace UserAPI.Service
{
    public interface IUserService
    {
        UserDto GetById(int id);
        void Create(User entity);
        void Update(User entity);
        void Delete(int id);
    }
}