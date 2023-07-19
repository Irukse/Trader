using Tinkoff.InvestApi.V1;

namespace HelpTrader.Services.Story.Enums;

/// <summary>
/// Type ema
/// </summary>
public enum PriceType
{
    /// <summary>
    /// Opening price for 1 instrument.
    /// </summary>
    Open = HistoricCandle.OpenFieldNumber, 
    
    /// <summary>
    /// Maximum price for 1 tool
    /// </summary>
    High = HistoricCandle.HighFieldNumber, 
    
    /// <summary>
    /// Minimum price for 1 tool
    /// </summary>
    Low = HistoricCandle.LowFieldNumber, 
    
    /// <summary>
    /// Closing price for 1 tool
    /// </summary>
    Close = HistoricCandle.CloseFieldNumber,  
}