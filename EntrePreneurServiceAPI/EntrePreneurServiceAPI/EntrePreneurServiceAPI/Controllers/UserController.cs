using EntrePreneurServiceAPI.Exceptions;
using EntrePreneurServiceAPI.Models;
using EntrePreneurServiceAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace EntrePreneurServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userController;
        public UserController(IUserService userController)
        {
            _userController = userController;

        }
        [HttpGet]
        [Route("/api/GetAllUser")]
        public ActionResult Get()
        {
            List<User> userList = _userController.Get();
            return Ok(userList);

        }


        [HttpGet]
        [Route("/api/GetUserById")]
        public ActionResult<User> Get(string id)
        {
            try
            {
                User user = _userController.Get(id);
                return Ok(user);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }

        }

        //[HttpPost]
        //[Route("CreateUser")]
        //public ActionResult Create(User user)
        //{
        //    User createdUser = _userController.Create(user);
        //    return Created("/api/UserCreated", createdUser);
        //}

        [HttpPut("{id:length(24)}")]
        public ActionResult Put(string id, User user)
        {
            try
            {
                bool isUser = _userController.Put(id, user);//Update instead of Put also does the same
                return Ok(isUser);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            try
            {
                bool userDeleteStatus = _userController.Delete(id);
                return Ok(userDeleteStatus);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }

        }

        [HttpGet]
        [Route("/api/GetUserByEmail")]
        public ActionResult<User> GetUserByEmail(string email)
        {
            try
            {
                User users = _userController.GetByEmail(email);
                return Ok(users);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }

        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> UploadImageProfile([FromForm] EntrepreneurFileviewModel fileviewmodel)
        {
            if (ModelState.IsValid)                          
            {
                using (var memoryStream = new MemoryStream())
                {
                    await fileviewmodel.Img.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 4097152)
                    {
                        //create a AppFile mdoel and save the image into database.
                        var file = new User()
                        {
                            FirstName = fileviewmodel.FirstName,
                            LastName = fileviewmodel.LastName,
                            Contact = fileviewmodel.Contact,
                            Profession = fileviewmodel.Profession,
                            Gender = fileviewmodel.Gender,
                            City = fileviewmodel.City,
                            State = fileviewmodel.State,
                            Country = fileviewmodel.Country,
                            Pincode = fileviewmodel.Pincode,
                            DateofBirth = fileviewmodel.DateofBirth,
                            AddressLine1 = fileviewmodel.AddressLine1,
                            HouseNo = fileviewmodel.HouseNo,
                           Email = fileviewmodel.Email,
                            Education = fileviewmodel.Education,
                            About = fileviewmodel.About,
                            Work = fileviewmodel.Work,

                            Img = memoryStream.ToArray()
                        };

                        User ent=_userController.Create(file);
                        //context.SaveChanges();
                        return Ok(ent);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                }
            }
            return Ok("Invalid");
        }
    }
}
