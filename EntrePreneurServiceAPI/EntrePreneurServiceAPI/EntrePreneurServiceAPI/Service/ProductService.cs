using EntrePreneurServiceAPI.Exceptions;
using EntrePreneurServiceAPI.Models;
using EntrePreneurServiceAPI.Repository;

namespace EntrePreneurServiceAPI.Service
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productService;
        public ProductService(IProductRepository productService)
        {
            _productService = productService;
        }
        public Product Create(Product product)
        {
            return _productService.Create(product);
        }

        public bool Delete(string id)
        {
            Product product = Get(id);

            if (product != null)
            {
                return _productService.Delete(id);

            }
            else
            {
                throw new ProductNotFoundException($"User with id: {id} does not exist");
            }
        }

        public List<Product> Get()
        {
            return _productService.Get().ToList();
        }

        public Product Get(string id)
        {
            Product isProductExist = _productService.Get(id);
            if (isProductExist != null)
            {
                return _productService.Get(id);
            }
            else
            {
                throw new ProductNotFoundException($"Product with id: {id} does not exist");
            }
        }
        public List<Product> GetByEmail(string email)
        {
            List<Product> isProductExist = _productService.GetByEmail(email);
            if (isProductExist != null)
            {
                return isProductExist;
            }
            else
            {
                throw new ProductNotFoundException($"Product with email :{email} does not exist");
            }
        }

        public bool Update(string id, Product product)
        {
            Product isuser = Get(id);
            if (isuser != null)
            {
                return _productService.Update(id, product);
            }
            else
            {
                throw new ProductNotFoundException($"Product with id: {product.ProductId} does not exist");
            }
        }
    }
}
