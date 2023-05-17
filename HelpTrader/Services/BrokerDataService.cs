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
        var data = await _client.GetDataForShareAsync<BrokerData>(share);

        var brokerData  = new BrokerData()
        {
            Price = data.Price,
            Share = data.Share,
            RequestDate = data.RequestDate
        };
        return brokerData;
    }
    
    //  я хочу, чтобы мой метод параллельно зашел в другой сервис, формируя строку подключения для каждой акции
    // записал ответ в модель, затем добавил в лист в любом порядке
    public Task<List<BrokerData>> GetListShareAsync(List<string> share)
    {
        var brokerDataList = new List<BrokerData>();
        Parallel.ForEach(share, async s =>
        {
            var data = await _client.GetDataForShareAsync<BrokerData>(s);
            var brokerData = new BrokerData()
            {
                Price = data.Price,
                Share = data.Share,
                RequestDate = data.RequestDate
            };
            brokerDataList.Add(brokerData);
        });
        return Task.FromResult(brokerDataList);
    }
}