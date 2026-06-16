using StartupRecomendationService.Exceptions;
using StartupRecomendationService.Models;
using StartupRecomendationService.Repository;

namespace StartupRecomendationService.Service
{
    public class InvestorRecomendationService:IInvestorRecomendationService
    {
        readonly IInvestorRecomendationRepository recomendationRepository;
        public InvestorRecomendationService(IInvestorRecomendationRepository repository)   
        {
            recomendationRepository = repository;
        }

        public async Task<IEnumerable<Product>> RecomendationByCategory(string uid)
        {
            var products = await recomendationRepository.RecomendationByCategory(uid);
            if (products.Any())
            {
                return products;
            }
            else
            {
                throw new NoProductFoundWithThisCategoryException($"No product found for this Category");
            }
        }
        public async Task<IEnumerable<Product>> RecomendationByLocation(string uid)
        {
            var products = await recomendationRepository.RecomendationByLocation(uid);
            if (products.Any())
            {
                return products;
            }
            else
            {
                throw new NoProductFoundWithThisLocationException($"No product found for this Location");
            }
        }
        public async Task<IEnumerable<Product>> RecomendationByStage(string uid)
        {
            var products = await recomendationRepository.RecomendationByStage(uid);
            if (products.Any())
            {
                return products;
            }
            else
            {
                throw new NoProductFoundWithThisStageException($"No product found for this Stage");
            }
        }
        public async Task<IEnumerable<Product>> RecomendationByModel(string uid)
        {
            var products = await recomendationRepository.RecomendationByModel(uid);
            if (products.Any())
            {
                return products;
            }
            else
            {
                throw new NoProductFoundWithThisModelException($"No product found for this Model");
            }
        }
    }
}
