using FluentMigrator.Runner;

namespace Migrations;

public class MigrationHostedService : IHostedService
{
    private readonly IHostApplicationLifetime _appLifeTime;
    private readonly IServiceProvider _serviceProvider;
    
    public MigrationHostedService(IHostApplicationLifetime appLifeTime, IServiceProvider serviceProvider)
    {
        _appLifeTime = appLifeTime;
        _serviceProvider = serviceProvider;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        
        using var scope = _serviceProvider.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        runner.MigrateUp();
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
