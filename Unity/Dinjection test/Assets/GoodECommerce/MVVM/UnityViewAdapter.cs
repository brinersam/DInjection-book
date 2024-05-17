using System.Collections.Generic;

using ECom.Domain;

namespace ECom.MVVM // implements the domain interface but where do i use this then erm
{
    public class UnityViewAdapter : IViewAdapter<ProductViewModel>
    {
        public UnityViewAdapter()
        {
            
        }

        public IEnumerable<ProductViewModel> ViewAdapter(IEnumerable<Product> products)
        {
            foreach (Product product in products)
                yield return new ProductViewModel(product.Name,product.UnitPrice);
        }
    }
}