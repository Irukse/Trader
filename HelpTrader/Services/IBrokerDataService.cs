using HelpTrader.Models;

namespace HelpTrader.Services;

public interface IBrokerDataService
{
    public Task<BrokerData> AnalysisShare();
    
    public Task<BrokerData> AnalysisForShare(string share);

    public Task<List<BrokerData>> GetListShareAsync(List<string> share);
}