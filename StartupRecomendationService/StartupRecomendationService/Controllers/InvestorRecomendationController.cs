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
        //[HttpPost]
        //[Route("/api/relation/{uid}")]




        
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
