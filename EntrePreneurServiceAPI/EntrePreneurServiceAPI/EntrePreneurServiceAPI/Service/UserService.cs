using EntrePreneurServiceAPI.Exceptions;
using EntrePreneurServiceAPI.Models;
using EntrePreneurServiceAPI.Repository;

namespace EntrePreneurServiceAPI.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userService;
        public UserService(IUserRepository userService)
        {
            _userService = userService;
        }

        public User Create(User user)
        {
            User IsuserAlreadyExist = _userService.Get(user.Id);
            if (IsuserAlreadyExist == null)
            {
                return _userService.Create(user);
            }
            else
            {
                throw new UserAlreadyExistException($"User with Id:{user.Id} already exists");
            }
        }

        public bool Delete(string id)
        {
            User user = Get(id);

            if (user != null)
            {
                return _userService.Delete(id);

            }
            else
            {
                throw new UserNotFoundException($"User with id: {id} does not exist");
            }
        }

        public List<User> Get()
        {
            return _userService.Get().ToList();
        }

        public User Get(string id)
        {
            User isUserExist = _userService.Get(id);
            if (isUserExist != null)
            {
                return _userService.Get(id);
            }
            else
            {
                throw new UserNotFoundException($"User with id: {id} does not exist");
            }

        }

        public bool Put(string id, User user) //Update instead of Put also does the same
        {
            User isuser = Get(id);
            if (isuser != null)
            {
                return _userService.Update(id, user);
            }
            else
            {
                throw new UserNotFoundException($"User with id: {user.Id} does not exist");
            }
        }

        public User GetByName(string firstname)
        {
            User isUserExist = _userService.GetByName(firstname);
            if (isUserExist != null)
            {
                return isUserExist;
            }
            else
            {
                throw new UserNotFoundException($"User with name: {firstname} does not exist");
            }

        }

        public User GetByEmail(string email)
        {
            User isUserExist = _userService.GetByEmail(email);
            if (isUserExist != null)
            {
                return isUserExist;
            }
            else
            {
                throw new UserNotFoundException($"User with email :{email} does not exist");
            }
        }
    }
}
