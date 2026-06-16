using StartupRecomendationService.Models;

namespace StartupRecomendationService.Service
{
    public interface IInvestorRecomendationService
    {
        Task<IEnumerable<Product>> RecomendationByCategory(string uid);
        Task<IEnumerable<Product>> RecomendationByModel(string uid);
        Task<IEnumerable<Product>> RecomendationByStage(string uid);
        Task<IEnumerable<Product>> RecomendationByLocation(string uid);
    }

}
