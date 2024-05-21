using System.Globalization;
using ECom.Domain;

namespace ECom.Module.CurrencyConverter
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private RegionInfo _baseRegion;
        private ICurrencyAPI _api;

        public CurrencyConverter(RegionInfo baseRegion, ICurrencyAPI api)
        {
            _baseRegion = baseRegion;
            _api = api;
        }

        public decimal GetExchangeRate(string goalCurrencyISO)
        {
            return _api.Request(_baseRegion.ISOCurrencySymbol, goalCurrencyISO);
        }
    }
}