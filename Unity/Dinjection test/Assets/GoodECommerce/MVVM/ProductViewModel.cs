using System.Collections.Generic;
using System.Globalization;

namespace ECom.MVVM
{
    public struct ProductViewModel
    {
        private static CultureInfo _priceCulture = new CultureInfo("en-US");
        
        public string SummaryText {get;}

        public ProductViewModel(string name, decimal unitPrice)
        {
            SummaryText = string.Format(_priceCulture, "{0} ({1:C})", name,unitPrice);
        }
    }


}