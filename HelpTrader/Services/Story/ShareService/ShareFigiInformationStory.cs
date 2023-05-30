using HelpTrader.Domain.Dto;
using HelpTrader.Services.Application.Manager.Repository;

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
   

    public ShareFigiInformationStory(ISimulatorBrokerClient client, IRedisRepository repository)
    {
        _client = client;
        _repository = repository;
    }

    /// <inheritdoc />
    protected override async Task<ShareFigiInformationResponse> DoAsync(ShareFigiInformationStoryContext context)
    {
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
                var data = await _client.GetDataFigiForShareAsync<List<string>>(share);
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
                    Ticker = data[0],
                    Figi = data[1],
                };
                sharesData.Add(brokerData);
                await _repository.UpdateBasket(share, brokerData);
            }
        }

        response.Shares = sharesData;

        return response;
    }
}