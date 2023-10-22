using System.ComponentModel.DataAnnotations;
using System.Numerics;
using bgTeam.DataAccess;
using Google.Protobuf.WellKnownTypes;
using HelpTrader.Domain.Dto;
using HelpTrader.Services.Analysis;
using HelpTrader.Services.Queries;
using Tinkoff.InvestApi;
using Tinkoff.InvestApi.V1;
using CandleInterval = HelpTrader.Services.Story.Enums;

namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Context for <inheritdoc cref="EmaAnalysisStory"/>
/// </summary>
public record EmaAnalysisStoryContext : IStoryContext<List<EmaAnalysisResponse>>
{
    /// <summary>
    /// Ticker.
    /// </summary>
    [Required]
    public List<string> Tickers { get; init; }
    
    /// <summary>
    /// Candlestick interval.
    /// </summary>
    [Required]
    public CandleInterval.CandleInterval Interval { get; init; }
    
    /// <summary>
    /// Smoothing period in EMA
    /// </summary>
    [Required]
    public int SmoothingPeriod{ get; init; }
    
    /// <summary>
    /// Data upload period in days
    /// </summary>
    [Required]
    public int UnloadingPeriodDays { get; init; }
    

    /// <summary>
    /// Candle time from.
    /// </summary>
    public DateTimeOffset Time { get; set; } = DateTimeOffset.UtcNow;
}

/// <summary>
/// Initial for --<inheritdoc cref="EmaAnalysisStoryContext"/> 
/// </summary>
public class EmaAnalysisStory : BaseStory<EmaAnalysisStoryContext, List<EmaAnalysisResponse>>
{
    private readonly InvestApiClient _investApiClient;
    private readonly IQueryBuilder _queryBuilder;
    private readonly IMovingAverage _movingAverage;
    
    public EmaAnalysisStory(
        InvestApiClient investApiClient,
        IQueryBuilder queryBuilder,
        IMovingAverage movingAverage)
    {
        _investApiClient = investApiClient;
        _queryBuilder = queryBuilder;
        _movingAverage = movingAverage;
    }

    protected override async Task<List<EmaAnalysisResponse>> DoAsync(EmaAnalysisStoryContext context)
    {
        var candles = await GetCandles(context);
        var CandlePrices = candles.ToDictionary(x => x.Key, x => x.Value.Candles.Select(x=>x.Close).ToList());
        
        var candlesEma = await GetEmaAsync(context.SmoothingPeriod, CandlePrices);

        return candlesEma;
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

    /// <summary>
    /// Get candles from Tinkoff
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    private async Task <Dictionary<string, GetCandlesResponse>> GetCandles(EmaAnalysisStoryContext context)
    {
        var shareData = await GetFigiDataAsync(context.Tickers);
        var candlesResponse= new Dictionary<string, GetCandlesResponse>();
        
        foreach (var data in shareData)
        {
            var candlesRequest = new GetCandlesRequest
            {
                InstrumentId = data.Figi,
                From = context.Time.Add(TimeSpan.FromDays(-context.UnloadingPeriodDays)).ToTimestamp(), 
                To = context.Time.ToTimestamp(),
                Interval = (Tinkoff.InvestApi.V1.CandleInterval)context.Interval,
            };
            // создать лист GetCandlesRequest, затем вызвать list.Parallel(_investApiClient.MarketData.GetCandles(candlesRequest))
            var candles = _investApiClient.MarketData.GetCandles(candlesRequest);
            candlesResponse.Add(data.Ticker,candles);
        }

        return candlesResponse;
    }
    
    /// <summary>
    /// Get ema
    /// </summary>
    /// <param name="context"></param>
    /// <param name="candles"></param>
    /// <returns></returns>
    private async Task<List<EmaAnalysisResponse>> GetEmaAsync(int smoothingPeriod, Dictionary<string, List<Quotation>> candles )
    {
        var ema = new List<EmaAnalysisResponse>();
        // опробовать многопоточность
        foreach (var candle in candles)
        {
            var candlesEma = new EmaAnalysisResponse()
            {
                Ticker = candle.Key,
                EmaData = await _movingAverage.GetEmaAsync(candle.Value, smoothingPeriod, new List<decimal>()),
            };
            
            ema.Add(candlesEma);
        }

        return ema;
    }
}
