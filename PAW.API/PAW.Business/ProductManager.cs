using PAW.Data.Models;

namespace PAW.Business
{
    public interface IProductManager
    {
        IEnumerable<Product> CreateProduct();
    }

    public class ProductManager : IProductManager
    {

        public ProductManager(IProductRepository productRepository)
        {
            
        }
        public IEnumerable<Product> CreateProduct()
        {
            var products = new List<Product>();
            return _productRepository.GetAll();
        }

	}
}
