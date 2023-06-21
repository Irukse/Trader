using Google.Protobuf.Collections;
using HelpTrader.Domain.Dto;
using HelpTrader.Services.Application.Manager.Repository;
using Tinkoff.InvestApi;
using Tinkoff.InvestApi.V1;

namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Context for <inheritdoc cref="SharePriceInformationStory"/>
/// </summary>
public record SharePriceInformationStoryContext : IStoryContext<List<SharePrice>>
{
    public RepeatedField<string> Figi { get; init; }
}

/// <summary>
/// Get price by figi
/// </summary>
public class SharePriceInformationStory : BaseStory<SharePriceInformationStoryContext, List<SharePrice>>
{
    private readonly InvestApiClient _investApiClient;
    private readonly IRedisRepository _repository;

    public SharePriceInformationStory(IRedisRepository repository, InvestApiClient investApiClient)
    {
        _repository = repository;
        _investApiClient = investApiClient;
    }

    /// <inheritdoc />
    protected override async Task<List<SharePrice>> DoAsync(SharePriceInformationStoryContext context)
    {
        var getLastPricesRequest = new GetLastPricesRequest
        {
            InstrumentId = { context.Figi }
        };

        var lastPrices = await _investApiClient.MarketData.GetLastPricesAsync(getLastPricesRequest);

        var brokerDataList = lastPrices.LastPrices
            .Select(lastPrice => new SharePrice() 
                { Figi = lastPrice.Figi, LastPrices = lastPrice.Price, Time = lastPrice.Time.ToDateTime()}).ToList();
        
        return brokerDataList;
    }
}