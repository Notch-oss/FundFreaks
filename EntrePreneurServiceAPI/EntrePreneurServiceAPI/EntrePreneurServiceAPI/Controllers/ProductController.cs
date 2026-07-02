using EntrePreneurServiceAPI.Exceptions;
using EntrePreneurServiceAPI.Models;
using EntrePreneurServiceAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Confluent.Kafka;
using System.Net;
using System.Diagnostics;

namespace EntrePreneurServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly string
        bootstrapServers = "localhost:9092";
        private readonly string topic = "product";
        private readonly IProductService _productController;
        public ProductController(IProductService productController)
        {
            _productController = productController;

        }
        [HttpGet]
        [Route("/api/GetAllProducts")]
        public ActionResult Get()
        {
            List<Product> productList = _productController.Get();
            return Ok(productList);

        }


        [HttpGet]
        [Route("/api/GetProductsById")]
        public ActionResult<Product> Get(string id)
        {
            try
            {
                Product product = _productController.Get(id);
                return Ok(product);
            }
            catch (ProductNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }

        }


        [HttpGet]
        [Route("/api/GetProductByEmail")]
        public ActionResult<Product> GetProductByEmail(string email)
        {
            try
            {
                List<Product> products = _productController.GetByEmail(email);
                return Ok(products);
            }
            catch (ProductNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }

        }

        //[HttpPost]
        //[Route("CreateProduct")]

        [HttpPut("{id}")]
        public ActionResult Put(string id, Product product)
        {
            try
            {
                bool isProduct = _productController.Update(id, product);
                return Ok(isProduct);
            }
            catch (ProductNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                bool prductDeleteStatus = _productController.Delete(id);
                return Ok(prductDeleteStatus);
            }
            catch (ProductNotFoundException unfe)
            {
                return NotFound(unfe.Message);
            }

        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductFileViewModel fileviewmodel)
        {

            if (ModelState.IsValid)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await fileviewmodel.ImageFile.CopyToAsync(memoryStream);
                    using (var ms = new MemoryStream())
                    {
                        await fileviewmodel.PdfFile.CopyToAsync(ms);
                        if (memoryStream.Length < 4097152 && ms.Length < 4097152)
                        {
                            //create a AppFile mdoel and save the image into database.
                            var file = new Product()
                            {
                                Title = fileviewmodel.Title,
                                Category = fileviewmodel.Category,
                                Location = fileviewmodel.Location,
                                Stage = fileviewmodel.Stage,
                                 Owners = fileviewmodel.Owners,
                                SharePrice = fileviewmodel.SharePrice,
                                BusinessModel = fileviewmodel.BusinessModel,
                                Description = fileviewmodel.Description,
                                Email = fileviewmodel.Email,
                                // Date = fileviewmodel.Date,
                                ImageFile = memoryStream.ToArray(),
                                PdfFile = ms.ToArray(),

                            };
                            Product product = _productController.Create(file);
                            Console.WriteLine($"Id:{product.ProductId}");
                            var returnData = new ProductReturnData();
                            returnData.ProductId = product.ProductId;
                            returnData.Title = product.Title;
                            returnData.Category = product.Category;
                            returnData.Location = product.Location;
                            returnData.Stage = product.Stage;
                            returnData.BusinessModel = product.BusinessModel;
                            string message = JsonSerializer.Serialize(returnData);
                            return Ok(await SendOrderRequest(topic, message));
                        }
                        else
                        {
                            ModelState.AddModelError("File", "The file is too large.");
                        }

                    }
                }
            }
            return Ok("Invalid");
        }
        [HttpGet]
        [Route("DownloadPdf")]
        public IActionResult DownloadPdf(string id)
        {
          Product product =  _productController.Get(id);
            byte[] pdf = product.PdfFile;
            return Ok(pdf);
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
