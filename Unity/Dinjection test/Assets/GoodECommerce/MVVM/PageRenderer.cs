using UnityEngine;
using EComShared.View;
using System.Globalization;

using ECom.Data;
using ECom.Domain;
using ECom.Module.CurrencyConverter;
using ECom.Module.CurrencyConverterAPI;

namespace ECom.MVVM
{
    public class PageRenderer : MonoBehaviour
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
            HomeController ctrller = NewCompositionRoot();
            foreach (ProductViewModel i in ctrller.Index())
            {
                var obj = Instantiate(_productListingPrefab,transform);
                obj.GetComponent<ProductListing>().Initialize($"{i.SummaryText})");
            }
        }

        private HomeController NewCompositionRoot()
        {
            RegionInfo homeRegion = new RegionInfo("en-US");
            RegionInfo userRegion = new RegionInfo("en-US"); // get it from user data todo

            return new HomeController
                    (
                        new ProductService
                        (
                            new CommerceDBContext(null),
                            new UserContextAdapter(),
                            discountMod: 0.50m,
                            new CurrencyConverter
                            (
                                homeRegion,
                                new FreeCurrencyAPI()
                            ),
                            userRegion // userRegion
                        ),
                        new CultureInfo("en-US") // also userRegion, fuck
                    );
        }
    }
}