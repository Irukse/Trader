using HelpTrader.Models;

namespace HelpTrader.Services;

public interface IBrokerDataService
{
    public Task<BrokerData> AnalysisShare();
    
    public Task<BrokerData> AnalysisForShare(string share);

   // public Task<List<BrokerData>> GetListShareAsync(List<string> share);

    public Task<List<ShareData>> GetListDataFigiShareAsync(List<string> share);

  //  public Task<SharePrice> GetPriceShareAsync(string figi);

    public Task<List<SharePrice>> GetPriceShareListAsync(List<string> figiList);

    public Task<List<DataAnalysisShare>> GetAnalysisShareAsync(List<string> share);
}