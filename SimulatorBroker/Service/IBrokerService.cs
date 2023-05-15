using SimulatorBroker.Models;

namespace SimulatorBroker.Service;

public interface IBrokerService
{
    public BrokerData GetBrokerData();
    public BrokerData GetBrokerData(string share);
}