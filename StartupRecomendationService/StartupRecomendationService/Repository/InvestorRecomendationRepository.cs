using Neo4jClient;
using Newtonsoft.Json.Linq;
using StartupRecomendationService.Models;

namespace StartupRecomendationService.Repository
{
    public class InvestorRecomendationRepository:IInvestorRecomendationRepository
    {
       
        private readonly IGraphClient _client;
        
        public InvestorRecomendationRepository(IGraphClient client)
        {
         
            _client = client;
        }
        public async Task<IEnumerable<Product>> RecomendationByCategory(string uid)
        {
            var products = await _client.Cypher.Match("(i:User)-[rel:sameCategory]->(p:Product)")
                                                   .Where((User i) => i.Id == uid).Return(p => p.As<Product>()).ResultsAsync;
            return products;
        }
        public async Task<IEnumerable<Product>> RecomendationByLocation(string uid)
        {
            var products = await _client.Cypher.Match("(i:User)-[rel:sameLocation]->(p:Product)")
                                                   .Where((User i) => i.Id == uid).Return(p => p.As<Product>()).ResultsAsync;
            return products;
        }
        public async Task<IEnumerable<Product>> RecomendationByStage(string uid)
        {
            var products = await _client.Cypher.Match("(i:User)-[rel:sameStage]->(p:Product)")
                                                   .Where((User i) => i.Id == uid).Return(p => p.As<Product>()).ResultsAsync;
            return products;
        }
        public async Task<IEnumerable<Product>> RecomendationByModel(string uid)
        {
            var products = await _client.Cypher.Match("(i:User)-[rel:sameModel]->(p:Product)")
                                                   .Where((User i) => i.Id == uid).Return(p => p.As<Product>()).ResultsAsync;
            return products;
        }
    }
}
