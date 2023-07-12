//using bgTeam.DataAccess;

using bgTeam.DataAccess;
using bgTeam.Extensions;
using Google.Protobuf.WellKnownTypes;
using HelpTrader.Domain.Dto;
using HelpTrader.Services.Queries;
using HelpTrader.Services.Story.Enums;
using Microsoft.AspNetCore.Http.Extensions;
using Tinkoff.InvestApi;
using Tinkoff.InvestApi.V1;
using CandleInterval = HelpTrader.Services.Story.Enums.CandleInterval;

namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Context for <inheritdoc cref="TechnicalAnalysisStory"/>
/// </summary>
public record TechnicalAnalysisStoryContext : IStoryContext<TechnicalAnalysisResponse>
{
    /// <summary>
    /// Ticker.
    /// </summary>
    public List<string> Tickers { get; init; }
    
    /// <summary>
    /// Candle time from.
    /// </summary>
  //  public DateTime TimeFrom  = DateTime.Now;
    public DateTimeOffset TimeFrom { get; set; } = DateTimeOffset.UtcNow;
    //
    // /// <summary>
    // /// Candle time to.
    // /// </summary>
    // public DateTime TimeTo { get; init; }
    //
    /// <summary>
    /// Candlestick interval.
    /// </summary>
    public Tinkoff.InvestApi.V1.CandleInterval Interval { get; init; }
}

public class TechnicalAnalysisStory : BaseStory<TechnicalAnalysisStoryContext, TechnicalAnalysisResponse>
{
    private readonly InvestApiClient _investApiClient;
    private readonly IQueryBuilder _queryBuilder;

    public TechnicalAnalysisStory(
        IQueryBuilder queryBuilder, 
        InvestApiClient investApiClient)
    {
        _investApiClient = investApiClient;
        _queryBuilder = queryBuilder;
    }

    protected override Task<TechnicalAnalysisResponse> DoAsync(TechnicalAnalysisStoryContext context)
    {
        var shareData = GetFigiDataAsync(context.Tickers);
        var data = shareData.Result.FirstOrDefault();

        var candlesRequest = new GetCandlesRequest
        {
            InstrumentId = data.Figi,
            From = context.TimeFrom.Add(TimeSpan.FromDays(-30)).ToTimestamp(), 
            To = context.TimeFrom.ToTimestamp(),
           // Interval = context.Interval,
           Interval = Tinkoff.InvestApi.V1.CandleInterval.Day,
        };

        var test = _investApiClient.MarketData.GetCandles(candlesRequest);
       var t = test.Candles.ToList();
        var ma = 5;

        for (int i = 0; i < t.Count(); i++)
        {
            
        }
        //test.Candles
        return null;
    }

    /// <summary>
    /// Get share data
    /// </summary>
    /// <param name="tickers"></param>
    /// <returns></returns>
    private async Task<IEnumerable<ShareData>> GetFigiDataAsync(IEnumerable<string> tickers)
    {
        var context = new GetFigiQueryContext(tickers);
        return await _queryBuilder.ReturnAsync<GetFigiQueryContext, IEnumerable<ShareData>>(context);
    }
}