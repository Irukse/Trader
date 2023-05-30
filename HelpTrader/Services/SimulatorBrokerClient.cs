namespace HelpTrader.Services;

public class SimulatorBrokerClient : HttpServiceClientBase, ISimulatorBrokerClient
{
    private const string SimulatorBrokerShareEndpoint = @"https://localhost:5000/BrokerData/share/{0}";
    private const string ShareFigiEndpoint = @"https://localhost:5000/BrokerData/datashare/{0}";
    private const string SharePriceEndpoint = @"https://localhost:5000/BrokerData/Price/{0}";

    private const string SimulatorBrokerEndpoint = "https://localhost:5000/BrokerData";

    public async Task<T?> GetDataForShare<T>()
    {
        var result = await GetSimulatorData<T>(SimulatorBrokerEndpoint);
        return result;
    }

    public async Task<T?> GetDataForShareAsync<T>(string share)
    {
        var url = GetUrl(SimulatorBrokerShareEndpoint,share);
        var result = await GetSimulatorData<T>(url);
        return result;
    }
    
    public async Task<T?> GetDataFigiForShareAsync<T>(string share)
    {
        var url = GetUrl(ShareFigiEndpoint,share);
        var result = await GetSimulatorData<T>(url);
        return result;
    }
    
    public async Task<T?> GetPriceForShareAsync<T>(string share)
    {
        var url = GetUrl(SharePriceEndpoint,share);
        var result = await GetSimulatorData<T>(url);
        return result;
    }

    private string GetUrl(string endPoint, string url)
    {
        var verificationUrl = string.Format(endPoint, url);
        return verificationUrl;
    }
}