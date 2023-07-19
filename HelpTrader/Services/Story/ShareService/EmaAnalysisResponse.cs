namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Historic candle
/// </summary>
public class EmaAnalysisResponse
{
    /// <summary>
    /// Ticker
    /// </summary>
    public string Ticker { get; init; }
    
    /// <summary>
    /// Ema data
    /// </summary>
    public List<decimal> EmaData { get; init; }
}