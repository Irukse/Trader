using bgTeam;

namespace HelpTrader.Services.Story;

public static class StoryExtensions
{
    /// <summary>
    /// Use this method when build story context to get errors about wrong return type on compilation stage instead of runtime.
    /// </summary>
    public static Task<TResponse> ReturnAsync<TContext, TResponse>(this IStoryBuilder storyBuilder, TContext queryContext)
        where TContext : IStoryContext<TResponse>
    {
        return storyBuilder.Build(queryContext).ReturnAsync<TResponse>();
    }

}

/// <summary>
/// Story context with strongly typed response
/// </summary>
/// <typeparam name="TResponse">Response type of a query context</typeparam>
public interface IStoryContext<TResponse>
{
}