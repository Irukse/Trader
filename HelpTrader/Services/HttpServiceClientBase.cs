using System.Web;

namespace HelpTrader.Services;

public abstract class HttpServiceClientBase
{
    protected  Task<T?> GetSimulatorData<T>(string serviceUrl)
    {
        var client = new HttpClient();
        var responseTask = client.GetAsync(serviceUrl);
        responseTask.Wait();
       
        var result = responseTask.Result;

        return result.Content.ReadFromJsonAsync<T>();
    }
}