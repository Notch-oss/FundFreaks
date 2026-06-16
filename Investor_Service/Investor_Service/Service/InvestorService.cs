using Investor_Service.Exceptions;
using Investor_Service.Repository;
using Investor_Service.Models;

namespace Investor_Service.Service
{
    public class InvestorService : IInvestorService
    {
        private readonly IUserRepository _userRepository;
        public InvestorService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public List<User> Get()
        {
            return _userRepository.Get().ToList();
        }
        public User Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("User ID cannot be null or empty", nameof(id));
            }

            var user = _userRepository.Get(id);
            if (user == null)
            {
                throw new UserNotFoundException($"User with id: {id} does not exist");
            }
            
            return user;
        }

        public User Create(User user)
        {
            return _userRepository.Create(user);

        }

        public bool Update(string id, User user)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("User ID cannot be null or empty", nameof(id));
            }

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            // This will throw UserNotFoundException if user doesn't exist
            Get(id);
            
            return _userRepository.Update(id, user);
        }

        public bool Delete(string id)
        {
            User user = Get(id);
            
            if (user!=null)
            {
                return _userRepository.Delete(id);
               
            }
            else
            {
                throw new UserNotFoundException($"User with id: {id} does not exist");
            }
        }
        public User GetByEmail(string email)
        {
            User isUserExist = _userRepository.GetByEmail(email);
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
