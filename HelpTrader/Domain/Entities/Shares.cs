using bgTeam.DataAccess.Impl.Dapper;

namespace HelpTrader.Domain.Entities;

/// <summary>
/// Shares directory
/// </summary>
[TableName("shares")]
public class Shares
{
    [ColumnName("id")]
    [Identity]
    public long Id { get; set; }
    
    [ColumnName("figi")]
    public string FIGI { get; set; }
    
    [ColumnName("sector")]
    public string Sector { get; set; }
    
    [ColumnName("currency")]
    public string Currency { get; set; }
    
    [ColumnName("ticker")]
    public string Ticker { get; set; }
}