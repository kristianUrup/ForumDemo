using System.Collections.Generic;
using SharedModels;

namespace UserAPI.Repository
{
    public class UserRepository: IRepository<User>

    {
        public IEnumerable<User> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}