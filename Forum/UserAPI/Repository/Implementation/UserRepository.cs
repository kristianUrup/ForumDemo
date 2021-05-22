using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository
{
    public class UserRepository : IRepository<User>

    {
        private readonly UserApiContext _ctx;

        public UserRepository(UserApiContext userApiContext)
        {
            _ctx = userApiContext;
        }

        public User GetById(int id)
        {
            return _ctx.Users.FirstOrDefault(user => user.Id == id);
        }

        public void Create(User entity)
        {
            _ctx.Users.Attach(entity).State = EntityState.Added;
            _ctx.SaveChanges();
        }

        public void Update(User entity)
        {
            _ctx.Users.Attach(entity).State = EntityState.Modified;
            _ctx.Remove(new User {Id = entity.Id});
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            _ctx.Users.Remove(new User {Id = id});
            _ctx.SaveChanges();
        }
    }
}