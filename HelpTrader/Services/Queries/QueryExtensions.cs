using bgTeam.DataAccess;

namespace HelpTrader.Services.Queries;

public static class QueryExtensions
{
    /// <summary>
    /// Use this method when build query context to get errors about wrong return type on compilation stage instead of runtime.
    /// </summary>
    public static Task<TResponse> ReturnAsync<TContext, TResponse>(this IQueryBuilder queryBuilder, TContext queryContext)
        where TContext : IQueryContext<TResponse>
    {
        return queryBuilder.Build(queryContext).ReturnAsync<TResponse>();
    }
    
    /// <summary>
    /// Sync version of the <see cref="ReturnAsync{TContext, TResponse}"/>.
    /// </summary>
    public static TResponse Return<TContext, TResponse>(this IQueryBuilder queryBuilder, TContext queryContext)
        where TContext : IQueryContext<TResponse>
    {
        return queryBuilder.Build(queryContext).Return<TResponse>();
    }
}

/// <summary>
/// Query context with strongly typed response
/// </summary>
/// <typeparam name="TResponse">Response type of a query context</typeparam>
public interface IQueryContext<TResponse>
{
}