using HelpTrader.Domain.Dto;
using HelpTrader.Services.Application.Manager.Repository;
using Tinkoff.InvestApi;
using Tinkoff.InvestApi.V1;
using Tinkoff.Trading.OpenApi.Network;

namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Context for <inheritdoc cref="ShareFigiInformationStory"/>
/// </summary>
public record ShareFigiInformationStoryContext : IStoryContext<ShareFigiInformationResponse>
{
    public List<string> Shares { get; init; }
}

/// <summary>
/// Story for get figi
/// </summary>
public class ShareFigiInformationStory : BaseStory<ShareFigiInformationStoryContext, ShareFigiInformationResponse>
{
    private readonly ISimulatorBrokerClient _client;
    private readonly IRedisRepository _repository;
    private readonly InvestApiClient _investApiClient;
    public ShareFigiInformationStory(ISimulatorBrokerClient client, IRedisRepository repository, InvestApiClient investApiClient)
    {
        _client = client;
        _repository = repository;
        _investApiClient = investApiClient;
    }

    /// <inheritdoc />
    protected override async Task<ShareFigiInformationResponse> DoAsync(ShareFigiInformationStoryContext context)
    {
        
      //  var token = "my.token";
// для работы в песочнице используйте GetSandboxConnection
    //    var connection = ConnectionFactory.GetSandboxConnection(token);
       // var contextTin = connection.Context;
       // var portfolio = await contextTin.PortfolioAsync();
       
        var response = new ShareFigiInformationResponse() { };
        var sharesData = new List<ShareData>();

        foreach (var share in context.Shares)
        {
            var dataFromCash = await _repository.GetBasket<ShareData>(share);

            if (dataFromCash != null)
            {
                sharesData.Add((ShareData)dataFromCash);
            }

            else
            {
                /////////////
                var instrumentForInfoAboutShare = new InstrumentRequest()
                {
                    IdType = InstrumentIdType.Ticker,
                    Id = "CNX",
                    ClassCode = "SPBXM"
                };
                var bbbb = _investApiClient.Instruments.ShareBy(instrumentForInfoAboutShare);
                
                
               // var data = await _client.GetDataFigiForShareAsync<List<string>>(share);
                var d = _investApiClient.Instruments.Shares();
                

                var getLastPricesRequest = new GetLastPricesRequest
                {
                    InstrumentId = { "BBG000CKVSG8" }
                };
                var g = _investApiClient.MarketData.GetLastPrices(getLastPricesRequest);
                //от брокера получаем сообщение такого формата:
                // {
                //"ticket" : "SBER",
                //"figi" : "BBG004730N88",
                //"name" : "Сбер Банк",
                //"type" : "stock",
                //"currency" : "RUB",
                //"source" : "TINKOFF"
                // }
                var brokerData = new ShareData()
                {
                 //   Ticker = data[0],
                 //   Figi = data[1],
                };
                sharesData.Add(brokerData);
                await _repository.UpdateBasket(share, brokerData);
            }
        }

        response.Shares = sharesData;

        return response;
    }
}