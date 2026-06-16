using Confluent.Kafka;
using Investor_Service.Exceptions;
using Investor_Service.Logger;
using Investor_Service.Models;
using Investor_Service.Service;

using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Investor_Service.Controllers
{
    [ServiceFilter(typeof(LoggingAspect))]
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly string
         bootstrapServers = "localhost:9092";
        private readonly string topic = "investor";
        private readonly IInvestorService _investorService;
        public UserController(IInvestorService investorService)
        {
            _investorService = investorService;
            


        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
            List<User> userList = _investorService.Get();
            return Ok(userList);

        }
        [HttpGet]
        [Route("/api/GetUserByEmail")]
        public ActionResult<User> GetUserByEmail(string email)
        {
            try
            {
                User users = _investorService.GetByEmail(email);
                return Ok(users);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }

        }

        [HttpGet]
        [Route("GetById")]
        public ActionResult<User> Get(string id)
        {
            try
            {
                User user = _investorService.Get(id);
                return Ok(user);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }

        }

        //[HttpPost]
        //[Route("Create")]
        //public ActionResult Create(User user)
        //{
        //    User createdUser = _investorService.Create(user);
        //    return Created("/api/created", createdUser);
        //}

        [HttpPut("{id}")]
        public ActionResult Put(string id, User user)
        {
            try
            {
                bool isUser = _investorService.Update(id, user);
                return Ok(isUser);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                bool userDeleteStatus = _investorService.Delete(id);
                return Ok(userDeleteStatus);
            }
            catch (UserNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }

        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> UploadImageProfile([FromForm] FileViewModel fileviewmodel)
        {
            if (ModelState.IsValid)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await fileviewmodel.File.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {
                        //create a AppFile mdoel and save the image into database.
                        var file = new User()
                        {
                            Name = fileviewmodel.Name,
                            LastName=fileviewmodel.LastName,
                            Contact=fileviewmodel.Contact,
                            Profession=fileviewmodel.Profession,
                            Address=fileviewmodel.Address,
                            City=fileviewmodel.City,
                            State=fileviewmodel.State,
                            Country=fileviewmodel.Country,
                            Pincode=fileviewmodel.Pincode,
                            DateofBirth=fileviewmodel.DateofBirth,
                            Gender=fileviewmodel.Gender,
                            Houseno=fileviewmodel.Houseno,
                            Streetno=fileviewmodel.Streetno,
                            Education=fileviewmodel.Education,
                            About=fileviewmodel.About,
                            work=fileviewmodel.work,
                            Category=fileviewmodel.Category,
                            Location=fileviewmodel.Location,
                            Stage=fileviewmodel.Stage,
                            Model=fileviewmodel.Model,
                            Email = fileviewmodel.Email,
                            File = memoryStream.ToArray()
                        };

                        User user = _investorService.Create(file);
                        
                        var returnData = new ReturnData();
                        returnData.Id = user.Id;
                        returnData.Name = user.Name;
                        returnData.Category = user.Category;
                        returnData.Location = user.Location;
                        returnData.Stage = user.Stage;
                        returnData.Model = user.Model;

                        string message = JsonSerializer.Serialize(returnData);
                        await SendOrderRequest(topic, message);
                        return Ok(user);

                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                }

                //var user = context.Users
                //    .Find(c => c.Name == fileviewmodel.Name).FirstOrDefault();
                ////.(c => new ReturnData()
                ////{
                ////    Name = c.Name,
                ////    ImageBase64 = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(c.Content))
                ////}).FirstOrDefault();
                //var returnData = new ReturnData();
                //returnData.Name = user.Name;
                //returnData.ImageBase64 = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(user.File));


                //return Ok(returnData);
            }
            return Ok("Invalid");
        }
        private async Task<bool> SendOrderRequest
     (string topic, string message)
        {
            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers,
                ClientId = Dns.GetHostName()
            };

            try
            {
                using (var producer = new ProducerBuilder
                <Null, string>(config).Build())
                {
                    var result = await producer.ProduceAsync
                    (topic, new Message<Null, string>
                    {
                        Value = message
                    });
                    Console.WriteLine("Data here");
                    Console.WriteLine($"Delivery Timestamp:{result.Timestamp.UtcDateTime}");
                    Debug.WriteLine($"Delivery Timestamp:{ result.Timestamp.UtcDateTime}");
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            return await Task.FromResult(false);
        }
    }




}


