using Google.Protobuf.WellKnownTypes;

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
    
    /// <summary>
    /// Ema data time
    /// </summary>
    public Dictionary<string, List<DateTime>> EmaDataTime { get; init; }
}