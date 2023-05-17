using HelpTrader.Models;

namespace HelpTrader.Services;

public interface ISimulatorBrokerClient
{
    public Task<T?> GetDataForShare<T>();
    public Task<T?> GetDataForShareAsync<T>(string share);
    public Task<T?> GetDataFigiForShareAsync<T>(string share);
    public Task<T?> GetPriceForShareAsync<T>(string share);
}