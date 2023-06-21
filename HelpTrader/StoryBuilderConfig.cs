using bgTeam;
using bgTeam.DataAccess;
using bgTeam.DataAccess.Impl;
using bgTeam.Impl;

namespace HelpTrader;

public static class StoryBuilderConfig
{
    
    public static void StoryBuilderServices(this IServiceCollection services)
    {
        services.AddStories<IStoryLibrary>();
        services.AddQueries<IQueryLibrary>();
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
    
    public static void AddQueries<TFromQueryAssembly>(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblyOf<TFromQueryAssembly>()
            .AddClasses(classes => classes.AssignableTo(typeof(IQuery<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.AddSingleton<IQueryFactory, QueryFactory>();
        services.AddSingleton<IQueryBuilder, QueryBuilder>();
    }
}
public interface IStoryLibrary
{
}

public interface IQueryLibrary
{
}