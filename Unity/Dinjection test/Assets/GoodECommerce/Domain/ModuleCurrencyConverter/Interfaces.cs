namespace ECom.Module.CurrencyConverter
{
    public interface ICurrencyAPI
    {
        public decimal Request(string startCurrency, string goalCurrency);
    }
}