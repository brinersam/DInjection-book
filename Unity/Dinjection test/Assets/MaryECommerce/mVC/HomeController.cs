using System.Collections.Generic;
using UnityEngine;
using Mary.Data;
using Mary.Domain;
using System.IO;
using System.Linq;

namespace Mary.MVC
{
public class HomeController : MonoBehaviour
{
    [SerializeField] GameObject _productListingPrefab;
    private bool _earlyCall = true;

    void Start()
    {
        RenderPage();
        _earlyCall = false;
    }

    void OnEnable()
    {
        if (_earlyCall) { return; }
        
        RenderPage();
    }

    void OnDisable()
    {
        foreach(Transform child in transform)
            Destroy(child.gameObject);
    }

    private void RenderPage()
    {
        foreach (Product i in Index())
        {
            var obj = Instantiate(_productListingPrefab,transform);
            obj.GetComponent<ProductListing>().Initialize($"{i.Name} ({i.UnitPrice:C})");
        }
    }

    private IEnumerable<Product> Index()
    {
        bool isCustomerPreferred = UserData.I.IsInRole(UserRole.PreferredCustomer);
        var service = new ProductService();
        return service.GetFeaturedProducts(isCustomerPreferred);
    }
}
}