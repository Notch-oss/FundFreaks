using UserAuthenticationService.Models;

namespace UserAuthenticationService.Repository
{
    public interface IUserRepository
    {
        List<RegisterUser> GetAllUsers();
        RegisterUser GetUserByEmail(RegisterUser user);
        int AddUser(RegisterUser user);
        RegisterUser DeleteUser(RegisterUser user);
        RegisterUser FindUserByEmail(string email);
        int Update(RegisterUser upUser);
    }
}
