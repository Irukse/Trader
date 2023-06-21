using bgTeam.DataAccess;
using HelpTrader.Domain.Entities;
using Tinkoff.InvestApi;

namespace HelpTrader.Services;

public class InitialDataOfTheDatabase : IHostedService
{
    private readonly InvestApiClient _investApiClient;
    private readonly ICrudService _crudService;
    private readonly IConnectionFactory _connectionFactory;

    public InitialDataOfTheDatabase(
        InvestApiClient investApiClient, 
        ICrudService crudService, 
        IConnectionFactory connectionFactory)
    {
        _investApiClient = investApiClient;
        _crudService = crudService;
        _connectionFactory = connectionFactory;
    }

    /// <summary>
    /// Initial database when application started
    /// filling the database with information about promotions
    /// </summary>
    private async Task InitialDatabaseStartData()
    {
        var sharesResponse = _investApiClient.Instruments.Shares();
        
        using var connection = await _connectionFactory.CreateAsync();
        using var transaction = connection.BeginTransaction();

        foreach (var share in sharesResponse.Instruments)
        {
            var shareData = new Shares
            {
                FIGI = share.Figi,
                Sector = share.Sector,
                Ticker = share.Ticker,
                Currency = share.Currency,
            };
            await _crudService.InsertAsync<Shares>(shareData, connection, transaction);
        }
        transaction.Commit();
        connection.Close();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await InitialDatabaseStartData();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}