using EntrePreneurServiceAPI.Models;

namespace EntrePreneurServiceAPI.Repository
{
    public interface IUserRepository
    {
        List<User> Get();
        User Get(string id);
        User Create(User user);
        bool Update(string id, User user);
        bool Delete(string id);
        User GetByName(string firstname);

        User GetByEmail(string email);
    }
}
