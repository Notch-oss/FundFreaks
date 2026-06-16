using UserAuthenticationService.Models;

namespace UserAuthenticationService.Service
{
    public interface IUserService
    {
        List<RegisterUser> GetAllUsers();
        int AddUser(RegisterUser user);
        RegisterUser DeleteUser(string email);
        int Update(string email, RegisterUser user);
        bool FormatCheck(Login request);
    }
}
