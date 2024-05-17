using System.Collections.Generic;

//using ECom.Data; // no coupling - good

namespace ECom.Domain
{
    public class ProductService
    {
        private decimal _discountMod;
        private readonly IDataContext _context;
        private UserInfo _user;
        public ProductService(IDataContext context, UserInfo user, decimal discountMod) 
        {
            _context = context;
            _discountMod = discountMod;
            _user = user;
        }

        public IEnumerable<Product> GetFeaturedProducts()
        {
            decimal discount = _user.IsPreferred ? _discountMod : 1;

            foreach (var i in _context.GetProducts(x => x.IsFeatured))
            {
                yield return i.ApplyDiscount(discount);
            }
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