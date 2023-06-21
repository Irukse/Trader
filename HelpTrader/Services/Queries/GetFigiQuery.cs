using bgTeam.DataAccess;
using HelpTrader.Domain.Dto;

namespace HelpTrader.Services.Queries;

/// <summary>
/// context for <inheritdoc cref="GetFigiQuery"/>
/// </summary>
/// <param name="tiskers"></param>
public record GetFigiQueryContext(IEnumerable<string> tiskers) : IQueryContext<IEnumerable<ShareData>>;

/// <summary>
/// query for get figi
/// </summary>
public class GetFigiQuery : BaseQuery<GetFigiQueryContext, IEnumerable<ShareData>>
{
    private readonly ICrudService _crudService;

    public GetFigiQuery(ICrudService crudService)
    {
        _crudService = crudService;
    }
    
    private readonly string GET_FIGI_SHARES_QUERY = $@"
SELECT tisker, figi
FROM shares
WHERE tisker=ANY(@tiskers)
";

    public override Task<IEnumerable<ShareData>> ExecuteAsync(GetFigiQueryContext context)
    {
        return _crudService.GetAllAsync<ShareData>(
            GET_FIGI_SHARES_QUERY,
            new
            {
                context.tiskers
            });
    }
}