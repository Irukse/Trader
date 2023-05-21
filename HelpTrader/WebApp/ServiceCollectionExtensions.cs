using HelpTrader.Services.Story.Extensions;

namespace HelpTrader.WebApp;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add api dependencies
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddHelpTraderServices(this IServiceCollection services)
    {
        //Common dependencies
        services.AddSqrsDependencies();
    }
}