using bgTeam;
using HelpTrader.Domain.Dto;
using HelpTrader.Services.Application.Manager.Repository;

namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Context for <inheritdoc cref="ShareAnalysisFairPriseStory"/>
/// </summary>
public record ShareAnalysisFairPriseStoryContext : IStoryContext<ShareAnalysisFairPriseResponse>
{
    public List<string> Shares { get; init; }
}

/// <summary>
/// Story for Analysis share
/// </summary>
public class ShareAnalysisFairPriseStory : BaseStory<ShareAnalysisFairPriseStoryContext, ShareAnalysisFairPriseResponse>
{
    private readonly IStoryBuilder _storyBuilder;
    private readonly IRedisRepository _repository;


    public ShareAnalysisFairPriseStory(IStoryBuilder storyBuilder, IRedisRepository repository)
    {
        _storyBuilder = storyBuilder;
        _repository = repository;
    }

    /// <inheritdoc />
    protected override async Task<ShareAnalysisFairPriseResponse> DoAsync(ShareAnalysisFairPriseStoryContext context)
    {
        var dataAnalysisShareList = new List<DataAnalysisShare>();
        var response = new ShareAnalysisFairPriseResponse();
        
        var shareData = await GetFigiAsync(context);
        var figiList = shareData.Select(x => x.Figi).ToList();
        
        var sharePrice = await GetPriceInformationAsync(figiList);

        //something logic
        var dataAnalysisShares = from sd in shareData
            join sp in sharePrice on sd.Figi equals sp.Figi
            select new { Name = sd.Ticker, Price = sp.Price };

        foreach (var data in dataAnalysisShares)
        {
            var dataAnalysisShare = new DataAnalysisShare()
            {
                TickerShare = data.Name,
                Price = data.Price,
                FairPrice = data.Price * 3,
            };
            dataAnalysisShareList.Add(dataAnalysisShare);
        }

        response.FairPrises = dataAnalysisShareList;

        return response;
    }

    /// <summary>
    /// get figi
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private async Task<List<ShareData>> GetFigiAsync(ShareAnalysisFairPriseStoryContext context)
    {
        var cont = new ShareFigiInformationStoryContext()
        {
            Shares = context.Shares
        };
        
        var shareData = await _storyBuilder.ReturnAsync<ShareFigiInformationStoryContext, ShareFigiInformationResponse>(cont);
        return shareData.Shares;
    }
    
    /// <summary>
    /// get price
    /// </summary>
    /// <param name="figiList"></param>
    /// <returns></returns>
    private async Task<List<SharePrice>> GetPriceInformationAsync(List<string> figiList)
    {
        var context = new SharePriceInformationStoryContext()
        {
            Figi = figiList
        };
        var sharePrice = await _storyBuilder.ReturnAsync<SharePriceInformationStoryContext, SharePriceInformationResponse>(context);
        return sharePrice.Prices;
    }
}