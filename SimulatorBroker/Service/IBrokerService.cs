using SimulatorBroker.Models;

namespace SimulatorBroker.Service;

public interface IBrokerService
{
    public BrokerData GetBrokerData();
    public BrokerData GetBrokerData(string share);
    public List<string> GetListDataShares(string share);
    public List<object>  GetPrice(string figi);
}