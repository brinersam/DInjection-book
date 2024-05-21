using System.Collections.Generic;
using System.Globalization;

//using ECom.Data; // no coupling - good

namespace ECom.Domain
{
    public class ProductService : IProductService
    {
        private decimal _discountMod;
        private readonly IProductRepository _context;
        private readonly IUserContext _user;
        private readonly ICurrencyConverter _converter;
        private readonly RegionInfo _region;

        public ProductService(
                IProductRepository context,
                IUserContext user,
                decimal discountMod,
                ICurrencyConverter converter,
                RegionInfo region) 
        {
            _context = context;
            _discountMod = discountMod;
            _user = user;
            _converter = converter;
            _region = region;
        }

        public IEnumerable<Product> GetFeaturedProducts()
        {
            decimal discount = _user.IsInRole(UserRole.PreferredCustomer) ? _discountMod : 1;

            foreach (var i in _context.GetFeaturedProducts())
            {
                yield return i.ApplyDiscount(discount).ConvertCurrency(_region, _converter);
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
        public static Product ConvertCurrency(this Product prdct, RegionInfo targetCurrency, ICurrencyConverter converter)
        {
            prdct.UnitPrice = converter.Convert(prdct.UnitPrice, targetCurrency.ISOCurrencySymbol);
            return prdct;
        }
    }
}