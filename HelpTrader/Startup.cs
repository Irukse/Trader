using bgTeam;
using bgTeam.DataAccess;
using HelpTrader.Services;
using HelpTrader.Services.Application.Manager.Repository;
using bgTeam.DataAccess.Impl;
using bgTeam.DataAccess.Impl.Dapper;
using bgTeam.DataAccess.Impl.PostgreSQL;

namespace HelpTrader;

public sealed class Startup
{
    private IConfiguration Configuration { get; }

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
        services.AddInvestApiClient((_, settings) => settings.AccessToken = "");

        DiSetup(services);
    }

    private void DiSetup(IServiceCollection services)
    {
        services.StoryBuilderServices();
        services.AddScoped<IRedisRepository, RedisRepository>();
        services.AddScoped<ISimulatorBrokerClient, SimulatorBrokerClient>();
        services.AddScoped<IStoryBuilder, StoryBuilder>();
        services.AddScoped<IQueryBuilder, QueryBuilder>();
        
        services.AddSingleton<IConnectionSetting, ConnectionSettings>();
        services.AddSingleton<ISqlDialect, SqlDialectWithUnderscoresDapper>();
        services.AddSingleton<ICrudService, CrudServiceDapper>();
        services.AddSingleton<IConnectionFactory, ConnectionFactoryPostgreSQL>();
    }
    
    public static void Configure(WebApplication app) {
      //  var svc = ((IApplicationBuilder)app).ApplicationServices.GetService<IService>(); // no exception
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