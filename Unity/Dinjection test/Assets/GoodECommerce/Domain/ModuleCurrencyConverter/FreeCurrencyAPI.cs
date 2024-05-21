using UnityEngine.Networking;
using System.Globalization;

using ECom.Module.CurrencyConverter;


namespace ECom.Module.CurrencyConverterAPI
{
    public class FreeCurrencyAPI : ICurrencyAPI
    {
        private const int _TIMEOUTSEC = 5;
        private const string _APIURL = "";
        private const string _APIKEY = "";

        public FreeCurrencyAPI() {}

        public decimal Request(string startCurrency, string goalCurrency)
        {
            return ParseResponse(GetRequest(goalCurrency));
        }

        private string GetRequest(string goalCurrency)
        {
            using (UnityWebRequest request = UnityWebRequest.Get($"{_APIURL}apikey={_APIKEY}&currencies={goalCurrency}"))
            {
                request.timeout = _TIMEOUTSEC;
                request.SendWebRequest();

                while (!request.isDone) 
                {
                    // if i were to write this async,
                    // i think i'd have to drag async all the way up to the consumer
                    // and i really dont care enough to do that
                }
                
                switch (request.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.ProtocolError:
                    case UnityWebRequest.Result.DataProcessingError:
                    {
                        throw new System.Exception($"Something went wrong: {request.error}");
                    }
                    case UnityWebRequest.Result.Success:
                    {
                        break;
                    }
                }
                return request.downloadHandler.text;
            }
        }

        private decimal ParseResponse(string json) 
        {
            int colonIdx = 0;
            for (int i = 0; i < json.Length; i++)
            {
                if (json[i] == ':')
                    colonIdx = i;
            }
            string result = json.Substring(colonIdx+1);
            result = result.Remove(result.Length-2);
            return decimal.Parse(result, CultureInfo.InvariantCulture);
        }
    }
}