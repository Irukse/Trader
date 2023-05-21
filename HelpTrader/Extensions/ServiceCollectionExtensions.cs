using bgTeam;
using bgTeam.Impl;

namespace HelpTrader.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddStories<TFromStoryAssembly>(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblyOf<TFromStoryAssembly>()
            .AddClasses(classes => classes.AssignableTo(typeof(IStory<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.AddSingleton<IStoryFactory, StoryFactory>();
        services.AddSingleton<IStoryBuilder, StoryBuilder>();
    }
}