namespace HelpTrader.Domain.Dto;

public class ShareData : ShareBase
{
    /// <summary>
    ///Ticker symbol (one to four letter code representing a specific stock)
    /// </summary>
    public string Ticker { get; set; }
}