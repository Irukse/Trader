using HelpTrader.Models;

namespace HelpTrader.Services;

public class BrokerDataService : IBrokerDataService
{
    private readonly ISimulatorBrokerClient _client;

    public BrokerDataService(ISimulatorBrokerClient client)
    {
        _client = client;
    }

    public async Task<BrokerData> AnalysisShare()
    {
        // HttpClient client = new HttpClient();
        // var responseTask = client.GetAsync("https://localhost:5000/BrokerData");
        // responseTask.Wait();
        //
        //     var result = responseTask.Result;
        //
        //         var data = result.Content.ReadFromJsonAsync<BrokerData>();
     
        var data = await _client.GetData<BrokerData?>();

            var brokerData  = new BrokerData()
            {
                Price = data.Price,
                Share = data.Share,
                RequestDate = data.RequestDate
            };
            return brokerData;
        }
    
    public async Task<BrokerData> AnalysisForShare(string share)
    {
        var data = await _client.GetDataForShare<BrokerData>(share);

        var brokerData  = new BrokerData()
        {
            Price = data.Price,
            Share = data.Share,
            RequestDate = data.RequestDate
        };
        return brokerData;
    }
}