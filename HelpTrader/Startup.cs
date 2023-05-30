using bgTeam;
using HelpTrader.Services;
using HelpTrader.Services.Application.Manager.Repository;
using HelpTrader.WebApp;

namespace HelpTrader;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration config)
    {
        Configuration = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddRazorPages();
        services.AddRouting();
        services.AddControllers();
        services.AddStackExchangeRedisCache(options => 
        { 
            options.Configuration = Configuration.GetValue<string>("CacheSettings:ConnectionString");
        });
 
        DiSetup(services);
    }

    protected virtual void DiSetup(IServiceCollection services)
    {
       // services.AddHelpTraderServices();
        services.StoryBuilderServices();
        services.AddScoped<IRedisRepository, RedisRepository>();
        services.AddScoped<ISimulatorBrokerClient, SimulatorBrokerClient>();
        services.AddScoped<IStoryBuilder, StoryBuilder>();
    }
    
    public void Configure(WebApplication app) {
        if (!app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.MapControllers();
        app.Run();
    }
}