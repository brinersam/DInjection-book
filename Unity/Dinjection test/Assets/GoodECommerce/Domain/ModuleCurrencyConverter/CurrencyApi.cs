using UnityEngine.Networking;
using UnityEngine;
using System.Threading.Tasks;

using ECom.Module.CurrencyConverter;


namespace ECom.Module.CurrencyConverterAPI
{
    public class FreeCurrencyAPI : ICurrencyAPI
    {
        private const string _APIURL = "key";
        private const string _APIKEY = "url";

        public FreeCurrencyAPI() {}

        public decimal Request(decimal moneys, string startCurrency, string goalCurrency) // a reqiest per field is fucked : use converison rates todo
        {
            Task task = GetRequest(); // https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
            int loopbreakre = 2000;
            while (loopbreakre-- > 0 && task.Status == TaskStatus.Running)
            {
                Debug.Log($"task in progress! : {task.Status}");
            }
            Debug.Log($"task completed! : {task.Status}"); // how to pull the result out of it? static field?
            //ReadResponse(request.downloadHandler.text);
            return 2;
        }

        private async Task<UnityWebRequest> GetRequest() // wtf is async // https://forum.unity.com/threads/async-webrequest-and-await-in-the-script-where-data-is-needed.1312056/
        {
            using (UnityWebRequest request = UnityWebRequest.Get(_APIURL))
            {
                request.SendWebRequest();
                await Task.Yield(); // https://www.reddit.com/r/dotnet/comments/qoycwn/struggling_a_bit_with_understanding_async/
                
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
                return request;
            }
        }

        private void ReadResponse(string json) 
        {
            throw new System.Exception($"{json}"); // https://stackoverflow.com/questions/13517792/deserializing-json-with-dynamic-keys
        }
    }

}