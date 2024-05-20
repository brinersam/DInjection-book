using System.Collections.Generic;

using ECom.Domain;

namespace ECom.MVVM
{
    public class HomeController
    {
        private IProductService _service;
        
        public HomeController(IProductService service)
        {
            _service = service;
        }

        public IEnumerable<ProductViewModel> Index()
        {
            foreach (Product product in _service.GetFeaturedProducts())
                yield return new ProductViewModel(product.Name,product.UnitPrice);
        }
    }
}