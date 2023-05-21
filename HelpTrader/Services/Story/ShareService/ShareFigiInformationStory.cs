using HelpTrader.Models;

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

    public ShareFigiInformationStory(ISimulatorBrokerClient client)
    {
        _client = client;
    }

    /// <inheritdoc />
    protected override  async Task<ShareFigiInformationResponse> DoAsync(ShareFigiInformationStoryContext context)
    {
        var shareDataList = new ShareFigiInformationResponse(){};
        var dfbvv = new List<ShareData>();
        foreach (var share in context.Shares)
        {
            var data = await _client.GetDataFigiForShareAsync<List<string>>(share);
            var brokerData = new ShareData()
            {
                NameShare = data[0],
                Figi = data[1],
            };
            dfbvv.Add(brokerData);
            
        }
        shareDataList.Shares = dfbvv;
        return shareDataList;
    }
}