   using StartupRecomendationService.Models;

namespace StartupRecomendationService.Repository
{
    public interface IInvestorRecomendationRepository
    {
        Task<IEnumerable<Product>> RecomendationByCategory(string uid);
        Task<IEnumerable<Product>> RecomendationByModel(string uid);
        Task<IEnumerable<Product>> RecomendationByStage(string uid);
        Task<IEnumerable<Product>> RecomendationByLocation(string uid);

    }
}
