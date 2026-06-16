using UserAuthenticationService.Models;

namespace UserAuthenticationService.Repository
{
    public class UserRepository : IUserRepository
    {
        FundFreaksUsersContext _dbContext;
        public UserRepository(FundFreaksUsersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddUser(RegisterUser user)
        {
            _dbContext.RegisterUsers.Add(user);
            int res=_dbContext.SaveChanges();
            return res;
        }

        public RegisterUser DeleteUser(RegisterUser user)
        {
            _dbContext.RegisterUsers.Remove(user);
            _dbContext.SaveChanges();
            return user;
        }

        public RegisterUser FindUserByEmail(string email)
        {
            return _dbContext.RegisterUsers.Where(u => u.Email == email).FirstOrDefault();
        }

        public List<RegisterUser> GetAllUsers()
        {
            return _dbContext.RegisterUsers.ToList();
        }

        public RegisterUser GetUserByEmail(RegisterUser user)
        {
            return _dbContext.RegisterUsers.Where(u => u.Email == user.Email).FirstOrDefault();
        }

        public int Update(RegisterUser upUser)
        {
            _dbContext.RegisterUsers.Update(upUser);
            int res = _dbContext.SaveChanges();
            return res;
        }
    }
}
