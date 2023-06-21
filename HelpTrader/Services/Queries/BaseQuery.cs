using bgTeam.DataAccess;

namespace HelpTrader.Services.Queries;

/// <summary>
/// Base query class which implement only execute async method
/// </summary>
/// <typeparam name="TQueryContext"></typeparam>
/// <typeparam name="TQueryResult"></typeparam>
public abstract class BaseQuery<TQueryContext, TQueryResult> : IQuery<TQueryContext, TQueryResult>
    where TQueryContext : IQueryContext<TQueryResult>
{
    /// <summary>
    /// Execute query logic
    /// </summary>
    /// <param name="context">Query context</param>
    public virtual TQueryResult Execute(TQueryContext context)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Execute query logic
    /// </summary>
    /// <param name="context">Query context</param>
    public abstract Task<TQueryResult> ExecuteAsync(TQueryContext context);
}