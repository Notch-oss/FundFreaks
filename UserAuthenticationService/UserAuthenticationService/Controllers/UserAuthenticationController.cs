using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using UserAuthenticationService.Logging;
using UserAuthenticationService.Models;
using UserAuthenticationService.Repository;
using UserAuthenticationService.Service;
using BCrypt.Net;


namespace UserAuthenticationService.Controllers
{
    //[ServiceFilter(typeof(Logger))]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly FundFreaksUsersContext _context;
        public readonly IUserRepository _userRepository;
        public readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        
        public UserAuthenticationController(FundFreaksUsersContext context, IUserRepository userRepository, IUserService userService,IConfiguration configuration)
        {
            _context = context;
            _userRepository = userRepository;
            _userService = userService;
            _configuration = configuration;
            
        }

        [HttpGet]
        [Route("Users")]
        public async Task<IActionResult> getUsers()
        {
            try
            {
                var users = await Task.Run(() => _userService.GetAllUsers());
                if (users != null && users.Any())
                {
                    return Ok(users);
                }
                return Ok("no users yet");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            try
            {
                //user email and password pattern validation
                //_userService.FormatCheck();
                
                var res = await Task.Run(() => _userService.AddUser(user));
                
                if(res > 0)
                {
                    var userL = new Login
                    {
                        Email = user.Email,
                        Password = user.Password
                    };
                    
                    string token = CreateToken(userL);
                    var response = new ResponseToken
                    {
                        Token = token,
                        Email = user.Email,
                        Role = user.Role
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest(new { message = "User was not registered" });
                }

               // if (res > 0)
               // { 
               //return Ok(new { message = "User Added Successfully" });
               //}
               // else
               // {
               //     return Ok(new { message = "User was not registered" });
               // }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login(Login request)
        {
            bool isFormat=_userService.FormatCheck(request);
            if (isFormat)
            {
                RegisterUser? emailExist = _context.RegisterUsers.Where(u => u.Email == request.Email).FirstOrDefault();
                if (emailExist.Email != request.Email)
                {
                    return BadRequest("User not Found");
                }
                if (!BCrypt.Net.BCrypt.Verify(request.Password, emailExist.Password))
                {
                    return BadRequest("Wrong Password");
                }
                
                string token = CreateToken(request);

                ResponseToken response = new ResponseToken();
                response.Role = emailExist.Role;
                response.Token = token;
                response.Email = request.Email;
                return Ok(response);
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(string email)
        {
            try
            {
                RegisterUser delUser = _userService.DeleteUser(email);
                return Ok(delUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(string email, RegisterUser user)
        {
            int res = _userService.Update(email, user);
            if (res > 0)
            {
                return Ok(new { message = "User Updated Successfully" });
            }
            else
            {
                return Ok(new { message = "user not found" });
            }
        }
        private string CreateToken(Login user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Email)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            
            return jwt;
        }
       

    }
}
