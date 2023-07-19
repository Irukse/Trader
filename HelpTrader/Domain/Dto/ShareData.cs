namespace HelpTrader.Domain.Dto;

/// <summary>
/// Promotion data
/// </summary>
public class ShareData : ShareBase
{
    /// <summary>
    ///Ticker symbol (one to four letter code representing a specific stock)
    /// </summary>
    public string Ticker { get; set; }
}