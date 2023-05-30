using bgTeam;
using bgTeam.Impl;

namespace HelpTrader;

public static class StoryBuilderConfig
{
    
    public static void StoryBuilderServices(this IServiceCollection services)
    {
        services.AddStories<IStoryLibrary>();
    }
    
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
public interface IStoryLibrary
{
}