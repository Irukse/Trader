using HelpTrader.Models;
using HelpTrader.Services.Application.Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Context for query to get figi
/// </summary>
public record ShareFigiInformationStoryContext : IStoryContext<ShareFigiInformationResponse>
{
    public List<string> Shares { get; init; }
}

/// <summary>
/// story for get figi
/// </summary>
public class ShareFigiInformationStory : BaseStory<ShareFigiInformationStoryContext, ShareFigiInformationResponse>
{
    private readonly ISimulatorBrokerClient _client;
    private readonly IBasketRepository _repository;

    public ShareFigiInformationStory(ISimulatorBrokerClient client, IBasketRepository repository)
    {
        _client = client;
        _repository = repository;
    }

    /// <inheritdoc />
    protected override  async Task<ShareFigiInformationResponse> DoAsync(ShareFigiInformationStoryContext context)
    {
        var response = new ShareFigiInformationResponse(){};
        var sharesData = new List<ShareData>();
        
        foreach (var share in context.Shares)
        {
            var dataFromCash = await _repository.GetBasket(share);

            if (dataFromCash != null)
            {
                sharesData.Add(dataFromCash);
            }

            else
            {
                var data = await _client.GetDataFigiForShareAsync<List<string>>(share);
                var brokerData = new ShareData()
                {
                    NameShare = data[0],
                    Figi = data[1],
                };
                sharesData.Add(brokerData);
                await _repository.UpdateBasket(brokerData);
            }
            
            
            // var data = await _client.GetDataFigiForShareAsync<List<string>>(share);
            // var brokerData = new ShareData()
            // {
            //     NameShare = data[0],
            //     Figi = data[1],
            // };
            // dfbvv.Add(brokerData);
            // await _repository.UpdateBasket(brokerData);
        }
        response.Shares = sharesData;
        
        return response;
    }
}