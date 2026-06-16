using System.Text.RegularExpressions;
using UserAuthenticationService.Exceptions;
using UserAuthenticationService.Models;
using UserAuthenticationService.Repository;
using BCrypt.Net;

namespace UserAuthenticationService.Service
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        string[] roleArray = new string[] { "entrepreneur", "investor"};
        

        public int AddUser(RegisterUser user)
        {
            RegisterUser userExist = _userRepository.GetUserByEmail(user);
            if (userExist == null)
            {
                bool isEmail = Regex.IsMatch(user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
                bool isPwrd = Regex.IsMatch(user.Password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

                if (isEmail == false)
                {
                    throw new InvalidEmailException("Invalid email entered");

                }
                if (isPwrd == false)
                {
                    throw new InvalidPasswordException("Password should contain at least 8 characters, at least one number and one letter.");
                }
                if (user.ConfirmPassword != user.Password)
                {
                    throw new PasswordDoesNotMatch("Passwords dont match");
                }
                
                else
                {
                    foreach (string role in roleArray)
                    {
                        if (user.Role.ToLower() == role)
                        {
                            // Hash the password before storing
                            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                            return _userRepository.AddUser(user);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    throw new RoleException("Choose Role as either entrepreneur or investor");
                }
                
            }
            else
            {
                throw new UserAlreadyExistsException("User Already exists.");
            }
        }

        public RegisterUser DeleteUser(string email)
        {
            RegisterUser userExist=_userRepository.FindUserByEmail(email);
            if(null != userExist)
            {
                _userRepository.DeleteUser(userExist);
                return userExist;
            }
            else
            {
                //custom exception
                throw new UserNotFoundException("User not found");
            }
        }

        public List<RegisterUser> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

       

        public int Update(string email,RegisterUser newInfo)
        {
            RegisterUser upUser=_userRepository.FindUserByEmail(email);
            if(upUser != null)
            {
                upUser.Password = newInfo.Password;
                int res=_userRepository.Update(upUser);
                return res;
            }
            return 0;

        }

        public bool FormatCheck(Login request)
        {
            bool isEmail = Regex.IsMatch(request.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            bool isPwrd = Regex.IsMatch(request.Password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

            if (isEmail == false)
            {
                throw new InvalidEmailException("Invalid email entered");

            }
            if (isPwrd == false)
            {
                throw new InvalidPasswordException("Password should contain at least 8 characters, at least one number and one letter.");
            }
            else
            {
                return true;
            }
        }
    }
}
