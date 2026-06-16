using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using StartupRecomendationService.Exceptions;
using StartupRecomendationService.Models;
using StartupRecomendationService.Service;

namespace StartupRecomendationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorRecomendationController : ControllerBase
    {
        readonly IInvestorRecomendationService _recomendationService;
        private readonly IGraphClient _client;
        public InvestorRecomendationController(IInvestorRecomendationService recomendationService, IGraphClient client)
        {
            _recomendationService = recomendationService;
            _client = client;

        }
        //[HttpGet]
        //[Route("/api/products")]
        //public async Task<IActionResult> Get()
        //{
        //    var products = await _client.Cypher.Match("(p:Product)")
        //        .Return(p => p.As<Product>()).ResultsAsync;
        //    return Ok(products);
        //}
        //[HttpPost]
        //[Route("/api/relation/{uid}")]
        //public async Task<IActionResult> Relation(string uid)
        //{
        //   var investor =await  _client.Cypher.Match("(i:User)").Where((User i) => i.Id == uid).Return(i => i.As<User>()).ResultsAsync;

        //  await  _client.Cypher.Match("(p:Product),(i:User)")
        //                      .Where((User i, Product p) => i.Id == investor.FirstOrDefault().Id && p.Category == investor.FirstOrDefault().Category)
        //                      .Create("(i)-[r:sameCategory]->(p)")
        //                      .ExecuteWithoutResultsAsync();

        //  await  _client.Cypher.Match("(p:Product),(i:User)")
        //      .Where((User i, Product p) => i.Id == investor.First().Id && p.Location == investor.First().Location)
        //      .Create("(i)-[r:sameLocation]->(p)")
        //      .ExecuteWithoutResultsAsync();

        //   await  _client.Cypher.Match("(p:Product),(i:User)")
        //     .Where((User i, Product p) => i.Id == investor.First().Id && p.Stage == investor.First().Stage)
        //     .Create("(i)-[r:sameStage]->(p)")
        //     .ExecuteWithoutResultsAsync();

        //   await  _client.Cypher.Match("(p:Product),(i:User)")
        //      .Where((User i, Product p) => i.Id == investor.First().Id && p.BusinessModel == investor.First().Model)
        //      .Create("(i)-[r:sameModel]->(p)")
        //      .ExecuteWithoutResultsAsync();
        //    return Ok("Relations Created");
        //}
        
        [HttpGet]
        [Route("/api/investorRecomendation/category/{uid}")]
        public async Task<IActionResult> GetByCategory(string uid)
        {
            try
            {
                var products = await _recomendationService.RecomendationByCategory(uid);
                return Ok(products);
            }
            catch (NoProductFoundWithThisCategoryException niex)
            {
                return NotFound(niex.Message);
            }
        }
        [HttpGet]
        [Route("/api/investorRecomendation/location/{uid}")]
        public async Task<IActionResult> GetByLocation(string uid)
        {
            try
            {
                var products = await _recomendationService.RecomendationByLocation(uid);
                return Ok(products);
            }
            catch (NoProductFoundWithThisLocationException niex)
            {
                return NotFound(niex.Message);
            }
        }
        [HttpGet]
        [Route("/api/investorRecomendation/stage/{uid}")]
        public async Task<IActionResult> GetByStage(string uid)
        {
            try
            {
                var products = await _recomendationService.RecomendationByStage(uid);
                return Ok(products);
            }
            catch (NoProductFoundWithThisStageException niex)
            {
                return NotFound(niex.Message);
            }
        }
        [HttpGet]
        [Route("/api/investorRecomendation/model/{uid}")]
        public async Task<IActionResult> GetByModel(string uid)
        {
            try
            {
                var products = await _recomendationService.RecomendationByModel(uid);
                return Ok(products);
            }
            catch (NoProductFoundWithThisModelException niex)
            {
                return NotFound(niex.Message);
            }
        }
    }
}
