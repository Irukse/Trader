using HelpTrader.Models;

namespace HelpTrader.Services;

public class SimulatorBrokerClient : HttpServiceClientBase, ISimulatorBrokerClient
{
    private const string SimulatorBrokerShareEndpoint = @"https://localhost:5000/BrokerData/share/{0}";
    private const string SimulatorBrokerEndpoint = "https://localhost:5000/BrokerData";

    public async Task<T?> GetData<T>()
    {
        var result = await GetSimulatorData<T>(SimulatorBrokerEndpoint);
        return result;
    }

    public async Task<T?> GetDataForShareAsync<T>(string share)
    {
        var url = GetUrl(share);
        var result = await GetSimulatorData<T>(url);
        return result;
    }

    private string GetUrl(string url)
    {
        var verificationUrl = string.Format(SimulatorBrokerShareEndpoint, url);
        return verificationUrl;
    }
}