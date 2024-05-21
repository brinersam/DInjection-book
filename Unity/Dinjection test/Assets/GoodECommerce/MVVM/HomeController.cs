using System.Collections.Generic;
using System.Globalization;

using ECom.Domain;

namespace ECom.MVVM
{
    public class HomeController
    {
        private IProductService _service;
        private CultureInfo _culture;
        
        public HomeController(IProductService service, CultureInfo culture)
        {
            _service = service;
            _culture = culture;
        }

        public IEnumerable<ProductViewModel> Index()
        {
            foreach (Product product in _service.GetFeaturedProducts())
                yield return new ProductViewModel(product.Name,product.UnitPrice, _culture);
        }
    }
}