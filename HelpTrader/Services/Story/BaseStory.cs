using bgTeam;
using bgTeam.Extensions;

namespace HelpTrader.Services.Story;

/// <summary>
/// Base story to check context
/// </summary>
/// <typeparam name="TContext"></typeparam>
/// <typeparam name="TEntity"></typeparam>
public abstract class BaseStory<TContext, TEntity> : IStory<TContext, TEntity>
    where TContext : IStoryContext<TEntity>
{
    public Task<TEntity> ExecuteAsync(TContext context)
    {
        context.CheckNull();
        return DoAsync(context);
    }

    protected abstract Task<TEntity> DoAsync(TContext context);
    
}