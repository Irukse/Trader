using SimulatorBroker.Models;

namespace SimulatorBroker.Service;

public class BrokerService : IBrokerService
{
    private Random _price = new Random();
    
    public BrokerService()
    {
        
    }

    public BrokerData GetBrokerData()
    {
        var price = new decimal(_price.Next(10, 15));
        var brokerData = new BrokerData()
        {
            Share = "Ford",
            Price = price,
        };
        
        return brokerData;
    }
}