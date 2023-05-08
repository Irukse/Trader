using HelpTrader.Models;

namespace HelpTrader.Services;

public class BrokerDataService : IBrokerDataService
{
    public BrokerData AnalysisShare()
    {
        HttpClient client = new HttpClient();
        var responseTask = client.GetAsync("https://localhost:5000/BrokerData");
        responseTask.Wait();
        // if (responseTask.IsCanceled)
        // {
            var result = responseTask.Result;
            // if (result.IsSuccessStatusCode)
            // {
                var data = result.Content.ReadFromJsonAsync<BrokerData>();

               var brokerData  = new BrokerData()
                {
                    Price = data.Result.Price,
                    Share = data.Result.Share

                };
                return brokerData;
                    //  }
        //}

  
    }
}