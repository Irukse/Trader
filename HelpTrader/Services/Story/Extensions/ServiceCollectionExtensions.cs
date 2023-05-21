
using HelpTrader.Extensions;


namespace HelpTrader.Services.Story.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add all queries and stories and services they require to the container.
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddSqrsDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddStories<IStoryLibrary>();
        return serviceCollection;
    }
}

public interface IStoryLibrary
{
}
