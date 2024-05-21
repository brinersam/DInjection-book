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
            string homeCultureString = "en-US";
            IUserContext userContext = new UserContextAdapter();

            return new HomeController
                    (
                        new ProductService
                        (
                            new CommerceDBContext(null),
                            userContext,
                            discountMod: 0.50m,
                            new CurrencyConverter
                            (
                                new RegionInfo(homeCultureString),
                                new FreeCurrencyAPI()
                            )
                        ),
                        userContext.CultureInfo
                    );
        }
    }
}