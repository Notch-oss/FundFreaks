using EntrePreneurServiceAPI.Models;

namespace EntrePreneurServiceAPI.Service
{
    public interface IUserService
    {
        List<User> Get();
        User Get(string id);
        User Create(User user);
        bool Put(string id, User user);//Update instead of Put also does the same
        bool Delete(string id);

        User GetByName(string firstname);

        User GetByEmail(string email);
    }
}
