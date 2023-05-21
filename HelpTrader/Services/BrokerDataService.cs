using System.Threading.Tasks.Dataflow;
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

        var data = await _client.GetDataForShare<BrokerData?>();

        var brokerData = new BrokerData()
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

        var brokerData = new BrokerData()
        {
            Price = data.Price,
            Share = data.Share,
            RequestDate = data.RequestDate
        };
        return brokerData;
    }

    // //  я хочу, чтобы мой метод параллельно зашел в другой сервис, формируя строку подключения для каждой акции
    // // записал ответ в модель, затем добавил в лист в любом порядке
    // public Task<List<BrokerData>> GetListShareAsync(List<string> share)
    // {
    //     var brokerDataList = new List<BrokerData>();
    //     Parallel.ForEach(share, async s =>
    //     {
    //         var data = await _client.GetDataForShareAsync<BrokerData>(s);
    //         if (data == null) return;
    //         var brokerData = new BrokerData()
    //         {
    //             Price = data.Price,
    //             Share = data.Share,
    //             RequestDate = data.RequestDate
    //         };
    //         brokerDataList.Add(brokerData);
    //     });
    //     return Task.FromResult(brokerDataList);
    // }

    //work method олучение фиджи по абревиатуре акции
    public  Task<List<ShareData>> GetListDataFigiShareAsync(List<string> share)
    {
        var shareDataList = new List<ShareData>();
        Parallel.ForEach(share, async s =>
        {
            var data = await _client.GetDataFigiForShareAsync<List<string>>(s);
                if (data == null) return;
                // возможно не успевает записать 
                var brokerData = new ShareData()
                {
                    NameShare = data[0],
                    Figi = data[1],
                };
                shareDataList.Add(brokerData);
                
            //записать в бд
        });
        return Task.FromResult(shareDataList);
    }

    // //work method 
    // public async Task<SharePrice> GetPriceShareAsync(string figi)
    // {
    //     //первым делом заходит в рэдис и пытается получить кэш данных
    //     
    //     var data = await _client.GetPriceForShareAsync<decimal>(figi);
    //     var brokerData = new SharePrice()
    //     {
    //         Figi = figi,
    //         Price = data,
    //     };
    //     //записать в бд
    //     return brokerData;
    // }
    
    //work method получение цены по фиджи
    public async Task<List<SharePrice>> GetPriceShareListAsync(List<string> figiList)
    {
        var brokerDataList = new List<SharePrice>();
        //первым делом заходит в рэдис и пытается получить кэш данных
        
        Parallel.ForEach(figiList, async figi =>
        {
            var data = await _client.GetPriceForShareAsync<decimal>(figi);
            var brokerData = new SharePrice()
            {
                Figi = figi,
                Price = data,
            };
            brokerDataList.Add(brokerData);
        });
        
        return brokerDataList;
    }
    
    //акая-то логика получения истиной стоимости
    public async Task<List<DataAnalysisShare>> GetAnalysisShareAsync(List<string> share)
    {
        var dataAnalysisShareList = new List<DataAnalysisShare>();
        var shareData = await GetListDataFigiShareAsync(share);
        
        var figiList = shareData.Select(x => x.Figi).ToList();
        
        var sharePrice = await GetPriceShareListAsync(figiList);

        var dataAnalysisShares = from sd in shareData
            join cp in sharePrice on sd.Figi equals cp.Figi
            select new  { Name = sd.NameShare, Price = cp.Price };

        foreach (var VARIABLE in dataAnalysisShares)
        {
            var dataAnalysisShare = new DataAnalysisShare()
            {
                Name = VARIABLE.Name,
                Price = VARIABLE.Price,
                FairPrice = VARIABLE.Price * 3,
            };
            dataAnalysisShareList.Add(dataAnalysisShare);
        }
        // foreach (var emp in employees)
        //     Console.WriteLine($"{emp.Name} - {emp.Company} ({emp.Language})");
        return dataAnalysisShareList;
    }

}


