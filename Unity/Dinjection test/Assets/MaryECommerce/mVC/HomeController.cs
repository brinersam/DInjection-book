using System.Collections.Generic;
using UnityEngine;
using Mary.Data;
using Mary.Domain;

namespace Mary.MVC
{
public class HomeController : MonoBehaviour
{
    [SerializeField] GameObject _productListingPrefab;
    private bool _isAfterStart = false;

    void Start()
    {
        RenderPage();
        _isAfterStart = true;
    }

    void OnEnable()
    {
        if (!_isAfterStart)
            return;
        
        RenderPage();
    }

    void OnDisable()
    {
        foreach(Transform child in transform)
            Destroy(child.gameObject);
    }

    public void RenderPage()
    {
        foreach (Product i in Index())
        {
            var obj = Instantiate(_productListingPrefab,transform);
            obj.GetComponent<ProductListing>().Initialize($"{i.Name} ({i.UnitPrice:C})");
        }
    }

    public IEnumerable<Product> Index()
    {
        bool isCustomerPreferred = UserData.I.IsInRole(UserRole.PreferredCustomer);
        var service = new ProductService();
        return service.GetFeaturedProducts(isCustomerPreferred);
    }
}
}