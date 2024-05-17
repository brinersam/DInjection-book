using System.Collections.Generic;
using UnityEngine;
using EComShared.View;

using ECom.Data; // this shouldnt be a dependency, but since i cant really put the boot in domain, this has to do until it clicks for me
using ECom.Domain; // this is ok

namespace ECom.MVVM
{
    public class HomeController : MonoBehaviour
    {
        [SerializeField] GameObject _productListingPrefab;
        private bool _earlyCall = true;

#region Irrelevant

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
#endregion
        
        private void RenderPage()
        {
            foreach (ProductViewModel i in Index())
            {
                var obj = Instantiate(_productListingPrefab,transform);
                obj.GetComponent<ProductListing>().Initialize($"{i.SummaryText})");
            }
        }

        private IEnumerable<ProductViewModel> Index()
        {
            var service = new ProductService // how do i fit this in service and then send data here? i cant just instantiate a monobeh from service
            (
                new CommerceJSONContext(null),
                new UserInfo(UserData.I.IsInRole(UserRole.PreferredCustomer)),
                discountMod: .50m
            );

            return new UnityViewAdapter().ViewAdapter(service.GetFeaturedProducts());
            //Debug.LogWarning("Stub used!"); // todo
            //return new List<ProductViewModel>(){new ProductViewModel ("SpaceCola", 6.23m), new ProductViewModel ("SpaceRamen", 50)};
            //bool isCustomerPreferred = UserData.I.IsInRole(UserRole.PreferredCustomer);
            //var service = new ProductService();
            //return service.GetFeaturedProducts();
        }
    }
}