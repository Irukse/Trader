using System.Globalization;
using HelpTrader.Domain.Dto;
using HelpTrader.Services.Application.Manager.Repository;

namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Context for <inheritdoc cref="SharePriceInformationStory"/>
/// </summary>
public record SharePriceInformationStoryContext : IStoryContext<SharePriceInformationResponse>
{
    public List<string> Figi { get; init; }
}

/// <summary>
/// Get price by figi
/// </summary>
public class SharePriceInformationStory : BaseStory<SharePriceInformationStoryContext, SharePriceInformationResponse>
{
    private readonly ISimulatorBrokerClient _client;
    private readonly IRedisRepository _repository;


    public SharePriceInformationStory(ISimulatorBrokerClient client, IRedisRepository repository)
    {
        _client = client;
        _repository = repository;
    }

    /// <inheritdoc />
    protected override async Task<SharePriceInformationResponse> DoAsync(SharePriceInformationStoryContext context)
    {
        var brokerDataList = new List<SharePrice>();
        var response = new SharePriceInformationResponse() { };

        foreach (var figi in context.Figi)
        {
            var dataFromCash = await _repository.GetBasket<SharePrice>(figi);

            if (dataFromCash != null)
            {
                brokerDataList.Add((SharePrice)dataFromCash);
            }

            else
            {
                var data = await _client.GetPriceForShareAsync<List<object>>(figi);
                //от брокера получаем сообщение такого формата:
                // {
                //"figi" : "BBG004730N88",
                //"price" : "111.1"
                // }
                var one = data[0];
                var two = data[1].ToString();

                CultureInfo cultures = new CultureInfo("en-US");
                decimal priceVal = Convert.ToDecimal(two, cultures);

                var brokerData = new SharePrice()
                {
                    Figi = one.ToString(), // если объекты придут в другом порядке...
                    Price = priceVal,
                };
                brokerDataList.Add(brokerData);
                await _repository.UpdateBasket(figi, brokerData);
            }
        }

        response.Prices = brokerDataList;

        return response;
    }
}