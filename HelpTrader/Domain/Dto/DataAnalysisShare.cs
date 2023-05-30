namespace HelpTrader.Domain.Dto;

public class DataAnalysisShare

{
    /// <summary>
    ///Ticker symbol
    /// </summary>
    public string TickerShare { get; set; }

    /// <summary>
    /// Share price
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Fair value of a share
    /// </summary>
    public decimal? FairPrice { get; set; }
}