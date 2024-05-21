using System.Collections.Generic;
using System.Globalization;

namespace ECom.Domain
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetFeaturedProducts();
    }

    public interface IProductService
    {
        public IEnumerable<Product> GetFeaturedProducts();
    }

    public interface ICurrencyConverter
    {
        public decimal Convert(decimal moneys, string goalCurrency);
        //public RegionInfo CurrentRegion
    }

    // public interface IDataContext
    // {
    //     // book diverts: says its best to use repository pattern aka just get the data, and filtering
    //     //      and such should be in domain, but wont that ignore sql optimizations in favor 
    //     //      of whatever implementation happens instead?
    //     public IEnumerable<Product> GetProducts(Func<Product,bool> predicate = null);
    // }
}