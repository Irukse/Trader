using bgTeam.DataAccess;
using HelpTrader.Domain.Dto;

namespace HelpTrader.Services.Queries;

/// <summary>
/// context for <inheritdoc cref="GetFigiQuery"/>
/// </summary>
/// <param name="tiskers"></param>
public record GetFigiQueryContext(IEnumerable<string> tickers) : IQueryContext<IEnumerable<ShareData>>;

/// <summary>
/// query for get figi
/// </summary>
public class GetFigiQuery : BaseQuery<GetFigiQueryContext, IEnumerable<ShareData>>
{
    private readonly ICrudService _crudService;
    private readonly IConnectionFactory _connectionFactory;
    public GetFigiQuery(ICrudService crudService, IConnectionFactory connectionFactory)
    {
        _crudService = crudService;
        _connectionFactory = connectionFactory;
    }
    
    private readonly string GET_FIGI_SHARES_QUERY = $@"
SELECT DISTINCT ticker, figi
FROM shares
WHERE ticker=ANY(@tickers)
";

    public override async Task<IEnumerable<ShareData>> ExecuteAsync(GetFigiQueryContext context)
    {
        using var connection = await _connectionFactory.CreateAsync();
        using var transaction = connection.BeginTransaction();
        
        var result = await _crudService.GetAllAsync<ShareData>(
            GET_FIGI_SHARES_QUERY,
            new
            {
                context.tickers
            });

        //var result = await _crudService.GetAllAsync<Shares>(x => context.tickers.Contains(x.Ticker));
        
       var x = result.DistinctBy(x => x.Ticker).Select(x => new ShareData() { Ticker = x.Ticker, Figi = x.Figi });
        
        
        transaction.Commit();
        connection.Close();

        return x;
    }
}