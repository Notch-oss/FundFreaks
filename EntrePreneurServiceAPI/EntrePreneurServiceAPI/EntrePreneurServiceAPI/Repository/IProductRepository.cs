using EntrePreneurServiceAPI.Models;

namespace EntrePreneurServiceAPI.Repository
{
    public interface IProductRepository
    {
        List<Product> Get();
        Product Get(string id);
        List<Product> GetByEmail(string email);
        Product Create(Product product);
        bool Update(string id, Product product);
        bool Delete(string id);
    }
}
