using Investor_Service.Models;

namespace Investor_Service.Repository
{
    public interface IUserRepository
    {
        List<User> Get();
        User Get(string id);
        User Create(User user);
        bool Update(string id, User user);
        bool Delete(string id);
        User GetByEmail(string email);
    }
}
