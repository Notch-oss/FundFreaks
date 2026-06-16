using Investor_Service.Models;

using MongoDB.Driver;

namespace Investor_Service.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly UserContext context;
        public UserRepository(UserContext _context)
        {
            context = _context;
        }
        public User Create(User user)
        {
            context.Users.InsertOneAsync(user);
            
            return user;

        }

        public bool Delete(string id)
        {
           
           
            context.Users.DeleteOneAsync(user => user.Id == id);
            return true;
           
            
             
        }

        public List<User> Get()
        {
            return context.Users.Find<User>(u => true).ToList();
           
        }

        public User Get(string id)
        {
            return context.Users.Find<User>(u => u.Id == id).FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return context.Users.Find<User>(p => p.Email == email).FirstOrDefault();
        }

        public bool Update(string id, User user)
        {
            context.Users.UpdateOneAsync<User>(u => u.Id == id, user.Id);
            return true;
        }
    }
}
