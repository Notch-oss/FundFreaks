using EntrePreneurServiceAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EntrePreneurServiceAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _product;

        public ProductRepository(IOptions<ProductDatabaseSetting> productDatabaseSetting)
        {
            var client = new MongoClient(productDatabaseSetting.Value.ConnectionString);
            var database = client.GetDatabase(productDatabaseSetting.Value.DatabaseName);
            _product = database.GetCollection<Product>(productDatabaseSetting.Value.CollectionName);
        }
        public Product Create(Product product)
        {
            _product.InsertOneAsync(product);
            return product;
        }

        public bool Delete(string id)
        {
            _product.DeleteOneAsync(product => product.ProductId == id);
            return true;
        }

        public List<Product> Get()
        {
            return _product.Find<Product>(p => true).ToList();
        }

        public Product Get(string id)
        {
            return _product.Find<Product>(p => p.ProductId == id).FirstOrDefault();
        }

        public List<Product> GetByEmail(string email)
        {
            return _product.Find<Product>(p => p.Email == email).ToList();
        }
        public bool Update(string id, Product product)
        {
            _product.UpdateOneAsync<Product>(p => p.ProductId == id, product.ProductId);
            return true; ;
        }
    }
    
}
