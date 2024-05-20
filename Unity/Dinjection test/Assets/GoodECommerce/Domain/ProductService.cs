using System.Collections.Generic;

//using ECom.Data; // no coupling - good

namespace ECom.Domain
{
    public class ProductService : IProductService
    {
        private decimal _discountMod;
        private readonly IProductRepository _context;
        private IUserContext _user;
        public ProductService(IProductRepository context, IUserContext user, decimal discountMod) 
        {
            _context = context;
            _discountMod = discountMod;
            _user = user;
        }

        public IEnumerable<Product> GetFeaturedProducts()
        {
            decimal discount = _user.IsInRole(UserRole.PreferredCustomer) ? _discountMod : 1;

            foreach (var i in _context.GetFeaturedProducts()) //x => x.IsFeatured
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