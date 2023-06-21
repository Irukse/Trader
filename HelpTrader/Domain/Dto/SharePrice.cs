using Google.Protobuf.WellKnownTypes;

namespace HelpTrader.Domain.Dto;

public class SharePrice : ShareBase
{
    /// <summary>
    /// Share price
    /// </summary>
    public decimal LastPrices { get; set; }
    
    /// <summary>
    /// The time when the last price was received
    /// in the UTC time zone according to the exchange time.
    /// </summary>
    public DateTime Time { get; set; }
}