using System.Collections.Generic;
using Mary.Data;

namespace Mary.Domain
{
    public class ProductService
    {
        private readonly CommerceDBContext _context;
        private readonly CommerceJSONContext _jcontext;
        public ProductService() 
        {
            _context = new CommerceDBContext();
            _jcontext = new CommerceJSONContext();
        }

        public IEnumerable<Product> GetFeaturedProducts(bool isCustomerPreferred)
        {
            decimal discount = isCustomerPreferred ? 0.95m : 1;
            
            foreach (var i in _jcontext.JSON_Read(x => !x.IsFeatured))
            {
                yield return i.ApplyDiscount(discount);
            }

            // foreach (var i in _context.DB_Read("SELECT * FROM Products WHERE IsFeatured = 1"))
            // {
            //     yield return i.ApplyDiscount(discount);
            // }
        }
    }

    static class ProductExtensions
    {
        public static Product ApplyDiscount(this Product prdct, decimal discount)
        {
            prdct.UnitPrice *= discount;
            return prdct;
        }
    }

}