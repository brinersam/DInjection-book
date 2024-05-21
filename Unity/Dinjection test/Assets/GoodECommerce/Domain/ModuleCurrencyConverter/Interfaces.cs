namespace ECom.Module.CurrencyConverter
{
    public interface ICurrencyAPI
    {
        public decimal Request(decimal moneys, string startCurrency, string goalCurrency);
    }
}