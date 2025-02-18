using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Data.Models;

namespace PAW.Mvc.Controllers
{
    public abstract class MainController : Controller
    {
        private readonly IProductManager _productManager;

        public MainController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IEnumerable<Product> GetMyProduct => _productManager.CreateProduct();
    }
}
