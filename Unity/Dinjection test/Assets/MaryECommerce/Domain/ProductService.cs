using System.Collections.Generic;
using Mary.Data;

namespace Mary.Domain
{
public class ProductService
{
    private readonly CommerceDBContext _context;
    public ProductService() 
    {
        _context = new CommerceDBContext();
    }

    public IEnumerable<Product> GetFeaturedProducts(bool isCustomerPreferred)
    {
        decimal discount = isCustomerPreferred ? 0.95m : 1;

        foreach (var i in _context.DB_Read("SELECT * FROM Products WHERE IsFeatured = 1"))
        {
            yield return ApplyDiscount(i, discount);
        }
    }

    private Product ApplyDiscount(Product prdct, decimal discount)
    {
        prdct.UnitPrice *= discount;
        return prdct;
    }
}
}