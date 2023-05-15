using HelpTrader.Models;

namespace HelpTrader.Services;

public interface ISimulatorBrokerClient
{
    public Task<T?> GetData<T>();
    public Task<T?> GetDataForShare<T>(string share);
}