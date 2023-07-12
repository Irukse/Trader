namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Historic candle
/// </summary>
public class TechnicalAnalysisResponse
{
    // /// <summary>
    // /// A sign of the completion of the candle.
    // /// false means that the candle for the current interval has not yet been fully formed.
    // /// </summary>
    // public bool IsComplete { get; init; }
    //
    // /// <summary>
    // /// Opening price for 1 instrument.
    // /// </summary>
    // public decimal PriceOpen { get; init; }
    //
    // /// <summary>
    // /// Maximum price for 1 tool.
    // /// </summary>
    // public decimal PriceHigh { get; init; }
    //
    // /// <summary>
    // /// Minimum price for 1 tool.
    // /// </summary>
    // public decimal PriceLow { get; init; }
    //
    // /// <summary>
    // /// Closing price for 1 instrument
    // /// </summary>
    // public decimal PriceClose { get; init; }
    //
    // /// <summary>
    // /// Trading volume in lots
    // /// </summary>
    // public decimal TradingVolume { get; init; }

    public string Advice  { get; init; }
    
    /// <summary>
    /// Candle time in UTC timezone.
    /// </summary>
    public DateTime Time { get; init; }
}